using MySql.Data.MySqlClient;
using API.Models.Interfaces;
using API.Models;

namespace API.Models
{
    public class DeleteBook : IDeleteBook
    {
        public void RemoveBook(int BookID){
            System.Console.WriteLine("made it to delete books");
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = $"update books set deleted = 1 where BookID = @BookID;";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            // cmd.Parameters.AddWithValue("@id", driver.Id);
            cmd.Parameters.AddWithValue("@BookID", BookID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}