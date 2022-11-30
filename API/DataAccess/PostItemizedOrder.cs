using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;
namespace API.DataAccess
{
    public class PostItemizedOrder
    {
        public void PostItemized(OrderItemized order)
        {
            //test
            System.Console.WriteLine(order.ItemizedOrderID);

            //variables
            //List<Customer> customers = new List<Customer>();
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            MySqlConnection con = new MySqlConnection(cs);

            //Is it open?
            try
            {
                System.Console.WriteLine("made it here");
                con.Open();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("It's not open");
            }
            DateTime now = DateTime.Now;
            string stm = $"INSERT INTO `fdfpqo2wtkd2rwyf`.`itemizedorder` (`OrderID`, `BookID`) VALUES ('{order.OrderID}', '{order.BookID}');";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}