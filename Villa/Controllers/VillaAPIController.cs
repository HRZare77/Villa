using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa;
using Villa.Data;
using Villa.Models.Dto;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<VillaDTo> GetVillas()
        {
            return VillaStore.villaList;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTo> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        public ActionResult<VillaDTo> CreateVilla([FromBody] VillaDTo villaDTovilla)
        {
            if (VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower()==villaDTovilla.Name.ToLower())!=null)
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
            villaDTovilla.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDTovilla);
            return CreatedAtRoute("GetVilla", new { id = villaDTovilla.Id }, villaDTovilla);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<VillaDTo> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            return NoContent();
        }
    }
}
