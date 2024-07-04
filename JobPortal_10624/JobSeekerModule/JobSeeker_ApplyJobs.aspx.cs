using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal_10624.JobSeekerModule
{
    public partial class JobSeeker_ApplyJobs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobPost();
                BindJobProfile();
            }
        }
         
        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoin");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdjobpostlist.DataSource = dt;
            grdjobpostlist.DataBind();

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

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoinSearch");
            cmd.Parameters.AddWithValue("@jpsjobprofile", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@jpsmaxsalary",txtsalary.Text);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdjobpostlist.DataSource = dt;
            grdjobpostlist.DataBind();
        }

        protected void grdjobpostlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Apy")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobSeeker_ApplyJobs", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jsid", Session["JSID"]);
                cmd.Parameters.AddWithValue("@jpsid", e.CommandArgument);

            }
        }
    }
}