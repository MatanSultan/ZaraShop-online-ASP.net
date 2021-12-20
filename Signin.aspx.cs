using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ZaraShopProject
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"] != null)
                {
                    txtuser.Text = Request.Cookies["UNAME"].Value;
                    txtpass.Text = Request.Cookies["UPWD"].Value;
                    remeberbtn.Checked = true;

                }
            }

        }



            protected void Button1_Click(object sender, EventArgs e)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblUsers where Username=@username and Password=@pwd", con);
                    cmd.Parameters.AddWithValue("@username", txtuser.Text);

                    cmd.Parameters.AddWithValue("@pwd", txtpass.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        Session["USERID"] = dt.Rows[0]["Uid"].ToString();
                        Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);

                        if (remeberbtn.Checked)
                        {
                            Response.Cookies["UNAME"].Value = txtuser.Text;
                            Response.Cookies["UPWD"].Value = txtpass.Text;

                            Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);

                            Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);

                        }
                        else
                        {
                            Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);

                            Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                        }

                        string Utype;
                        Utype = dt.Rows[0][5].ToString().Trim();

                        if (Utype == "User")
                        {
                            Session["Username"] = txtuser.Text;
                            Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                            Session["getFullName"] = dt.Rows[0]["name"].ToString();
                          
                            Session["LoginType"] = "User";
                        //A query string is a part of a uniform resource locator(URL) that assigns values to specified parameters
                            if (Request.QueryString["rurl"] != null)
                            {

                                if (Request.QueryString["rurl"] == "cart")
                                {
                                    Response.Redirect("Cart.aspx");
                                }

                                if (Request.QueryString["rurl"] == "PID")
                                {
                                    string myPID = Session["ReturnPID"].ToString();
                                    Response.Redirect("ProductView.aspx?PID=" + myPID + "");
                                }
                            }

                            else
                            {
                                Response.Redirect("UserHome.aspx?UserLogin=YES");
                            }



                        }
                        if (Utype == "Admin")
                        {
                            Session["Username"] = txtuser.Text;
                            Session["LoginType"] = "Admin";
                            Response.Redirect("~/AdminHome.aspx");
                        }
                    }
                    else
                    {
                        LabelEror.Text = "Invalid Username and password";
                    }

                   
                    clr();
                    con.Close();
                    LabelEror.Text = "the deatels not good try agin ";
                    LabelEror.ForeColor = System.Drawing.Color.Green;

                }
            }

            private void clr()
            {
                txtpass.Text = string.Empty;
                txtuser.Text = string.Empty;
                txtuser.Focus();

            }


        }
    }
