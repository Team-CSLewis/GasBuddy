using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GassBuddy.Web.App_Features
{
    public partial class PostPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.LabelCoords.Text = "Location found successfully: " + this.TextBox1.Text;
        }
    }
}