using Microsoft.AspNetCore.Mvc;
using RestWithAspNETUdemy.Business;
using RestWithAspNETUdemy.Model;
using RestWithAspNETUdemy.Repository;
using Utilities.Extension;

/// <summary>
/// Receives the EntryPoint Request, Ask the result for the Business and eturn the Response
/// </summary>
namespace RestWithAspNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        /// <summary>
        /// When instanciated, the Business will be automatically provided by the dependency injection
        /// </summary>
        /// <param name="business"></param>
        /// <see cref="Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
        public PersonsController(IPersonBusiness business)
        {
            _personBusiness = business;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
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
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            person = _personBusiness.Update(person);
            if (person.IsNull())
                return NotFound();
            return new ObjectResult(person);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
