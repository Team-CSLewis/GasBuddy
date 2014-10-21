using GassBuddy.Data.Repositories;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GassBuddy.Data
{
    public interface IGassBuddyData
    {
        IRepository<PriceHistory> PriceHistories { get; }

        IRepository<Chain> Chains { get; }

        IRepository<GasStation> GasStations { get; }

        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
