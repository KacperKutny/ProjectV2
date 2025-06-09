using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Models
{
    public class Rental

    {
        public int RentalId { get; set; }
        public string DateOfRental { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PricePerDay { get; set; }
        public PaymentType? paymentType { get; set; }

        public string CardNumber = null!;
        public char CurrencySymbol;

        public Dictionary<int, Employee> employeeQualifier = new Dictionary<int, Employee>();
        public List<Employee> Employees { get; } = new();
        public ICollection<EmployeeRental> EmployeeRentals { get; set; } = null!;
        public ICollection<ClientRental> ClientRentals { get; set; } = null!;

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Rental() { }
        public Rental(int rentalId, string dateOfRental, decimal pricePerDay)
        {
            RentalId = rentalId;
            DateOfRental = dateOfRental;
            PricePerDay = pricePerDay;

        }

        public Rental(int rentalId, string dateOfRental, decimal pricePerDay, string cardNumber)
        {
            RentalId = rentalId;
            DateOfRental = dateOfRental;
            PricePerDay = pricePerDay;
            CardNumber = cardNumber;
            paymentType = PaymentType.CardPayment;
        }

        public Rental(int rentalId, string dateOfRental, decimal pricePerDay, char currencySymbol)
        {
            RentalId = rentalId;
            DateOfRental = dateOfRental;
            PricePerDay = pricePerDay;
            CurrencySymbol = currencySymbol;
            paymentType = PaymentType.CashPayment;
        }

        public void addEmployeeQualif(Employee employee)
        {

            if (!employeeQualifier.ContainsKey(employee.EmployeeId))
            {
                employeeQualifier.Add(employee.EmployeeId, employee);


                employee.setRental(this);
            }
        }

        public void addEmployee(Employee employee)
        {
            if (this.Employees.Contains(employee))
            {
                return;
            }

            this.Employees.Add(employee);
            employee.setRental(this);
        }

        public Employee? findEmployeeQualif(int Id)
        {

            if (!employeeQualifier.ContainsKey(Id))
            {
                throw new Exception("Unable to find an employee: " + Id);
            }
            return employeeQualifier.TryGetValue(Id, out Employee employee) ? employee : null;
        }

        public int getMaxRentalId()
        {
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            string sqlQuery = "SELECT Max(RentalId) FROM Rental;";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);




            int maxRentalId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return maxRentalId;

        }
        public void saveRental(string dateOfRental, decimal pricePerDay, int carId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

            string sqlQuery = "INSERT INTO Rental (DateOfRental, PricePerDay, CarId) VALUES ('" + dateOfRental + "', " + pricePerDay + ", " + carId + ")";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
