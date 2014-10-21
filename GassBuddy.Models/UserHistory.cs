namespace GassBuddy.Models
{
    using System;

    public class UserHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime DateOfRefuel { get; set; }

        public virtual GasStation GasStation { get; set; }

        public int GasStationId { get; set; }

        public decimal FuelQuantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
