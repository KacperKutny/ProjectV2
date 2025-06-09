using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class CarState
    {
        public int CarStateId { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

        public CarState() { }
        

        

        public CarState(Car car, State state)
        {
            Car = car;
            State = state;
        }
    }
}
