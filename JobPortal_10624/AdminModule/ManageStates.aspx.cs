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
    public partial class ManageStates : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCountry();
                BindGridView();
            }
        }
        public void Clear()
        {
            ddlCountry.SelectedValue = "0";
            txtstatesName.Text = string.Empty;
            btnsubmit.Text = "Submit";
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_Countries", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlCountry.DataValueField = "cid";
            ddlCountry.DataTextField = "cname";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindGridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_State", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdStates.DataSource = dt;
            grdStates.DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@cid", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@stname", txtstatesName.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();

            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@stid", ViewState["idd"]);
                cmd.Parameters.AddWithValue("@cid", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@stname", txtstatesName.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();
            }
        }

        protected void grdStates_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@stid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
            }

            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_State", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@stid", e.CommandArgument);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                ddlCountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                txtstatesName.Text = dt.Rows[0]["stName"].ToString();
                btnsubmit.Text = "Update";
                ViewState["idd"] = e.CommandArgument;
            }

        }
    }
}