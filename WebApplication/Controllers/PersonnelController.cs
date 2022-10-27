using Microsoft.AspNetCore.Mvc;
using WebApplication.data;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {

        private IPersonnelRepository repository;

        public PersonnelController()
        {
            this.repository = new PersonnelRepository();
        }

        // GET: api/<MainController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/<MainController>/5
        [HttpGet("salaries/{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id Personnel parameter is required");
            }


            return Ok(repository.GetSalariesById(id));
        }

        // POST api/<MainController>
        [HttpPost]
        public IActionResult Post([FromBody] Personnel personnel)
        {

            if (personnel == null)
            {
                return BadRequest("Parameter Personnel is required");
            }

            bool result = repository.Create(personnel);
            return Ok(result);

        }

        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
