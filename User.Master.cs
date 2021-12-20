using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaraShopProject
{
    public partial class SSS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnuserlogout_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/SignIn.aspx");
            Session["Username"] = null;
        }
    }
}