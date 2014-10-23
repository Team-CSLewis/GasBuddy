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
    public partial class SetDefaultPrice : System.Web.UI.Page
    {
        private IGassBuddyData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new GassBuddyData();
        }

        protected void BtnSetPrice_Click(object sender, EventArgs e)
        {
            var dieselPrice = decimal.Parse(this.TextBoxDieselPrice.Text);
            var petrolPrice = decimal.Parse(this.TextBoxPetrolPrice.Text);
            var lpgPrice = decimal.Parse(this.TextBoxLpgPrice.Text);
            var history = new PriceHistory()
            {
                Date = DateTime.Now,
                DieselPrice = dieselPrice,
                PetrolPrice = petrolPrice,
                LpgPrice = lpgPrice
            };

            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);

            var currentSet = this.data.PriceHistories.All()
                        .Where(x => x.Date >= today)
                        .Where(x => x.Date < tomorrow).FirstOrDefault();
            if (currentSet == null)
            {
                this.data.PriceHistories.Add(history);
            }
            else
            {
                currentSet.DieselPrice = dieselPrice;
                currentSet.LpgPrice = lpgPrice;
                currentSet.PetrolPrice = petrolPrice;
                this.data.PriceHistories.Update(currentSet);
            }
            this.data.SaveChanges();
            this.SuccessMessage.InnerText = "Data information successfully saved";
            this.SuccessMessage.Visible = true;
            this.ButtonBackToHome.Visible = true;
            this.FormForPrice.Visible = false;
        }

        protected void ButtonBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
    }
}