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
    public class itemizedorderController : ControllerBase
    {
        // GET: api/itemizedorder
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/itemizedorder/5
        [HttpGet("{id}", Name = "Getxxxxx")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/itemizedorder
        [HttpPost]
        public void Post([FromBody] OrderItemized value)
        {
            PostItemizedOrder dataAccess = new PostItemizedOrder();
            //Order data;
            // try
            // {
                dataAccess.PostItemized(value);
                //System.Console.WriteLine($"Placed order #" + data.OrderID);
                //return data; 
            // }
            // catch
            // {
            //     System.Console.WriteLine("Place Order Failed");
            //     //data = new Order{OrderID = -123456789};
            //     //return data;
            // }
        }

        // PUT: api/itemizedorder/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/itemizedorder/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
