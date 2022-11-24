using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using API.DataAccess;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [HttpGet]
        public List<Books> Getxx()
        {
           IGetAllBooks readObject = new ReadBooks();
           return readObject.GetAllBooks();
        }

        // GET: api/books/5
        [HttpGet("{id}", Name = "Getx")]
        public string Get(int Id)
        {
            IGetBook readObject = new ReadBooks();
            return readObject.GetBook(Id);
        }

        // POST: api/books
        [HttpPost("upload", Name = "uploadx")]
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
