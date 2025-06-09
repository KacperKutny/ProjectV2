using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Mechanic : Employee
    {

        public string Specialization { get; set; }
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Mechanic() { }

        public Mechanic(int employeeId, string name, string lastname, DateTime dateofbirth, string maidenName, Address address, List<string> previousjobs, string specialization, DateTime dateOfEmployment)
            : base(employeeId, name, lastname, dateofbirth, maidenName, address, previousjobs, dateOfEmployment)
        {

            Specialization = specialization;
        }

        public Mechanic(int employeeId, string name, string lastname, DateTime dateofbirth, Address address, List<string> previousjobs, string specialization, DateTime dateOfEmployment)
          : base(employeeId, name, lastname, dateofbirth, address, previousjobs, dateOfEmployment)
        {

            Specialization = specialization;
        }

        public override string ToString()
        {

            return "ID Pracownika: " + EmployeeId + "\n Name: " + Name + "\n Last Name: " + LastName + "\n Date Of Employment " + DateOfEmployment +
                "\n Seniority: " + Seniority;

        }

        public List<Mechanic> getMechanicsList(int institutionId)
        {
            List<Mechanic> mechanics = new List<Mechanic>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT Mechanic.EmployeeId, Name, LastName, Specialization FROM Mechanic, Employee WHERE Mechanic.EmployeeId = Employee.EmployeeId AND InstitutionId = " + institutionId;
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Mechanic mechanic = new Mechanic();
                    mechanic.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    mechanic.Name = dr["Name"].ToString();
                    mechanic.LastName = dr["LastName"].ToString();
                    mechanic.Specialization = dr["Specialization"].ToString();

                    mechanics.Add(mechanic);
                }
            }
            con.Close();
            return mechanics;
        }


        public void saveMechanic(int employeeId, int rentalId)
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

