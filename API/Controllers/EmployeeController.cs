using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;
using API.DataAccess;

namespace book_bin.Controllers
{
    [EnableCors("OpenPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Employees> Get()
        {
            System.Console.WriteLine("HERE");
            EmployeeData dataAccess = new EmployeeData();
            return dataAccess.GetAll();
        }

        // GET: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{username}", Name = "GetUserName")]
        public string Get(int userName)
        {
            System.Console.WriteLine("here"+userName);
            return "value";
        }

        //POST: api/Employee
        [HttpPost]
        public List<Employees> Post([FromBody] Employees user)
        {
            System.Console.WriteLine("HERE IN POST");
            EmployeeData dataAccess = new EmployeeData();
            return dataAccess.GetSelect(user); 
        }

        // PUT: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Employee/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
