using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.DataAccess;
using API.Models;
using API.Models.Interfaces;

namespace book_bin.Controllers
{
    [EnableCors("OpenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Books> Get()
        {
            // System.Console.WriteLine("HERE");
            IGetAllBooks readObject = new ReadBooks();
            return readObject.GetAllBooks();
            // BookData dataAccess = new BookData();
            // return dataAccess.GetAll();
        }


        // GET: api/books/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{bookID}", Name = "Get")]
        public Books Get(int BookID)
        {
            System.Console.WriteLine("Here in Get Books"+BookID);
            //IGetBook readObject = new ReadBooks();
            //return readObject.GetBook(BookID);
            Books data;
            IGetBook readObject = new ReadBooks();
            try
            {
                data=readObject.GetBook(BookID); 
            }
            catch
            {
                System.Console.WriteLine("That book was not found");
                data = new Books(){Title = "nothing_here_34759842718928765432"};
            }
            return data;
        }

        // POST: api/books
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Books book)
        {
            IAddBook addObject = new SaveBook();
            addObject.AddBook(book);
        }

        // PUT: api/books/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int BookID, string Condition, [FromBody] Books book)
        {
            IEditBook editObject = new EditBook();
            editObject.EditBooks(book);
        }

        // DELETE: api/books/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{BookID}")]
        public void Delete(int BookID)
        {
            IDeleteBook deleteObject = new DeleteBook();
            deleteObject.RemoveBook(BookID);
        }
    }
}
