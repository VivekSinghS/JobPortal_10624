using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace JobPortal_10624.JobRecruiterModule
{
    public partial class JobRecruiter_JobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                EditData();
            }
        }


        public void EditData()
        {
            if (Request.QueryString["idd"] != null && Request.QueryString["idd"].ToString() == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@jpsid", Request.QueryString["idd"].ToString());
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                ddljobprofile.SelectedValue = dt.Rows[0]["jpsjobprofile"].ToString();
                rblGender.SelectedValue = dt.Rows[0]["jpsgender"].ToString();
                ddlMinExp.SelectedValue = dt.Rows[0]["jpsminexp"].ToString();
                ddlMaxExp.SelectedValue = dt.Rows[0]["jpsmaxexp"].ToString();
                txtminSalary.Text = dt.Rows[0]["jpsminsalary"].ToString();
                txtmaxSalary.Text = dt.Rows[0]["jpsmaxsalary"].ToString();
                txtComment.Text = dt.Rows[0]["jpscomment"].ToString();
                btnjobpost.Text = "Update";
            }
        }

        public void BindJobProfile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobProfiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "jpID";
            ddljobprofile.DataTextField = "jpName";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnjobpost_Click(object sender, EventArgs e)
        {
            if (btnjobpost.Text == "Job Post")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsgender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminexp", ddlMinExp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsmaxexp", ddlMaxExp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminsalary", txtminSalary.Text);
                cmd.Parameters.AddWithValue("@jpsmaxsalary", txtmaxSalary.Text);
                cmd.Parameters.AddWithValue("@jpscomment", txtComment.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("JobRecruiter_JobPostList.aspx");
            }
              else if (btnjobpost.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@jpsid", Request.QueryString["idd"].ToString());
                cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsgender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminexp", ddlMinExp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsmaxexp", ddlMaxExp.SelectedValue);
                cmd.Parameters.AddWithValue("@jpsminsalary", txtminSalary.Text);
                cmd.Parameters.AddWithValue("@jpsmaxsalary", txtmaxSalary.Text);
                cmd.Parameters.AddWithValue("@jpscomment", txtComment.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("JobRecruiter_JobPostList.aspx");
            }
        }
    }
}