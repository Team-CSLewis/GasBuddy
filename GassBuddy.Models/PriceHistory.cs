using System;
namespace GassBuddy.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }

        public int GasStationId { get; set; }

        public virtual GasStation GasStation { get; set; }

        public DateTime Date { get; set; }

        public decimal PetrolPrice { get; set; }

        public decimal DieselPrice { get; set; }

        public decimal LpgPrice { get; set; }
    }
}
