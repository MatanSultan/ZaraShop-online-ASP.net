using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaraShopProject
{
    public partial class addcat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
  
        protected void addcatbtn_Click(object sender, EventArgs e)
        {
            //chacking if its null or empty 
            if (TextBoxcat.Text != null && TextBoxcat.Text != "" && TextBoxcat.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString))
                {
                    con.Open();
                    // insert the Sql the value on the textbox  : TextBoxcat;
                    SqlCommand cmd = new SqlCommand("Insert into tblCategory(CatName) Values('" + TextBoxcat.Text + "')", con);
                    cmd.ExecuteNonQuery();

                  //reset the textbox
                    TextBoxcat.Text = string.Empty;
                    //connection colse
                    con.Close();
                    lblmsg.Text = "add Category Successfully ";
                    // paint the string on the lblmsg in green color and update the user if the Category add successfully
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    TextBoxcat.Focus();
                }
            }
        }
    }
}