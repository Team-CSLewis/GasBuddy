using GassBuddy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GassBuddy.Models;

namespace GassBuddy.Web.LoggedUser
{
    public partial class UserPage : System.Web.UI.Page
    {
        GassBuddyData data;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.data = new GassBuddyData();
                var userId = this.User.Identity.GetUserId();
                
                var userHistoryPosts = this.data.UsersHistory.All()
                                                            .Where(x => x.UserId == userId)
                                                            .ToList();

                this.ListViewUserPosts.DataSource = userHistoryPosts;
                this.totalMoneyAmount.InnerText = userHistoryPosts.Sum(x => x.TotalPrice).ToString();
                this.totalLitterAmount.InnerText = userHistoryPosts.Sum(x => x.FuelQuantity).ToString();
                var startDate = userHistoryPosts.Min(x => x.DateOfRefuel);
                var endDate = userHistoryPosts.Max(x => x.DateOfRefuel);
                var timeSpan = (endDate - startDate).Days;

                this.totalPeriod.InnerText = string.Format("Total period {0} days. From {1} to {2}", timeSpan, startDate.ToString("dd/mm/yyyy"), endDate.ToString("dd/mm/yyyy"));

                this.Page.DataBind();
            }
        }

        
    }
}