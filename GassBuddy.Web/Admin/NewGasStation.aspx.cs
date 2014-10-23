using GassBuddy.Data;
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
        }
    }
}