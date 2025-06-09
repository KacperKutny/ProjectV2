using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class ElectricSportsCar : ElectricCar, ISportsCar
    {

        public int Power { get; set; }
        public int VMax { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal AdditionalFee { get; set; }
     
        public ElectricSportsCar() { }

        public ElectricSportsCar(int carId, string engineType, string model, DateTime dateOfProduction, int range, int power, int vMax, decimal additionalFee)
            : base(carId, engineType, model, dateOfProduction, range)
        {
            Power = power;
            VMax = vMax;
            AdditionalFee = additionalFee;
        }

        public override string ToString()
        {
            return "Car ID: " + CarId + " \n Engine type: " + EngineType + " \n Model: " + Model + " \n Power: " + Power;
        }
    }
}