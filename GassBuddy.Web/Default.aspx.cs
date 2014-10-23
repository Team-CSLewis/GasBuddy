namespace GassBuddy.Web
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using GassBuddy.Data;

    public partial class Default : Page
    {
        private GassBuddyData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            data = new GassBuddyData();
            if (Page.IsPostBack)
            {
                return;
            }

            GridViewStations.DataSource =
                data.GasStations.All().OrderBy(s => s.DieselPrice + s.PetrolPrice + s.LpgPrice).ToList();
            GridViewStations.DataBind();

            var gasStationsCount = Enumerable.Count(data.GasStations.All());
            LiteralStationsCount.Text = gasStationsCount.ToString(CultureInfo.InvariantCulture);

            var avgDieselPrice = data.GasStations.All().Average(s => s.DieselPrice);
            AvgDiselPrice.Text = avgDieselPrice.ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));

            var avgLpgPrice = data.GasStations.All().Average(s => s.LpgPrice);
            AvgLPGPrice.Text = avgLpgPrice.ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));

            var avgPetrolPrice = data.GasStations.All().Average(s => s.PetrolPrice);
            AvgPetrolPrice.Text = avgPetrolPrice.ToString("C", CultureInfo.CreateSpecificCulture("Bg-bg"));
        }

        protected void GridViewStations_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewStations.PageIndex = e.NewPageIndex;
            GridViewStations.DataSource =
                data.GasStations.All().OrderBy(s => s.DieselPrice + s.PetrolPrice + s.LpgPrice).ToList();
            GridViewStations.DataBind();
        }

    }
}