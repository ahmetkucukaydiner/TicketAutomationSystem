using Core.Entitites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TicketAutomationSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB; Database = TAS; Trusted_Connection = true");
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusOwner> BusOwners { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<BusStaff> BusStaffes { get; set; }
        public DbSet<BusType> BusTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<JourneyStation> JourneyStations { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LineStation> LineStations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pnr> Pnr { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
