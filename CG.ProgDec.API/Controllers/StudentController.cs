using CG.ProgDec.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BL.Models.Student> Get()
        {
            return StudentManager.Load();
        }

        [HttpGet("{id}")]
        public BL.Models.Student Get(int id)
        {
            return StudentManager.LoadById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BL.Models.Student student)
        {
            try
            {
                int results = StudentManager.Insert(student);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // This 
            }
        }

        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] BL.Models.Student student) 
        {
            try
            {
                int results = StudentManager.Update(student);
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
                int results = StudentManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
