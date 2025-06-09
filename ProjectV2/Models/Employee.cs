using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? MaidenName { get; set; }
        public Address Address { get; set; } = null!;
        public DateTime DateOfEmployment { get; set; }

        public List<string> previousJobs = new List<string>();
        public int Seniority { get; set; }

        public Institution? Institution { get; set; } = null!;

        public ICollection<EmployeeRental> EmployeeRentals { get; set; } = null!;

        public Rental? Rental { get; set; }

        public Employee() { }

        public Employee(int employeeId, string name, string lastname, DateTime dateofbirth, string maidenName, Address address, List<string> previousjobs, DateTime dateOfEmployment)
        {
            EmployeeId = employeeId;
            Name = name;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            MaidenName = maidenName;
            Address = address;
            previousJobs = previousjobs;
            DateOfEmployment = dateOfEmployment;
            Seniority = countSeniority();

        }

        public Employee(int employeeId, string name, string lastname, DateTime dateofbirth, Address address, List<string> previousjobs, DateTime dateOfEmployment)
        {
            EmployeeId = employeeId;
            Name = name;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Address = address;
            previousJobs = previousjobs;
            DateOfEmployment = dateOfEmployment;
            Seniority = this.countSeniority();
        }

        public void setRental(Rental rental)
        {
            if (this.Rental != null)
            {
                return;
            }

            this.Rental = rental;
            rental.addEmployee(this);
        }

        public void getPreviousJobs()
        {
            foreach (string job in previousJobs)
            {
                Console.WriteLine(job);
            }
        }

        public int countSeniority()
        {
            return DateTime.Now.Year - this.DateOfEmployment.Year;
        }
    }
}
