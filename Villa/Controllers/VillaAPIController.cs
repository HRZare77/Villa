using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        public VillaAPIController(ILogging logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDTo> GetVillas()
        {
            _logger.Log("Getting all villas","");
            return Ok(_applicationDbContext.Villas.ToList());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTo> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("Invalid villa ID", "error");
                return BadRequest();
            }
            var villa = _applicationDbContext.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<VillaDTo> CreateVilla([FromBody] VillaDTo villaDTovilla)
        {
            if (_applicationDbContext.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTovilla.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists!");
                return BadRequest(ModelState);
            }

            if (villaDTovilla == null)
            {
                return BadRequest(villaDTovilla);
            }
            if (villaDTovilla.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

         Models.Villa villa = new()
            {
                Name = villaDTovilla.Name,
                Occupancy = villaDTovilla.Occupancy,
                Sqft = villaDTovilla.Sqft,
                ImageUrl = villaDTovilla.ImageUrl,
                Amenity = villaDTovilla.Amenity,
                Details = villaDTovilla.Details,
                Rate = villaDTovilla.Rate,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            _applicationDbContext.Villas.Add(villa);
            _applicationDbContext.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villaDTovilla.Id }, villaDTovilla);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTo> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _applicationDbContext.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _applicationDbContext.Villas.Remove(villa);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTo> UpdateVilla(int id, [FromBody] VillaDTo villaDTovilla)
        {
            if (villaDTovilla == null || id != villaDTovilla.Id)
            {
                return BadRequest();
            }
           
            Models.Villa villa = new()
            {
                Name = villaDTovilla.Name,
                Occupancy = villaDTovilla.Occupancy,
                Sqft = villaDTovilla.Sqft,
                ImageUrl = villaDTovilla.ImageUrl,
                Amenity = villaDTovilla.Amenity,
                Details = villaDTovilla.Details,
                Rate = villaDTovilla.Rate,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            _applicationDbContext.Villas.Update(villa);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTo> UpdatePartialVilla(int id, JsonPatchDocument<VillaDTo> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _applicationDbContext.Villas.FirstOrDefault(v => v.Id == id);

            VillaDTo villaDTo = new()
            {
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Sqft = villa.Sqft,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity,
                Details = villa.Details,
                Rate = villa.Rate
            };  

            if (villa == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(villaDTo, ModelState);

            Models.Villa villaModel = new()
            {
                Name = villaDTo.Name,
                Occupancy = villaDTo.Occupancy,
                Sqft = villaDTo.Sqft,
                ImageUrl = villaDTo.ImageUrl,
                Amenity = villaDTo.Amenity,
                Details = villaDTo.Details,
                Rate = villaDTo.Rate
            };

            _applicationDbContext.Villas.Update(villaModel);
            _applicationDbContext.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}