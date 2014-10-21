namespace GassBuddy.Data
{
    using System;
    using System.Xml.Linq;    
    using System.Linq;
    using GassBuddy.Models;
    using System.Collections.Generic;
    using System.Text;

    public class XMLGasStationReader
    {
        private Random rnd;
        private const decimal LOWEST_PRICE = 2.49m;
        private const decimal HIGHEST_PRICE = 2.71m;
        private const decimal LOWEST_PRICE_LPG = 1.10m;
        private const decimal HIGHEST_PRICE_LPG = 1.45m;

        public XMLGasStationReader()
        {
            this.rnd = new Random();
        }
        public ICollection<GasStation> GetGasStations(string path)
        {
            var xmlData = XElement.Load(path);

            var xmlWaypoints = xmlData.Elements();

            var gasStations = new List<GasStation>();

            foreach (var xmlWayPoint in xmlWaypoints)
            {
                if (xmlWayPoint.Name != "wpt")
                {
                    continue;
                }

                gasStations.Add(new GasStation
                    {
                        Name = this.GetName(xmlWayPoint),
                        GeoLocation = this.GetLocation(xmlWayPoint),
                        Description = this.GetDescription(xmlWayPoint),
                        Address = this.GetAddress(xmlWayPoint),
                        DieselPrice = this.GetPrice(LOWEST_PRICE, HIGHEST_PRICE),
                        PetrolPrice = this.GetPrice(LOWEST_PRICE, HIGHEST_PRICE),
                        LpgPrice = this.GetPrice(LOWEST_PRICE_LPG, HIGHEST_PRICE_LPG)
                    });
            }

            return gasStations;
        }        

        private string GetName(XElement xmlWayPoint)
        {
            if (xmlWayPoint.Element("name") != null)
            {
                return xmlWayPoint.Element("name").Value;
            }
            else
            {
                throw new ArgumentException("Gas station cannot be null or emoty");
            }
        }

        private string GetLocation(XElement xmlWayPoint)
        {
            var lat = xmlWayPoint.FirstAttribute.Value;
            var lon = xmlWayPoint.LastAttribute.Value;

            return string.Format("{0};{1}", lat, lon);
        }

        private string GetDescription(XElement xmlWayPoint)
        {
            if (xmlWayPoint.Element("desc") == null)
            {
                return string.Empty;
            }
            var desc = xmlWayPoint.Element("desc").Value;
            return desc;
        }

        private string GetAddress(XElement xmlWayPoint)
        {
            var address = xmlWayPoint.Element("extensions")
                                        .Element("WaypointExtension")
                                        .Element("Address")
                                        .Element("StreetAddress").Value;            
            return address;
        }

        private string GetCity(XElement xmlWayPoint)
        {
            var city = xmlWayPoint.Element("extensions")
                                        .Element("WaypointExtension")
                                        .Element("Address")
                                        .Element("City").Value;            
            return city;
        }

        private decimal GetPrice(decimal lowestPrice, decimal highestPrice)
        {
            var lowBoundAsInt = (int)((lowestPrice - Math.Floor(lowestPrice))*100);
            var highBoundAsInt = (int)((highestPrice - Math.Floor(highestPrice)) * 100);

            var cents = this.rnd.Next(lowBoundAsInt, highBoundAsInt);
            var price = Math.Floor(lowestPrice) + (decimal)cents / 100m;

            return price;
        }
    }
}
