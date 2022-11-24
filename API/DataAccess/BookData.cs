// using MySql.Data.MySqlClient;
// using API.Models;
// namespace API.DataAccess
// {
//     public class BookData
//     {
//         public List<Books> GetAll()
//         {
//             List<Books> book = new List<Books>();
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
//                 Books newBook = new Books() { BookID = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2), ISBN = rdr.GetString(3), Condition = rdr.GetInt32(4), Deleted = rdr.GetBoolean(5)};
//                 books.Add(newBooks);
//             }
//             con.Close();
//             return books;
//         } 
        
//         } 

//     }