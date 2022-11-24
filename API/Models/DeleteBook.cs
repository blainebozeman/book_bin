// using MySql.Data.MySqlClient;
// using api.Models.Interfaces;
// using api.Models;

// using Microsoft.AspNetCore.Cors;
// namespace API.Models;
// {
//     public class DeleteBook : IDeleteBook
//     {
//         string cs = "server= h1use0ulyws4lqr1.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=hllptjk6934naxti;database=fdfpqo2wtkd2rwyf;port=3306;password=g9sovn4chedx08w6";
//         MySqlConnection con = new MySqlConnection(cs);
//         con.Open();

//         string stm = $"update books set deleted = 1 where BookID = @BookID;";
//          MySqlCommand cmd = new MySqlCommand(stm, con);
//             // cmd.Parameters.AddWithValue("@id", driver.Id);
//             cmd.Parameters.AddWithValue("@BookID", BookID);
//             cmd.Prepare();
//             cmd.ExecuteNonQuery();
        
//     }
// }