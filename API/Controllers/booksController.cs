using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_bin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/books/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(Guid BookID)
        {
            return "value";
        }

        // POST: api/books
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public void Put(Guid BookID, [FromBody] string value)
        {
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public void Delete(Guid BookID)
        {
        }
    }
}
