using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class TruckCar : Car
    {
        public int Capacity { get; set; }

        public TruckCar(int carId, string engineType, string model, DateTime dateOfProduction, int capacity)
            : base(carId, engineType, model, dateOfProduction)
        {
            Capacity = capacity;

        }


    }
}

