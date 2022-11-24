using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using MySql.Data.MySqlClient;
using API.Models.Interfaces;
using System;
using API.Models;

namespace API.Models
{
    public class ReadBooks: IGetAllBooks, IGetBook
    {
      
        public List<Books> GetAllBooks()
        {
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from books where deleted = 0";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Books> books = new List<Books>();
            while(rdr.Read()){
                System.Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1) +  " "  + rdr.GetInt32(2) + " " + rdr.GetString(3) + " " + rdr.GetString(4) + " " + rdr.GetDateTime(5)+ " " + rdr.GetBoolean(6));
                Books newBook = new Books(){BookID = rdr.GetInt32(0), Title = rdr.GetString(1), Condition = rdr.GetInt32(2), Author = rdr.GetString(3), ISBN = rdr.GetString(4) , DateAdded = rdr.GetDateTime(5), Deleted = rdr.GetBoolean(6)};
                books.Add(newBook);

                //public Guid BookID{get;set;}
            }

            con.Close();
            return books;
        }

        public Books GetBook(int BookID)
        {
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * from books";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", BookID);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Books(){BookID = rdr.GetInt32(0), Title = rdr.GetString(1), Condition = rdr.GetInt32(2), Author = rdr.GetString(3), ISBN = rdr.GetString(4) , DateAdded = rdr.GetDateTime(5), Deleted = rdr.GetBoolean(6)};
        }
    }
}