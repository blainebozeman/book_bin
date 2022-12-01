using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using MySql.Data.MySqlClient;
using API.Models.Interfaces;
using System.Data;
using MySql.Data;
using System;
using API.Models;
namespace API.Models
{
    public class ReadVendorReports : IGetVendorReport
    {
        public List<VendorReport> GetVendorReports()
        {
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6; Convert Zero DateTime=True";


            //server=localhost;User Id=root;password=mautauaja;Persist Security Info=True;database=test;Convert Zero Datetime=True
            //string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6 ";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            //select COUNT(*) as NumberofBooksSold, VendororCustomerName from books group by VendororCustomername;
            string stm = "select * from VendorReports;";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<VendorReport> vendorReports = new List<VendorReport>();
            while(rdr.Read()){
    
                vendorReports.Add(new VendorReport()
                {
                NumberofBooksSold = rdr.GetInt32(0),
                VendororCustomerName = rdr.GetString(1)
                });
            }
                
                
               //System.Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1) +  " "  + rdr.GetString(2) + " " + rdr.GetInt32(3) + " " + rdr.GetString(4) + " " + rdr.GetString(5)+ " " + rdr.GetString(6) + "" + rdr.GetDouble(7) + "" + rdr.GetDateTime(8));
            con.Close();
            return vendorReports;
        }
    }
}