using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;
namespace API.DataAccess
{
    public class PostOrders
    {
        public Order PutCustomer(Order order)
        {
            //test
            System.Console.WriteLine(order.EmpId);

            //variables
            //List<Customer> customers = new List<Customer>();
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            MySqlConnection con = new MySqlConnection(cs);

            //Is it open?
            try
            {
                System.Console.WriteLine("made it to post books");
                con.Open();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("It's not open");
            }
            DateTime now = DateTime.Now;
            System.Console.WriteLine(now);
            string time = $"{now.Year}-{now.Month}-{now.Day} {now.Hour}:{now.Minute}:{now.Second}";
            string stm = $"INSERT INTO `fdfpqo2wtkd2rwyf`.`custorder` (`TotalAmount`, `OrdDateTime`, `Cust_id`, `Emp_id`) VALUES ('{order.TotalAmount}', '{time}', '{order.Cust_id}', '{order.EmpId}');";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();

            //Get Order Just Placed
            Order thisOrder = new Order();
            List<Order> temp = new List<Order>();

            //stm = $"SELECT * from custorder WHERE TotalAmount LIKE '{order.TotalAmount}' and OrdDateTime LIKE '{time}' and Cust_id LIKE '{order.Cust_id}' and Emp_id LIKE '{order.EmpId}';";
            stm = $"SELECT * from custorder WHERE TotalAmount LIKE '{order.TotalAmount}' and Cust_id LIKE '{order.Cust_id}' and Emp_id LIKE '{order.EmpId}';";
            MySqlCommand cmd2 = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd2.ExecuteReader();

            while (rdr.Read())
            {
                thisOrder = new Order() { TotalAmount = rdr.GetInt32(0), OrdDateTime = rdr.GetDateTime(1), OrderID = rdr.GetInt32(2), Cust_id = rdr.GetInt32(3), EmpId = rdr.GetInt32(4)};
                // temp.Add(newCustomer);
            }
            System.Console.WriteLine(thisOrder.OrderID);
            con.Close();
            return thisOrder;
        }
    }
}