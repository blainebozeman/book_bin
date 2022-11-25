using MySql.Data.MySqlClient;
using API.Models.Interfaces;
using API.Models;

namespace API.Models
{
    public class EditBook : IEditBook
    {
        public void EditBooks(Books book){
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = $"update books set condition=@Condition where BookID= @BookID";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@condition", book.Condition);

            cmd.Parameters.AddWithValue("@BookID", book.BookID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}