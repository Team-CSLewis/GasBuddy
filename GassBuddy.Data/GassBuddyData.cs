using GassBuddy.Data.Repositories;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GassBuddy.Data
{
    public class GassBuddyData : IGassBuddyData
    {
        private IGasBuddyDbContext context;
        private IDictionary<Type, object> repositories;

        public GassBuddyData()
            : this(new GasBuddyDbContext())
        {
        }

        public GassBuddyData(IGasBuddyDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<PriceHistory> PriceHistories
        {
            get
            {
                return this.GetRepository<PriceHistory>();
            }
        }

        public IRepository<GasStation> GasStations
        {
            get
            {
                return this.GetRepository<GasStation>();
            }
        }

        public IRepository<Chain> Chains
        {
            get
            {
                return this.GetRepository<Chain>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<UserHistory> UsersHistory
        {
            get
            {
                return this.GetRepository<UserHistory>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
