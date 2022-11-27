// using System.Security.AccessControl;
// using System.Threading;
// using System.Xml.Linq;
// using System.ComponentModel.Design.Serialization;
// using System.Security.Cryptography;
// using MySql.Data.MySqlClient;
// using API.Models;
// using API;
// namespace API.DataAccess
// {
//     public class BookData
//     {
//         public List<Books> GetAll()
//         {
//             List<Books> books = new List<Books>();
//             ConnectionString connectionString = new ConnectionString();
//             string cs = connectionString.cs;
//             MySqlConnection con = new MySqlConnection(cs);
//             //Is it open?
//             try
//             {
//                 con.Open();
//             }
//             catch (System.Exception)
//             {
//                 System.Console.WriteLine("It's not open");
//             }

//             string stm = "SELECT * from books order by genre";
//             MySqlCommand cmd = new MySqlCommand(stm, con);
//             MySqlDataReader rdr = cmd.ExecuteReader();

//             while (rdr.Read())
//             {
//                 Books newBook = new Books() { 
//                     ISBN= rdr.GetInt32(0),
//                     Title = rdr.GetString(1), 
//                     Author = rdr.GetString(2),
//                     Condition = rdr.GetString(3),
//                     Genre = rdr.GetString(4),
//                     BookID = rdr.GetInt32(5),
//                     Deleted = rdr.GetInt32(6), 
//                     Price = rdr.GetDouble(7),
//                     DateAdded = rdr.GetDateTime(8)};
//                     books.Add(newBook);
//             }
//             con.Close();
//             return books;
//         } 
        
//         } 

//     }