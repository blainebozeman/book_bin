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
        public List<Books> Get()
        {
            System.Console.WriteLine("HERE");
            BookData dataAccess = new BookData();
            return dataAccess.GetAll();
        }


        // GET: api/books/5
        [HttpGet("{id}", Name = "Getx")]
        public string Get(int BookID)
        {
            return "value";
        }

        // POST: api/books
        [HttpPost("upload", Name = "uploadx")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public void Put(int BookID, [FromBody] string value)
        {
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public void Delete(int BookID)
        {
        }
    }
}
