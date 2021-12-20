using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZaraShopProject
{
    public partial class AddBrandName : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (textBrandName.Text != null && textBrandName.Text != "" && textBrandName.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tblBrands(Name) Values('" + textBrandName.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Brand Added Successfully ');  </script>");
                    textBrandName.Text = string.Empty;

                    con.Close();
                    lblMsg.Text = "Brand Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    textBrandName.Focus();


                }
            }
        }
    }
}
