using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class ElectricCar : Car
    {
        public int Range { get; set; }


        public ElectricCar ()
        {

        }
        public ElectricCar(int carId, string engineType, string model, DateTime dateOfProduction, int range)
            : base(carId, engineType, model, dateOfProduction)
        {
            Range = range;
        }
    }
}