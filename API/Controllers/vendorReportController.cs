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
    [Route("api/[controller]")]
    [ApiController]
    public class vendorReportController : ControllerBase
    {
        // GET: api/vendorReport
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<VendorReport> Get()
        {
            // System.Console.WriteLine("HERE");
            IGetVendorReport readVendorList = new ReadVendorReports();
            return readVendorList.GetVendorReports();
            // BookData dataAccess = new BookData();
            // return dataAccess.GetAll();
        }


        // GET: api/vendorReport/5
        [HttpGet("{id}", Name = "Getxxxxxxx")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/vendorReport
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/vendorReport/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/vendorReport/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
