using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class EmployeeRental
    {
        public int EmployeeRentalId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public int RentalId { get; set; }
        public Rental Rental { get; set; } = null!;
    }
}
