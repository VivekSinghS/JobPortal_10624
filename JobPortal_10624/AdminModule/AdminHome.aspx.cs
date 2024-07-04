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
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAdminData();
            }
        }

        public void ShowAdminData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblAdmin where adminid = '"+Session["AID"] +"' ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            lbladminname.Text = dt.Rows[0]["adminname"].ToString();
            lbladminemail.Text = dt.Rows[0]["adminemail"].ToString();
            lbladminpassword.Text = dt.Rows[0]["adminpassword"].ToString();
        }
    }
}