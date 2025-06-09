using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class DeliveryEmployee : Employee
    {

        public string DrivingLicenceCategory { get; set; }
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public DeliveryEmployee() { }
        public DeliveryEmployee(int employeeId, string name, string lastname, DateTime dateofbirth, string maidenName, Address address, List<string> previousjobs, string drivingLicenceCategory, DateTime dateOfEmployment)
         : base(employeeId, name, lastname, dateofbirth, maidenName, address, previousjobs, dateOfEmployment)
        {

            DrivingLicenceCategory = drivingLicenceCategory;
        }

        public DeliveryEmployee(int employeeId, string name, string lastname, DateTime dateofbirth, Address address, List<string> previousjobs, string drivingLicenceCategory, DateTime dateOfEmployment)
          : base(employeeId, name, lastname, dateofbirth, address, previousjobs, dateOfEmployment)
        {

            DrivingLicenceCategory = drivingLicenceCategory;
        }


        public List<DeliveryEmployee> getDeliveryEmployeesList(int institutionId)
        {
            List<DeliveryEmployee> deliveryEmployees = new List<DeliveryEmployee>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT Employee.EmployeeId, Name, LastName, DrivingLicenceCategory FROM DeliveryEmployee, Employee WHERE DeliveryEmployee.EmployeeId = Employee.EmployeeId AND InstitutionId = " + institutionId;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    DeliveryEmployee deliveryEmployee = new DeliveryEmployee();
                    deliveryEmployee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    deliveryEmployee.Name = dr["Name"].ToString();
                    deliveryEmployee.LastName = dr["LastName"].ToString();
                    deliveryEmployee.DrivingLicenceCategory = dr["DrivingLicenceCategory"].ToString();

                    deliveryEmployees.Add(deliveryEmployee);
                }
            }
            con.Close();
            return deliveryEmployees;
        }

        public void saveDeliveryEmployee(int employeeId, int rentalId)
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
