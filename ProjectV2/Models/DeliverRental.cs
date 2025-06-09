using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class DeliveryRental : Rental
    {

        public Address Address { get; set; }

        public DeliveryRental(int rentalId, string dateOfRental, decimal pricePerDay, string cardNumber, Address address) : base(rentalId, dateOfRental, pricePerDay, cardNumber)
        {
            Address = address;
        }

        public DeliveryRental(int rentalId, string dateOfRental, decimal pricePerDay, char currencySymbol, Address address) : base(rentalId, dateOfRental, pricePerDay, currencySymbol)
        {
            Address = address;
        }


    }
}
