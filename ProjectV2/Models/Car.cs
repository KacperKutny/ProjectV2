using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Car
    {

        public int CarId { get; set; }
        public string EngineType { get; set; }
        public string Model { get; set; }

        public DateTime DateOfProduction { get; set; }

        public StateType Type;

        public DateTime? DateOfRepair { get; set; }
        public DateTime? DateOfCorruption { get; set; }
        public DateTime? PlannedDateOfRepair { get; set; }

        public int ProducentId { get; set; }
        public Producent Producent { get; set; } = null!;
        public List<CarState> StateHistory = new List<CarState>();

        public ICollection<Rental> Rentals { get; set; } = null!;
        public ICollection<CarState> CarStates { get; set; } = null!;

        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Car() { }
        public Car(int carId, string engineType, string model, DateTime dateOfProduction)
        {
            CarId = carId;
            EngineType = engineType;
            Model = model;
            DateOfProduction = dateOfProduction;
        }

        public void makeCarRunning(DateTime dateOfCorruption, DateTime dateOfRepair)
        {
            Type = StateType.Running;
            DateOfRepair = dateOfRepair;
            DateOfCorruption = dateOfCorruption;

            State state = new State(dateOfCorruption, dateOfRepair);
            CarState carState = new CarState(this, state);
            addCarState(carState);
        }

        public void makeCarBroken(DateTime dateOfCorruption, DateTime plannedDateOfRepair)
        {
            Type = StateType.Broken;
            DateOfCorruption = dateOfCorruption;
            PlannedDateOfRepair = plannedDateOfRepair;

            State state = new State(dateOfCorruption, plannedDateOfRepair);
            CarState carState = new CarState(this, state);
            addCarState(carState);
        }

        public void addCarState(CarState newCarState)
        {
            if (newCarState != null && newCarState.Car == this)
            {
                StateHistory.Add(newCarState);
            }
        }

        public void getHistory()
        {
            foreach (CarState newCarState in StateHistory)
            {
                Console.WriteLine(newCarState);
            }
        }


        public override string ToString()
        {
            return "Car model: " + Model + " Date of production " + DateOfProduction;
        }


        public List<Car> getCarsList()
        {
            List<Car> cars = new List<Car>();
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT  CarId, Model, EngineType From Car;";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Car car = new Car();
                    car.CarId = Convert.ToInt32(dr["CarId"]);
                    car.Model = dr["Model"].ToString();
                    car.EngineType = dr["EngineType"].ToString();

                    cars.Add(car);
                }
            }
            con.Close();
            return cars;
        }
    }
}