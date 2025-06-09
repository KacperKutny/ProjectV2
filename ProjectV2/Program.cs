using ProjectV2.Data;
using ProjectV2.Models;
/*
using RentalCompanyContext context = new RentalCompanyContext();
Address address = new Address
{
    Street = "XXXXXXXXXX",
    StreetNumber = 152
};

Institution institution = new Institution()
{
    ClosingHour = 9,
    OpeningHour = 22,
    Address = address,
};

List<string> previousJobs = new List<String>();
previousJobs.Add("Mechanik here");


ElectricSportsCar electricSportsCar = new ElectricSportsCar()
{
    EngineType = "eletryczny",
    Model = "Tesla Roadster",
    DateOfProduction = DateTime.Now,
    Range = 200,
    Power = 2000,
    VMax = 340,
    AdditionalFee = 240,
    ProducentId = 3
};

context.Add(address);
context.Add(institution);
context.ElectricSportsCar.Add(electricSportsCar);

electricSportsCar.makeCarBroken(new DateTime(2023-10-10), new DateTime(2023-11-11));
context.Update(electricSportsCar);
context.SaveChanges();


Mechanic mechanic = new Mechanic()
{
    Name = "Kacper",
    LastName = "Kutny",
    DateOfBirth = new DateTime(2001 - 10 - 10),
    Address = address,
    previousJobs = previousJobs,
    Specialization = "Samochody elektryczne",
    DateOfEmployment = new DateTime(2020 - 10 - 10)
    

};
context.Update(mechanic);
context.SaveChanges();

DeliveryEmployee de = new DeliveryEmployee
{
    Name = "Janusz",
    LastName = "XXXXXXXXXX",
    DateOfBirth = new DateTime(1994- 10 - 10),
    Address = address,
    previousJobs = previousJobs,
    DrivingLicenceCategory = "Q",
    DateOfEmployment = new DateTime(2012 - 10 - 10),

};
context.Update(de);
context.SaveChanges();
/*
RegisteryEmployee re = new RegisteryEmployee
{
    Name = "Tomasz",
    LastName = "Poziomka",
    DateOfBirth = new DateTime(1999 - 10 - 10),
    Address = address,
    previousJobs = previousJobs,
    NativeLanguage = "Polski",
    DateOfEmployment = new DateTime(2010- 10 - 10),


};
*/
namespace ProjectV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form2());


        }
    }
}