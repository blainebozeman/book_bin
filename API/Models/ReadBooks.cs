using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace API.Models
{
    public class ReadBooks: IGetAllBooks, IGetBook
    {
      
        public List<Books> GetAllDrivers()
        {
            string cs = "server=http://h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from books where deleted = 0";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Books> books = new List<Books>();
            while(rdr.Read()){
                System.Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1) + " "  + rdr.GetInt32(2) + " " + rdr.GetDateTime(3) + " " + rdr.GetBoolean(4));
                Books newBook = new Books(){BookId = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetInt32(2), ISBN = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};
                drivers.Add(newDriver);


                //public Guid BookID{get;set;}
        public string Title{get;set;}
        public string Author{get;set;}
        public string ISBN{get;set;}
        public string Condition {get; set;}
            }

            con.Close();
            return drivers;
        }

        public Drivers GetDriver(int Id)
        {
            string cs = "server=t07cxyau6qg7o5nz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=k5j9nxg826jfmhp3;database=vajiy0c387qvu0oa;port=3306;password=ui8elf3aj8wkfy2j";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from drivers";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Drivers(){Id = rdr.GetInt32(0), Name = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};




        }

    }
}