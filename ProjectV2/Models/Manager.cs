using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Manager : Employee
    {

        public DateTime DateOfPromotion { get; set; }

     public Manager() { }
        public Manager(int employeeId, string name, string lastname, DateTime dateofbirth, string maidenName, Address address, List<string> previousjobs, DateTime dateOfPromotion, DateTime dateOfEmployment)
         : base(employeeId, name, lastname, dateofbirth, maidenName, address, previousjobs, dateOfEmployment)
        {

            DateOfPromotion = dateOfPromotion;
        }

        public Manager(int employeeId, string name, string lastname, DateTime dateofbirth, Address address, List<string> previousjobs, DateTime dateOfPromotion, DateTime dateOfEmployment)
          : base(employeeId, name, lastname, dateofbirth, address, previousjobs, dateOfEmployment)
        {

            DateOfPromotion = dateOfPromotion;
        }

    }

}