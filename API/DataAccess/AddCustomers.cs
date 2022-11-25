using MySql.Data.MySqlClient;
using API.Models;
namespace API.DataAccess
{
    public class AddCustomers
    {
        public List<Customer> PutCustomer(Customer user)
        {
            //test
            System.Console.WriteLine(user.CustUserName);

            //variables
            List<Customer> customers = new List<Customer>();
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

            //command 
            // string stm = $"SELECT * from customers WHERE UserName LIKE '{user.CustUserName}' and CustPassword LIKE '{user.CustPassword}';";
            // MySqlCommand cmd = new MySqlCommand(stm, con);
            // MySqlDataReader rdr = cmd.ExecuteReader();
            // try
            // {
            string stm = $"INSERT INTO `fdfpqo2wtkd2rwyf`.`customers` (`CustFName`, `CustLName`, `CustCredits`, `UserName`, `Emp_id`, `CustPassword`) VALUES ('{user.FName}', '{user.LName}', '0', '{user.CustUserName}', '1', '{user.CustPassword}');";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            customers.Add(user);
            con.Close();
            // }
            // catch
            // {
            //     System.Console.WriteLine("customer already exist");
                System.Console.WriteLine(customers[0].CustUserName + customers[0].CustPassword);
                con.Close();
            // }
            return customers;
        }
    }
}