using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class SportsCar : Car, ISportsCar
    {
        public int VMax { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal AdditionalFee { get; set; }

        public SportsCar(int carId, string engineType, string model, DateTime dateOfProduction, int vMax, decimal additionalFee)
            : base(carId, engineType, model, dateOfProduction)
        {
            VMax = vMax;
            AdditionalFee = additionalFee;
        }
    }
}
