using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand
            {
                Connection = con,
                CommandText = "select * from dbUserMange where IDNumer='" + txtusername.Text.Trim() + "' and password='" + txtPassword.Text.Trim() + "'",
                CommandType = System.Data.CommandType.Text
            };

            SqlDataReader aa;
            con.Open();
            aa = cmd.ExecuteReader();
            if (aa.Read())
            {
                Session["name"] = aa.GetString(0);
                con.Close();
                aa.Close();
                Response.Redirect("register");
            }
            else
                labelError.Text = "Something is wrong, the ID or the Password is not Right ! ";
            con.Close();
            aa.Close();
        }
    }
}
