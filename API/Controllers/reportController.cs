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
    public class reportController : ControllerBase
    {
        // GET: api/report
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/report/5
        [HttpGet("{id}", Name = "Getxxx")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/report
        [HttpPost]
        public Order Post([FromBody] Order value)
        {
                        // System.Console.WriteLine("HERE IN POST");
            PostOrders dataAccess = new PostOrders();
            Order data;
            try
            {
                data=dataAccess.PutCustomer(value);
                System.Console.WriteLine($"Placed order #" + data.OrderID);
                return data; 
            }
            catch
            {
                System.Console.WriteLine("Place Order Failed");
                data = new Order{OrderID = -123456789};
                return data;
            }
        }

        // PUT: api/report/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/report/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
