using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal_10624.AdminModule
{
    public partial class ManageCompanyType : System.Web.UI.Page
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
            txtCompanyTypeName.Text = string.Empty;
            btnsubmit.Text = "Submit";
        }

        public void BindGridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdCompanyType.DataSource = dt;
            grdCompanyType .DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@ctname", txtCompanyTypeName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();

            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@ctid", ViewState["idd"]);
                cmd.Parameters.AddWithValue("@ctname", txtCompanyTypeName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();
            }
        }

        protected void grdCompanyType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@ctid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
            }

            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@ctid", e.CommandArgument);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                txtCompanyTypeName.Text = dt.Rows[0]["ctname"].ToString();
                btnsubmit.Text = "Update";
                ViewState["idd"] = e.CommandArgument;
            }
        }
    }
}