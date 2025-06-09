using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class ClientRental
    {
        public int ClientRentalId { get; set; }
        public string DateOfRental { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }


        public ClientRental() { }
        public ClientRental(int clientRentalId, Client client, Rental rental, string dateOfRental)
        {
            ClientRentalId = clientRentalId;
            Client = client;
            Rental = rental;
            DateOfRental = dateOfRental;
        }
    }
}
