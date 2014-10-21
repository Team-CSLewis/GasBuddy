using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GassBuddy.Models
{
    public class Chain
    {
        private ICollection<GasStation> gasStations;

        public Chain()
        {
            this.gasStations = new HashSet<GasStation>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GasStation> GasStations
        {
            get { return this.gasStations; }
            set { this.gasStations = value; }
        }
    }
}
