using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZaraShopProject.Classes;

namespace ZaraShopProject
{
    public partial class register : System.Web.UI.Page
    {
        PasswordHandler passHandler = new PasswordHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


protected void txtsignup_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = PhoneTB.Text.Trim();
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = EmailTB.Text.Trim();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                cmd = new SqlCommand(RoleRBL.SelectedValue == "1" ? "spu_InsertNewBaker" : "spu_InsertNewClient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = PhoneTB.Text.Trim();
                cmd.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = FullNameTB.Text.Trim();
                cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = AddressTB.Text.Trim();
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = EmailTB.Text.Trim();
                String password = PasswordTB.Text;
                String salt = passHandler.GetSalt();// the salt to send to the DB
                String hasedEverything = passHandler.CreateHashedPassword(password, salt);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = hasedEverything;
                cmd.Parameters.Add("@salt", SqlDbType.NVarChar).Value = salt;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    Session["phone"] = PhoneTB.Text.Trim();
                    Session["name"] = FullNameTB.Text.Trim();
                    Session["role"] = RoleRBL.SelectedValue;
                    Message.Text = "Registerd! Just a sec...";
                    Response.AddHeader("REFRESH", "5;URL=" + (Convert.ToInt32(Session["role"]) == 1 ? "BakerMain" : "ClientMain"));

                }
                else
                {
                    Message.Text = "Error";
                }
            }
            else
            {
                Message.Text = RoleRBL.SelectedValue == "1" ? "This baker already exists" : "This client already exists";
                reader.Close();
            }
            con.Close();

        }
    }
}