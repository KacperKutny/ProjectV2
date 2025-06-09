using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class PickUpRental : Rental
    {

        public DateTime DateOfPickup { get; set; }

        public PickUpRental(int rentalId, string dateOfRental, decimal pricePerDay, string cardNumber, DateTime dateOfPickup) : base(rentalId, dateOfRental, pricePerDay, cardNumber)
        {
            DateOfPickup = dateOfPickup;
        }

        public PickUpRental(int rentalId, string dateOfRental, decimal pricePerDay, char currencySymbol, DateTime dateOfPickup) : base(rentalId, dateOfRental, pricePerDay, currencySymbol)
        {
            DateOfPickup = dateOfPickup;
        }
    }
}