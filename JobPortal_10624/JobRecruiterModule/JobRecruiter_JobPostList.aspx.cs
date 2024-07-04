using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal_10624.JobRecruiterModule
{
    public partial class JobRecruiter_JobPostList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobPost();
            }
        }

        public void BindJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JPSJoinByRecruiter");
            cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdjobpostlist.DataSource = dt;
            grdjobpostlist.DataBind();
           
        }

        protected void grdjobpostlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Dlt") 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "changestatus");
                cmd.Parameters.AddWithValue("@jpsid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobPost();
            }
              else if (e.CommandName== "Edt")
            {
                Response.Redirect("JobRecruiter_JobPost.aspx?idd= " +e.CommandArgument);

            }
        }
    }
}