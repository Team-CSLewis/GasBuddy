using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GassBuddy.Data
{
    public interface IGasBuddyDbContext
    {
        IDbSet<Chain> Chains { get; set; }

        IDbSet<GasStation> GasStations { get; set; }

        IDbSet<PriceHistory> PriceHistories { get; set; }

        IDbSet<User> Users { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
