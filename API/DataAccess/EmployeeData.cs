using MySql.Data.MySqlClient;
using API.Models;
namespace API.DataAccess
{
    public class EmployeeData
    {
        public List<Employees> GetAll()
        {
            List<Employees> employees = new List<Employees>();
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            MySqlConnection con = new MySqlConnection(cs);
            //Is it open?
            try
            {
                con.Open();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("It's open");
            }

            string stm = "SELECT * from drivers order by DateHired desc";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1)+ " " + rdr.GetBoolean(4));
                Drivers newDrivers = new Drivers() { DriverID = rdr.GetInt32(0), FullName = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};
                if (newDrivers.Deleted == false)
                {
                    drivers.Add(newDrivers);
                }
            }
            con.Close();
            return drivers;
        } 
    }
}


namespace api.DataAccess
{
    public class DriverData
    {
        public List<Drivers> GetAll()
        {
            List<Drivers> drivers = new List<Drivers>();
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            MySqlConnection con = new MySqlConnection(cs);
            //Is it open?
            try
            {
                con.Open();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("It's open");
            }

            string stm = "SELECT * from drivers order by DateHired desc";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1)+ " " + rdr.GetBoolean(4));
                Drivers newDrivers = new Drivers() { DriverID = rdr.GetInt32(0), FullName = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetBoolean(4)};
                if (newDrivers.Deleted == false)
                {
                    drivers.Add(newDrivers);
                }
            }
            con.Close();
            return drivers;
        }
    }
}