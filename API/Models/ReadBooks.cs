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
    public class ReadBooks: IGetAllBooks, IGetBook
    {
      
        public List<Books> GetAllBooks()
        {
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6; Convert Zero DateTime=True";


            //server=localhost;User Id=root;password=mautauaja;Persist Security Info=True;database=test;Convert Zero Datetime=True
            //string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6 ";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from books where deleted = 0";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Books> allBooks = new List<Books>();
            while(rdr.Read()){
    
                allBooks.Add(new Books()
                {
                ISBN = rdr.GetInt32(0),
                Title = rdr.GetString(1), 
                Author = rdr.GetString(2), 
                Condition = rdr.GetString(3),
                Genre = rdr.GetString(4),
                BookID = rdr.GetInt32(5),
                Deleted = rdr.GetInt32(6),
                Price = rdr.GetDouble(7), 
                DateAdded = rdr.GetDateTime(8)
                });
            }
                
                
               //System.Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1) +  " "  + rdr.GetString(2) + " " + rdr.GetInt32(3) + " " + rdr.GetString(4) + " " + rdr.GetString(5)+ " " + rdr.GetString(6) + "" + rdr.GetDouble(7) + "" + rdr.GetDateTime(8));
    
            return allBooks;
        }

        public Books GetBook(int BookID)
        {
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6; Convert Zero DateTime=True";
           // string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from books where BookID= @BookID";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@BookID", BookID);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Books(){
                ISBN = rdr.GetInt32(0),
                Title = rdr.GetString(1), 
                Author = rdr.GetString(2), 
                Condition = rdr.GetString(3),
                Genre = rdr.GetString(4),
                BookID = rdr.GetInt32(5),
                Deleted = rdr.GetInt32(6),
                Price = rdr.GetDouble(7), 
                DateAdded = rdr.GetDateTime(8)
            };
        }
    }
}