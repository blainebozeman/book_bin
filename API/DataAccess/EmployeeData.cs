using MySql.Data.MySqlClient;
using API;
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

            string stm = "SELECT * from employees order by Emp_id";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1)+ " " + rdr.GetBoolean(4));
                Employees newEmployees = new Employees() { EmpUserName = rdr.GetString(0), EmpPassword = rdr.GetString(1), Emp_ID = rdr.GetInt32(2), Admin = rdr.GetBoolean(3), FName = rdr.GetString(4), LName = rdr.GetString(5)};
                    employees.Add(newEmployees);
            }
            con.Close();
            return employees;
        } 
        public List<Employees> GetSelect(Employees search)
        {
            List<Employees> employees = new List<Employees>();
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

            string stm = $"SELECT * from drivers WHERE EmpUserName LIKE '{search.EmpUserName} and EmpPassword LIKE '{search.EmpPassword}';";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " " + rdr.GetString(1)+ " " + rdr.GetBoolean(4));
                Employees newEmployees = new Employees() { EmpUserName = rdr.GetString(0), EmpPassword = rdr.GetString(1), Emp_ID = rdr.GetInt32(2), Admin = rdr.GetBoolean(3), FName = rdr.GetString(4), LName = rdr.GetString(5)};
                    employees.Add(newEmployees);
            }
            con.Close();
            return employees;
        } 
    }
}