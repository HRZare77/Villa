using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa;
using Villa.Data;
using Villa.Logging;
using Villa.Models.Dto;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public VillaAPIController(ILogging logger, ApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VillaDTo>> GetVillas()
        {
            _logger.Log("Getting all villas","");
            List<Models.Villa> villaList = await _applicationDbContext.Villas.ToListAsync();
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
            var villa = await _applicationDbContext.Villas.FirstOrDefaultAsync(v => v.Id == id);
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
            if (await _applicationDbContext.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == villaDTovilla.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists!");
                return BadRequest(ModelState);
            }

            if (villaDTovilla == null)
            {
                return BadRequest(villaDTovilla);
            }
            //if (villaDTovilla.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            Models.Villa villa = _mapper.Map<Models.Villa>(villaDTovilla);

            //Models.Villa villa = new()
            //{
            //    Name = villaDTovilla.Name,
            //    Occupancy = villaDTovilla.Occupancy,
            //    Sqft = villaDTovilla.Sqft,
            //    ImageUrl = villaDTovilla.ImageUrl,
            //    Amenity = villaDTovilla.Amenity,
            //    Details = villaDTovilla.Details,
            //    Rate = villaDTovilla.Rate,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now
            //};

            await _applicationDbContext.Villas.AddAsync(villa);
            await _applicationDbContext.SaveChangesAsync();
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
            var villa =await _applicationDbContext.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _applicationDbContext.Villas.Remove(villa);
           await _applicationDbContext.SaveChangesAsync();
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

            //Models.Villa villa = new()
            //{
            //    Name = villaDTovilla.Name,
            //    Occupancy = villaDTovilla.Occupancy,
            //    Sqft = villaDTovilla.Sqft,
            //    ImageUrl = villaDTovilla.ImageUrl,
            //    Amenity = villaDTovilla.Amenity,
            //    Details = villaDTovilla.Details,
            //    Rate = villaDTovilla.Rate,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now
            //};
            _applicationDbContext.Villas.Update(villa);
            await _applicationDbContext.SaveChangesAsync();
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
            var villa = await _applicationDbContext.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            VillaUpdateDTo villaDTo=_mapper.Map<VillaUpdateDTo>(villa);

            //VillaUpdateDTo villaDTo = new()
            //{
            //    Name = villa.Name,
            //    Occupancy = villa.Occupancy,
            //    Sqft = villa.Sqft,
            //    ImageUrl = villa.ImageUrl,
            //    Amenity = villa.Amenity,
            //    Details = villa.Details,
            //    Rate = villa.Rate
            //};  

            if (villa == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(villaDTo, ModelState);

            Models.Villa villaModel = _mapper.Map<Models.Villa>(villaDTo);

            //Models.Villa villaModel = new()
            //{
            //    Name = villaDTo.Name,
            //    Occupancy = villaDTo.Occupancy,
            //    Sqft = villaDTo.Sqft,
            //    ImageUrl = villaDTo.ImageUrl,
            //    Amenity = villaDTo.Amenity,
            //    Details = villaDTo.Details,
            //    Rate = villaDTo.Rate
            //};

            _applicationDbContext.Villas.Update(villaModel);
            await _applicationDbContext.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}