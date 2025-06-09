using Microsoft.EntityFrameworkCore;
using ProjectV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Data
{
    public class RentalCompanyContext : DbContext
    {

        public DbSet<Rental> Rentals { get; set; } = null!;
        public DbSet<EmployeeRental> EmployeeRentals { get; set; } = null!;
        public DbSet<Mechanic> Mechanics { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<DeliveryEmployee> DeliveryEmployees { get; set; } = null!;
        public DbSet<RegisteryEmployee> RegisteryEmployees { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<CarState> CarStates { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<TruckCar> TruckCars { get; set; } = null!;
        public DbSet<SportsCar> SportsCars { get; set; } = null!;
        public DbSet<ElectricSportsCar> ElectricSportsCar { get; set; } = null!;
        public DbSet<ElectricCar> ElectricCars { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<ClientRental> ClientRentals { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=db-mssql;Initial Catalog=s20455;Integrated Security=True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
