using GassBuddy.Data;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GassBuddy.Web.Admin
{
    public partial class NewGasStation : System.Web.UI.Page
    {
        private IGassBuddyData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new GassBuddyData();
            if (!this.Page.IsPostBack)
            {

                this.DropDownChains.DataSource = data.Chains.All()
                                                                .Select(x => new { x.Name , x.Id})
                                                                .ToList();
                this.Page.DataBind();
            }
        }

        protected void AddStation_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                return;
            }

            var name = this.TbStationName.Text;
            var description = this.TbDescription.Text;
            var location = this.TbLocation.Text;
            var address = this.TbStationAddress.Text;
            var city = this.TbCity.Text;
            var chain = int.Parse(this.DropDownChains.SelectedValue);
            var defaultPrice = this.data.PriceHistories.All().OrderByDescending(p => p.Date).FirstOrDefault();
            var station = new GasStation()
            {
                Name = name,
                Description = description,
                GeoLocation = location,
                Address = address,
                ChainId = chain,
                City = city,
                DieselPrice = defaultPrice.DieselPrice,
                LpgPrice = defaultPrice.LpgPrice,
                PetrolPrice = defaultPrice.PetrolPrice
            };
            this.data.GasStations.Add(station);
            this.data.SaveChanges();
            this.SuccessMessage.InnerText = "Gas station successfully added";
            this.SuccessMessage.Visible = true;
            this.ButtonBackToHome.Visible = true;
            this.NewStationForm.Visible = false;

        }

        protected void ButtonBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
    }
}