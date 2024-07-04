using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal_10624
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(ddlusertype.SelectedValue == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblAdmin where Adminemail='" + txtemail.Text + "' and Adminpassword = '" + txtpassword.Text + "' ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login Failed !";
                }
                else
                {
                    Session["AID"] = dt.Rows[0]["adminid"];
                    Response.Redirect("~/AdminModule/AdminHome.aspx");
                }
            }
            else if (ddlusertype.SelectedValue == "2")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblJobRecruiter_Registration where jremail ='" + txtemail.Text + "' and jrpassword = '" + txtpassword.Text + "' and jrstatus = 0 ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login Failed !";
                }
                else
                {
                    Session["JRID"] = dt.Rows[0]["jrid"];
                    Response.Redirect("~/JobRecruiterModule/JobRecruiterHome.aspx");
                }
            }
            else if (ddlusertype.SelectedValue == "3")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from JobSeeker_Registration where jsemail='"+txtemail.Text+"' and jspassword = '"+txtpassword.Text+ "' and jsstatus = 0 ", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                if(dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login Failed !";
                }
                else
                {
                    Session["JSID"] = dt.Rows[0]["jsid"];
                    Response.Redirect("~/JobSeekerModule/JobSeekerHome.aspx");
                }
            }
        }
    }
}