using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GassBuddy.Data;
using GassBuddy.Models;

namespace GassBuddy.Web.App_Features
{
    public partial class PostPrice : Page
    {
        private GassBuddyData data;       

        protected void Page_Load(object sender, EventArgs e)
        {
            this.data = new GassBuddyData();

            if (!this.Page.IsPostBack)
            {
                this.DropDownListCities.DataSource = data.GasStations.All()
                                                                       .Select(x => x.City)
                                                                       .Distinct()
                                                                       .ToList();

                this.DropDownChains.DataSource = data.Chains.All()
                                                                .Select(x => x.Name)
                                                                .ToList();
                this.Page.DataBind();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var city = this.DropDownListCities.SelectedValue;
            var chain = this.DropDownChains.SelectedValue;
            var gasStations = GetGasStationsByChainAndCity(city, chain);
            this.GridViewGasStations.DataSource = gasStations;
            this.GridViewGasStations.DataBind();
        }

        protected void GridViewGasStations_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var city = this.DropDownListCities.SelectedValue;
            var chain = this.DropDownChains.SelectedValue;
            var gasStations = GetGasStationsByChainAndCity(city, chain);
            this.GridViewGasStations.PageIndex = e.NewPageIndex;
            this.GridViewGasStations.DataSource = gasStations;
            this.GridViewGasStations.DataBind();
        }

        
        private ICollection<GasStation> GetGasStationsByChainAndCity (string city, string chain)
        {
            return this.data.GasStations.All()
                                        .Where(x => x.City == city && x.Chain.Name == chain)
                                        .ToList();
        }
    }
}