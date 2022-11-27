using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;
namespace API.DataAccess
{
    public class AddCustomers : IAddCustomer
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
            string stm = $"INSERT INTO `fdfpqo2wtkd2rwyf`.`customers` (`CustFName`, `CustLName`, `CustCredits`, `UserName`, `Emp_id`, `CustPassword`) VALUES ('{user.FName}', '{user.LName}', '0', '{user.CustUserName}', '{user.CustID}', '{user.CustPassword}');";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            customers.Add(user);
            con.Close();
            System.Console.WriteLine(customers[0].CustUserName + customers[0].CustPassword);
            con.Close();
            return customers;
        }
    }
}