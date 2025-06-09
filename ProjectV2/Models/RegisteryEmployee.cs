using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class RegisteryEmployee : Employee
    {

        public string NativeLanguage { get; set; }
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public RegisteryEmployee() { }
        public RegisteryEmployee(int employeeId, string name, string lastname, DateTime dateofbirth, string maidenName, Address address, List<string> previousjobs, string nativeLanguage, DateTime dateOfEmployment)
         : base(employeeId, name, lastname, dateofbirth, maidenName, address, previousjobs, dateOfEmployment)
        {

            NativeLanguage = nativeLanguage;
        }


        public RegisteryEmployee(int employeeId, string name, string lastname, DateTime dateofbirth, Address address, List<string> previousjobs, string nativeLanguage, DateTime dateOfEmployment)
          : base(employeeId, name, lastname, dateofbirth, address, previousjobs, dateOfEmployment)
        {
            NativeLanguage = nativeLanguage;
        }


        public List<RegisteryEmployee> getRegisteryEmployeesList(int institutionId)
        {
            List<RegisteryEmployee> registeryEmployees = new List<RegisteryEmployee>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT Employee.EmployeeId, Name, LastName, NativeLanguage FROM RegisteryEmployee, Employee WHERE RegisteryEmployee.EmployeeId = Employee.EmployeeId AND InstitutionId = " + institutionId;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    RegisteryEmployee registeryEmployee = new RegisteryEmployee();
                    registeryEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    registeryEmployee.Name = dr["Name"].ToString();
                    registeryEmployee.LastName = dr["LastName"].ToString();
                    registeryEmployee.NativeLanguage = dr["NativeLanguage"].ToString();

                    registeryEmployees.Add(registeryEmployee);
                }
            }
            con.Close();
            return registeryEmployees;
        }
        public void saveRegisteryEmployee(int employeeId, int rentalId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

            string sqlQuery = "INSERT INTO EmployeeRental (EmployeeId, RentalId) VALUES (" + employeeId + ", " + rentalId + ")";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}