using System.Data.Entity;

namespace SafeFreightLogisticsApp.Models
{
    public class SafeFreightDB : DbContext
    {
        public SafeFreightDB() : base("name=SafeFreightDB")
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ShipmentMode> ShipmentModes { get; set; }
        public DbSet<HalfHourlyTime> HalfHourlyTimes { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }

    }
}