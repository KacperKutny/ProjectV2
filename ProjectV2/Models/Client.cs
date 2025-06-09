using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        public string ClientLastName { get; set; }
        public Address ClientAddress { get; set; }

        public ICollection<ClientRental> ClientRentals { get; set; } = null!;


        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        public Client() { }

        public Client(int clientID, string clientName, string clientLastName, Address clientAddress)
        {
            ClientID = clientID;
            ClientName = clientName;
            ClientLastName = clientLastName;
            ClientAddress = clientAddress;

        }

        public List<Client> getClientsList()
        {
            List<Client> clients = new List<Client>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT ClientId, ClientName, ClientLastName From Client";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr != null )
            {
                while(dr.Read())
                {
                    Client client = new Client();
                    client.ClientID = Convert.ToInt32(dr["ClientId"]);
                    client.ClientName = dr["ClientName"].ToString();
                    client.ClientLastName = dr["ClientLastName"].ToString();

                    clients.Add(client);
                }
            }
            con.Close();
            return clients;
        }

        public void saveClient(string dateofRental, int clientId, int rentalId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

            string sqlQuery = "INSERT INTO ClientRental (DateOfRental, ClientId, RentalId) VALUES ('" + dateofRental +"', " + clientId + ", " + rentalId + ")";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}