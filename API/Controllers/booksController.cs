using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.DataAccess;
using API.Models;
using API.Models.Interfaces;

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
            IGetAllBooks readObject = new ReadBooks();
            return readObject.GetAllBooks();
            // BookData dataAccess = new BookData();
            // return dataAccess.GetAll();
        }


        // GET: api/books/5
        [HttpGet("{bookID}", Name = "Get")]
        public Books Get(int BookID)
        {
            System.Console.WriteLine(BookID);
            IGetBook readObject = new ReadBooks();
            return readObject.GetBook(BookID);
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
