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
    public partial class ManageQualification : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        public void Clear()
        {
            txtqualificationName.Text = string.Empty;
            btnsubmit.Text = "Submit";
        }

        public void BindGridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdQualification.DataSource = dt;
            grdQualification.DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@qname", txtqualificationName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();

            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@qid", ViewState["idd"]);
                cmd.Parameters.AddWithValue("@qname", txtqualificationName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();
            }
        }
        protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@qid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
            }

            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@qid", e.CommandArgument);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                txtqualificationName.Text = dt.Rows[0]["qname"].ToString();
                btnsubmit.Text = "Update";
                ViewState["idd"] = e.CommandArgument;
            }

        }

        
    }
}