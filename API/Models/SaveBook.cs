using MySql.Data.MySqlClient;
using API.Models.Interfaces;

using Microsoft.AspNetCore.Cors;
namespace API.Models

{
    public class SaveBook : IAddBook
    {
        public void AddBook(Books book){
            string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = $"insert into books(BookID, Title, Author, ISBN, Genre, BookCondition, Price, DateAdded) VALUES (@BookID, @Title, @Author, @ISBN, @Genre, @Condition, @Price, @DateAdded);";
            MySqlCommand cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@BookID", book.BookID);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@Condition", book.Condition);
            cmd.Parameters.AddWithValue("@Genre" , book.Genre);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@DateAdded", book.DateAdded);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

    
        }
    }
}
