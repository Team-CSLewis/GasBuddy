using GassBuddy.Data;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GassBuddy.Web.LoggedUser
{
    public partial class PostPrice : System.Web.UI.Page
    {
        private GassBuddyData data;
        public GasStation currentGasStation;

        protected void Page_Load(object sender, EventArgs e)
        {
            data = new GassBuddyData();

            var queryStrObject = HttpUtility.ParseQueryString(this.Page.ClientQueryString);
            var gasStationId = int.Parse(queryStrObject["id"]);

            this.DropDownListFuelTypes.DataSource = Enum.GetNames(typeof(FuelType));

            currentGasStation = data.GasStations.All().FirstOrDefault(x => x.Id == gasStationId);

            var gasStationCoords = currentGasStation.GeoLocation.Split(';');
            this.StationLat.Text = gasStationCoords[0];
            this.StationLon.Text = gasStationCoords[1];
            this.Page.DataBind();
        }

        protected void ButtonSubmitPrice_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                return;
            }
            this.UpdateGasStationPrices();
            this.UpdateUserHistory();
            this.data.SaveChanges();

            this.SuccessMessage.InnerText = "Data information successfully saved";
            this.PostPricePageContent.Visible = false;
            this.ButtonBackToHome.Visible = true;
            this.userForm.Visible = false;
        }

        private void UpdateGasStationPrices()
        {
            if (this.TextBoxDieselPrice.Text.Length != 0)
            {
                var dieselPrice = decimal.Parse(this.TextBoxDieselPrice.Text);
                this.currentGasStation.DieselPrice = dieselPrice;
            }

            if (this.TextBoxPetrolPrice.Text.Length != 0)
            {

                var petrolPrice = decimal.Parse(this.TextBoxPetrolPrice.Text);
                this.currentGasStation.PetrolPrice = petrolPrice;
            }
            if (this.TextBoxLpgPrice.Text.Length != 0)
            {
                var lpgPrice = decimal.Parse(this.TextBoxLpgPrice.Text);

                this.currentGasStation.LpgPrice = lpgPrice;
            }
        }

        private void UpdateUserHistory()
        {
            var username = this.User.Identity.Name;
            var userId = this.data.Users.All().FirstOrDefault(x => x.UserName == username).Id;
            var pricePerLitter = decimal.Parse(this.TextBoxPricePerLitter.Text);
            var fuelQuantity = decimal.Parse(this.TextBoxFuelQuantity.Text);
            var totalPrice = pricePerLitter * fuelQuantity;
            var gasStationId = this.currentGasStation.Id;
            var fuelType = this.DropDownListFuelTypes.SelectedIndex;

            var date = DateTime.Now;

            var userHistory = new UserHistory
            {
                UserId = userId,
                DateOfRefuel = date,
                PricePerLitter = pricePerLitter,
                FuelQuantity = fuelQuantity,
                TotalPrice = totalPrice,
                GasStationId = gasStationId,
                FuelType = (FuelType)fuelType
            };

            this.data.UsersHistory.Add(userHistory);
        }

        protected void ButtonBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
    }
}