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
<<<<<<< HEAD
        public List<Books> Getxx()
        {
           IGetAllBooks readObject = new ReadBooks();
           return readObject.GetAllBooks();
=======
        public List<Books> Get()
        {
            System.Console.WriteLine("HERE");
            BookData dataAccess = new BookData();
            return dataAccess.GetAll();
>>>>>>> refs/remotes/origin/main
        }


        // GET: api/books/5
        [HttpGet("{id}", Name = "Getx")]
<<<<<<< HEAD
        public string Get(int Id)
=======
        public string Get(int BookID)
>>>>>>> refs/remotes/origin/main
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
