namespace GassBuddy.Web.Data
{
    using GassBuddy.Models;
    using GassBuddy.Web.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class GasBuddyDbContext : IdentityDbContext<User>
    {
        public GasBuddyDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GasBuddyDbContext, Configuration>());
        }

        public static GasBuddyDbContext Create()
        {
            return new GasBuddyDbContext();
        }

        public IDbSet<Chain> Chains { get; set; }

        public IDbSet<GasStation> GasStations { get; set; }

        public IDbSet<PriceHistory> PriceHistory { get; set; }
    }
}