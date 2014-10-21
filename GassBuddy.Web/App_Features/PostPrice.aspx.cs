using GassBuddy.Data;
using GassBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GassBuddy.Web.App_Features
{
    public partial class PostPrice1 : System.Web.UI.Page
    {
        private GassBuddyData data;
        public GasStation currentGasStation;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
            {
                var queryStrObject  = HttpUtility.ParseQueryString(this.Page.ClientQueryString);
                var gasStationId = int.Parse(queryStrObject["id"]);
                
                data = new GassBuddyData();

                currentGasStation = data.GasStations.All().FirstOrDefault(x => x.Id == gasStationId);
            }
            this.Page.DataBind();
        }
        

        protected void ButtonSubmitPrice_Click(object sender, EventArgs e)
        {
            
        }
    }
}