namespace GassBuddy.Data.Migrations
{
    using GassBuddy.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GasBuddyDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GasBuddyDbContext context)
        {
            var chains = new List<Chain>()
            {
                new Chain()
                {
                    Name = "Shell",
                    GasStations = new HashSet<GasStation>()
                    {
                        new GasStation()
                            {
                                Name = "Shell 5",
                                Address = "Some Address",
                                DieselPrice = 2.51m,
                                PetrolPrice = 2.46m,
                                LpgPrice = 1.14m
                            }
                    }
                },                    
                new Chain()
                {
                    Name = "Lukoil",
                    GasStations = new HashSet<GasStation>()
                    {
                         new GasStation
                            {
                                Name = "Lukoil B146",
                                Address = "Some another Address",
                                DieselPrice = 2.50m,
                                PetrolPrice = 2.44m,
                                LpgPrice = 1.12m                                
                            }
                    }
                },
                new Chain()
                {
                    Name = "OMV",
                    GasStations = new HashSet<GasStation>()
                    {
                        new GasStation
                            {
                                Name = "OMV Best",
                                Address = "somethink in 83",
                                DieselPrice = 2.49m,
                                PetrolPrice = 2.45m,
                                LpgPrice = 1.12m                               
                            }
                    }
                }               
            };
            foreach (var chain in chains)
            {
                context.Chains.Add(chain);
            }
        }
    }
}
