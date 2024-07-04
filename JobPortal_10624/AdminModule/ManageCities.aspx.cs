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
    public partial class ManageCities : System.Web.UI.Page
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
            ddlstatesName.SelectedValue = "0";
            txtCity.Text = "";
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

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_State", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GetStateByCountry");
            cmd.Parameters.AddWithValue("@cid", ddlCountry.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlstatesName.DataValueField = "stid";
            ddlstatesName.DataTextField = "stname";
            ddlstatesName.DataSource = dt;
            ddlstatesName.DataBind();
            ddlstatesName.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindGridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_City", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            grdCity.DataSource = dt;
            grdCity.DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@cid", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@stid",ddlstatesName.SelectedValue);
                cmd.Parameters.AddWithValue("@cityname", txtCity.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();

            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@cityid", ViewState["idd"]);
                cmd.Parameters.AddWithValue("@cid", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@stid", ddlstatesName.SelectedValue);
                cmd.Parameters.AddWithValue("@cityname",txtCity.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridView();
            }
        }

        protected void grdCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridView();
            }

            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_City", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "edit");
                cmd.Parameters.AddWithValue("@cityid", e.CommandArgument);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                ddlCountry.SelectedValue = dt.Rows[0]["cid"].ToString();
                BindState();
                ddlstatesName.SelectedValue= dt.Rows[0]["stid"].ToString();
                txtCity.Text = dt.Rows[0]["cityName"].ToString();
                btnsubmit.Text = "Update";
                ViewState["idd"] = e.CommandArgument;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }
    }
}