using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public Address()
        {

        }
        public Address(int addressId, string street, int streetNumber)
        {
            AddressId = addressId;
            Street = street;
            StreetNumber = streetNumber;
        }
    }
}
