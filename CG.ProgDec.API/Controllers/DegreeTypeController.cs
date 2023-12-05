using CG.ProgDec.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeTypeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BL.Models.DegreeType> Get()
        {
            return DegreeTypeManager.Load();
        }

        [HttpGet("{id}")]
        public BL.Models.DegreeType Get(int id)
        {
            return DegreeTypeManager.LoadById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BL.Models.DegreeType degreeType)
        {
            try
            {
                int results = DegreeTypeManager.Insert(degreeType);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // This 
            }
        }

        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] BL.Models.DegreeType degreeType) 
        {
            try
            {
                int results = DegreeTypeManager.Update(degreeType);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                int results = DegreeTypeManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
