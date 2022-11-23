using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.DataAccess;
namespace book_bin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/customers/5
        [HttpGet("{id}", Name = "Getxx")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/customers
        [HttpPost]
        public List<Customer> Post([FromBody] Customer user)
        {
            System.Console.WriteLine("HERE IN POST");
            GetCustomers dataAccess = new GetCustomers();
            return dataAccess.GetSelect(user); 
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
