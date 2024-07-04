using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal_10624.AdminModule
{
    public partial class ManageJobRecruiter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobRecruiter();
            }
           
        }

        public void BindJobRecruiter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JRJoin");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdmanageJobRecruiter.DataSource = dt;
            grdmanageJobRecruiter.DataBind();

        }

        protected void grdmanageJobRecruiter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@jrid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobRecruiter();
            }
        }
    }
}