using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Producent
    {
        public int ProducentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public List<Car> carsList = new List<Car>();
        public ICollection<Car> Cars { get; set; } = null!;

        public Producent() { }
        public Producent(string name, string address, string email)
        {
            Name = name;
            Address = address;
            Email = email;
        }


        public void addCar(Car newCar)
        {
            if (!carsList.Contains(newCar))
                carsList.Add(newCar);
        }

        public void getCars()
        {
            var sortedList = carsList.OrderBy(o => o.DateOfProduction).ToList();
            foreach (Car car in sortedList)
            {
                Console.WriteLine(car);
            }
        }
    }
}
