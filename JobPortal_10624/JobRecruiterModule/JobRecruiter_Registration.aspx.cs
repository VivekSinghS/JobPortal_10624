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
    public partial class JobRecruiter_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCompanyType();
            }
        }

        public void Clear()
        {
            txtcompanyName.Text = string.Empty;
            btnSubmit.Text = "Submit";
        }

        public void BindCompanyType()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_CompanyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlcompanytype.DataValueField = "ctid";
            ddlcompanytype.DataTextField = "ctname";
            ddlcompanytype.DataSource = dt;
            ddlcompanytype.DataBind();
            ddlcompanytype.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_Registration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@jrname", txtcompanyName.Text);
            cmd.Parameters.AddWithValue("@jrtype", ddlcompanytype.SelectedValue);
            cmd.Parameters.AddWithValue("@jremail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@jrpassword", txtpassword.Text);
            cmd.Parameters.AddWithValue("@jrcontactperson", txtcontactperson.Text);
            cmd.Parameters.AddWithValue("@jrcontactnumber", txtcontactno.Text);
            cmd.Parameters.AddWithValue("@jrcomment", txtcomment.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}