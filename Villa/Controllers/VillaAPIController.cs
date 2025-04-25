using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa;
using Villa.Data;
using Villa.Logging;
using Villa.Models.Dto;
using Villa.Repository;
using Villa.Repository.IRepository;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _villaRepository;

        public VillaAPIController(ILogging logger, IMapper mapper,IVillaRepository villaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _villaRepository = villaRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VillaDTo>> GetVillas()
        {
            _logger.Log("Getting all villas","");
            IEnumerable<Models.Villa> villaList = await _villaRepository.GetAllAsync();
            return Ok(_mapper.Map<VillaDTo>(villaList));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTo>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("Invalid villa ID", "error");
                return BadRequest();
            }
            var villa = await _villaRepository.GetAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTo>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VillaDTo>> CreateVilla([FromBody] VillaCreateDTo villaDTovilla)
        {
            if (await _villaRepository.GetAsync(u => u.Name.ToLower() == villaDTovilla.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists!");
                return BadRequest(ModelState);
            }

            if (villaDTovilla == null)
            {
                return BadRequest(villaDTovilla);
            }
           
            Models.Villa villa = _mapper.Map<Models.Villa>(villaDTovilla);

            
           await _villaRepository.CreateAsync(villa);

            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTo>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa =await _villaRepository.GetAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
           await _villaRepository.RemoveAsync(villa);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTo>> UpdateVilla(int id, [FromBody] VillaUpdateDTo villaDTovilla)
        {
            if (villaDTovilla == null || id != villaDTovilla.Id)
            {
                return BadRequest();
            }

            Models.Villa villa = _mapper.Map<Models.Villa>(villaDTovilla);

           await _villaRepository.UpdateAsync(villa);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTo>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTo> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _villaRepository.GetAsync(v => v.Id == id,tracked:false);

            VillaUpdateDTo villaDTo=_mapper.Map<VillaUpdateDTo>(villa);

            if (villa == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(villaDTo, ModelState);

            Models.Villa villaModel = _mapper.Map<Models.Villa>(villaDTo);

          await _villaRepository.UpdateAsync(villaModel);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}