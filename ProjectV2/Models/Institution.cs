using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public Address Address { get; set; }


        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Institution()
        {
        }
        public Institution(int institutionId, int openingHour, int closingHour)
        {
            InstitutionId = institutionId;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            Address = new Address(1, "Konwaliowa", 22);
        }

        public List<Institution> getInstitutionsList()
        {
            List<Institution> institutions = new List<Institution>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT InstitutionId FROM INSTITUTION";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Institution instutution = new Institution();
                    instutution.InstitutionId = Convert.ToInt32(dr["InstitutionId"]);


                    institutions.Add(instutution);
                }
            }
            con.Close();
            return institutions;
        }

    }
}
