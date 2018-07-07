using Microsoft.AspNetCore.Mvc;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Services;
using Utilities.Extension;

/// <summary>
/// Receives the EntryPoint Request, Ask the result for the Service and eturn the Response
/// </summary>
namespace RestWithAspNETUdemy.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        /// <summary>
        /// When instanciated, the Service will be automatically provided by the dependency injection
        /// </summary>
        /// <param name="service"></param>
        /// <see cref="Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
        public PersonsController(IPersonService service)
        {
            _personService = service;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindByAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person.IsNull())
                return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person.IsNull())
                return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            person = _personService.Update(person);
            if (person.IsNull())
                return NotFound();
            return new ObjectResult(person);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
