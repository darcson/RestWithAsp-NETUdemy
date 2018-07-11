using Microsoft.AspNetCore.Mvc;
using RestWithAspNETUdemy.Business;
using RestWithAspNETUdemy.Data.VO;
using RestWithAspNETUdemy.Extensions;
using RestWithAspNETUdemy.Model;

namespace RestWithAspNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private IBookBusiness _bookBusiness;

        /// <summary>
        /// When instanciated, the Business will be automatically provided by the dependency injection
        /// </summary>
        /// <param name="business"></param>
        /// <see cref="Startup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
        public BooksController(IBookBusiness business)
        {
            _bookBusiness = business;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book.IsNull())
                return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book.IsNull())
                return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/values/5
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null)
                return BadRequest();

            book = _bookBusiness.Update(book);
            if (book.IsNull())
                return NotFound();
            return new ObjectResult(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
