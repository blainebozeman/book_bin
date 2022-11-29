using System;
namespace API.Models
{
    public class VendorReport
    {
        public int NumberofBooksSold{get; set;}

        public string VendororCustomerName{get; set;}

        public override string ToString()
        {
            return "NumberofBooksSold: " + this.NumberofBooksSold + "VendororCustomerName: " + this.VendororCustomerName;
        }



    }
}