namespace GassBuddy.Models
{
    using System.Collections.Generic;
    public class GasStation
    {   
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PetrolPrice { get; set; }

        public decimal DieselPrice { get; set; }

        public decimal LpgPrice { get; set; }

        public string Address { get; set; }

        public int ChainId { get; set; }

        public virtual Chain Chain { get; set; }

        public string Description { get; set; }

        public string GeoLocation { get; set; } 
    }
}
