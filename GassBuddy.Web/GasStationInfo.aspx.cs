using GassBuddy.Data;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GassBuddy.Web
{
    public partial class GasStationInfo : Page
    {
        private GassBuddyData data;
        public GasStation currentGasStation;

        protected void Page_Load(object sender, EventArgs e)
        {
            data = new GassBuddyData();

            var queryStrObject = HttpUtility.ParseQueryString(this.Page.ClientQueryString);
            var gasStationId = int.Parse(queryStrObject["id"]);

            currentGasStation = data.GasStations.All().FirstOrDefault(x => x.Id == gasStationId);

            var gasStationCoords = currentGasStation.GeoLocation.Split(';');
            this.StationLat.Text = gasStationCoords[0];
            this.StationLon.Text = gasStationCoords[1];

            this.DieselPrice.Text = currentGasStation.DieselPrice.ToString();
            this.PetrolPrice.Text = currentGasStation.PetrolPrice.ToString();
            this.LpgPrice.Text = currentGasStation.LpgPrice.ToString();
            this.Address.Text = currentGasStation.Address;
            this.City.Text = currentGasStation.City;
            this.Chain.Text = currentGasStation.Chain.Name;

            var usersPosted = GetUsersByPosts(currentGasStation.Id);
            this.GridUsersPosts.DataSource = usersPosted;

            this.Page.DataBind();
        }

        protected void GridUsersPosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gasStationId = this.currentGasStation.Id;
            var users = GetUsersByPosts(gasStationId);
            this.GridUsersPosts.PageIndex = e.NewPageIndex;
            this.GridUsersPosts.DataSource = users;
            this.GridUsersPosts.DataBind();
        }

        private ICollection<UserHistory> GetUsersByPosts(int gasStationId)
        {
            return this.data.UsersHistory.All()
                                        .Where(x => x.GasStationId == gasStationId)
                                        .ToList();
        }
    }
}