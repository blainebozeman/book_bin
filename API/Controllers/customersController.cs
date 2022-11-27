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
            // System.Console.WriteLine("HERE IN POST");
            // GetCustomers dataAccess = new GetCustomers();
            // return dataAccess.GetSelect(user); 
            System.Console.WriteLine("HERE IN POST");
            List<Customer> data;
            if (user.FName == "")
            {
                GetCustomers dataAccess = new GetCustomers();
                try
                {
                    data=dataAccess.GetSelect(user); 
                }
                catch
                {
                    System.Console.WriteLine("no user");
                    data = new List<Customer>{new Customer(){CustUserName = "nothing_here_34759842718928765432"}};
                }
                return data;
            }
            else if(user.Credits != 0)
            {
                UpdateCustomers dataAccess = new UpdateCustomers();
                try
                {
                    data=dataAccess.UpdateCredit(user); 
                }
                catch
                {
                    System.Console.WriteLine("no user");
                    data = new List<Customer>{new Customer(){CustUserName = "nothing_here_34759842718928765432"}};
                }
                return data;
            }
            else
            {
                System.Console.WriteLine("Adding New Customer");
                try
                {
                    AddCustomers dataAccess = new AddCustomers();
                    return dataAccess.PutCustomer(user);
                }
                catch
                {
                    System.Console.WriteLine("no user");
                    data = new List<Customer>{new Customer(){CustUserName = "nothing_here"}};
                    return data; 
                }
            }
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
