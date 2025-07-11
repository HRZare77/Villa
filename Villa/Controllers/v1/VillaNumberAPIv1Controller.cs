﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villa.Data;
using Villa.Logging;
using Villa.Models;
using Villa.Models.Dto;
using Villa.Repository;
using Villa.Repository.IRepository;

namespace Villa.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VillaNumberAPIv1Controller : ControllerBase
    {
        private readonly ILogging _logger;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _villaNumberRepository;
        private readonly IVillaRepository _villaRepository;

        public VillaNumberAPIv1Controller(ILogging logger, IMapper mapper, IVillaNumberRepository villaNumberRepository, APIResponse response, IVillaRepository villaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _villaNumberRepository = villaNumberRepository;
            _response = response;
            _villaRepository = villaRepository;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillasNumber()
        {
            _logger.Log("Getting all villas", "");
            try
            {
                IEnumerable<VillaNumber> villaList = await _villaNumberRepository.GetAllAsync(includeProperties: "Villa");
                _response.Result = _mapper.Map<List<VillaNumberDTo>>(villaList);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());

            }
            return _response;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Invalid villa ID", "error");
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _villaNumberRepository.GetAsync(v => v.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<VillaNumberDTo>(villaNumber);
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());
            }
            return _response;
        }

        //[MapToApiVersion("2.0")]
        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "string1", "string2" };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTo villaDTovilla)
        {
            try
            {
                if (await _villaNumberRepository.GetAsync(u => u.VillaNo == villaDTovilla.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Number already exists!");
                    return BadRequest(ModelState);
                }

                if (await _villaRepository.GetAsync(u => u.Id == villaDTovilla.VillaId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa Id is Invalid!");
                    return BadRequest(ModelState);
                }

                if (villaDTovilla == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                VillaNumber villa = _mapper.Map<VillaNumber>(villaDTovilla);


                await _villaNumberRepository.CreateAsync(villa);

                _response.Result = _mapper.Map<VillaNumberDTo>(villa);
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villa.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());

            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _villaNumberRepository.GetAsync(v => v.VillaNo == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _villaNumberRepository.RemoveAsync(villa);
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());

            }
            return _response;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTo villaDTovilla)
        {
            try
            {
                if (villaDTovilla == null || id != villaDTovilla.VillaNo)
                {
                    return BadRequest();
                }

                if (await _villaRepository.GetAsync(u => u.Id == villaDTovilla.VillaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Id is Invalid!");
                    return BadRequest(ModelState);
                }

                VillaNumber villa = _mapper.Map<VillaNumber>(villaDTovilla);

                await _villaNumberRepository.UpdateAsync(villa);

                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());

            }
            return _response;
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDTo> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var villa = await _villaNumberRepository.GetAsync(v => v.VillaNo == id, tracked: false);

                VillaNumberUpdateDTo villaDTo = _mapper.Map<VillaNumberUpdateDTo>(villa);

                if (villa == null)
                {
                    return NotFound();
                }

                patchDTO.ApplyTo(villaDTo, ModelState);

                VillaNumber villaModel = _mapper.Map<VillaNumber>(villaDTo);

                await _villaNumberRepository.UpdateAsync(villaModel);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors.Add(ex.ToString());

            }
            return _response;
        }
    }
}