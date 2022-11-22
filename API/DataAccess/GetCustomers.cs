using MySql.Data.MySqlClient;
using API.Models;
namespace API.DataAccess
{
    public class GetCustomers
    {
        public List<Customer> GetSelect(Customer user)
        {
            System.Console.WriteLine(user.CustUserName);
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
                System.Console.WriteLine("It's open");
            }

            string stm = $"SELECT * from drivers WHERE CustUserName LIKE '{user.CustUserName} and CustPassword LIKE '{user.CustPassword}';";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Customer newCustomer = new Customer() { CustID = rdr.GetGuid(0), FName = rdr.GetString(1), LName = rdr.GetString(2), Credits = rdr.GetInt32(3), CustUserName = rdr.GetString(4), Emp_ID = rdr.GetInt32(5)};
                customers.Add(newCustomer);
            }
            con.Close();
            return customers;
        } 
    }
}