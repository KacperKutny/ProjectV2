using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public interface ISportsCar
    {
        public int VMax { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal AdditionalFee { get; set; }
    }
}

