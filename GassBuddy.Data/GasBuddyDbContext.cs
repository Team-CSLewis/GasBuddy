namespace GassBuddy.Data
{
    using GassBuddy.Data;
    using GassBuddy.Data.Migrations;
    using GassBuddy.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class GasBuddyDbContext : IdentityDbContext<User>, IGasBuddyDbContext
    {
        public GasBuddyDbContext()
            : base("GasBuddy", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GasBuddyDbContext, Configuration>());
        }

        public static GasBuddyDbContext Create()
        {
            return new GasBuddyDbContext();
        }

        public IDbSet<Chain> Chains { get; set; }

        public IDbSet<GasStation> GasStations { get; set; }

        public IDbSet<PriceHistory> PriceHistories { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}