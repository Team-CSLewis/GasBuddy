namespace GassBuddy.Web.Data
{
    using GassBuddy.Models;
    using GassBuddy.Web.Migrations;
    using GassBuddy.Web.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class GasBuddyDbContext : IdentityDbContext<ApplicationUser>
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