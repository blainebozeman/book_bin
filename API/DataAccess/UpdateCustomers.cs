using MySql.Data.MySqlClient;
using API.Models;
using API.Models.Interfaces;
namespace API.DataAccess
{
    public class UpdateCustomers
    {
        public List<Customer> UpdateCredit(Customer user)
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
                System.Console.WriteLine("made it to update credits");
                con.Open();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("It's not open");
            }
            //update Credits
            string stm = $"UPDATE `fdfpqo2wtkd2rwyf`.`customers` SET `CustCredits` = '{user.Credits}' WHERE (`cust_id` = '{user.CustID}');";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            customers.Add(user);
            con.Close();
            System.Console.WriteLine(customers[0].CustUserName + customers[0].CustPassword + customers[0].Credits);
            con.Close();
            return customers;
        }
    }
}