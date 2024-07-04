using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace JobPortal_10624.JobSeekerModule
{
    public partial class JobSeeker_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCountry();
                BindJobProfile();
                BindJobExp();
                BindQualification();
               // BindGridView();
            }
        }
        public void Clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtpassword.Text = "";
            ddlCountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue = "0";
            ddlExp.SelectedValue= "0";
            ddljobprofile.SelectedValue = "0";
            ddlQualification.SelectedValue = "0";
            txtcomment.Text = "";
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

        public void BindJobExp()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_JobExp ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlExp.DataValueField = "jeid";
            ddlExp.DataTextField = "jename";
            ddlExp.DataSource = dt;
            ddlExp.DataBind();
            ddlExp.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_tblQualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "show");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlQualification.DataValueField = "qID";
            ddlQualification.DataTextField = "qName";
            ddlQualification.DataSource = dt;
            ddlQualification.DataBind();
            ddlQualification.Items.Insert(0, new ListItem("--Select--", "0"));
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
            ddlstate.DataValueField = "stid";
            ddlstate.DataTextField = "stname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Proc_City", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GetCityByState");
            cmd.Parameters.AddWithValue("@stid", ddlstate.SelectedValue);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "cityid";
            ddlcity.DataTextField = "cityname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string JSPhoto = Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath("JS_PHOTOS" + "\\" +JSPhoto));

            string JSResume = Path.GetFileName(fuResume.PostedFile.FileName);
            fuResume.SaveAs(Server.MapPath("JS_RESUME" + "\\" + JSResume));

            if (btnSubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_JobSeeker_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@jsname", txtName.Text);
                cmd.Parameters.AddWithValue("@jsemail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@jspassword", txtpassword.Text);
                cmd.Parameters.AddWithValue("@jsjobprofile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@jsexp", ddlExp.SelectedValue);
                cmd.Parameters.AddWithValue("@jsqualification", ddlQualification.SelectedValue);
                cmd.Parameters.AddWithValue("@jscountry", ddlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@jsstate", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@jscity", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@jscomment", txtcomment.Text);
                cmd.Parameters.AddWithValue("@jsphoto", JSPhoto);
                cmd.Parameters.AddWithValue("@jsresume", JSResume);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
               

            }
           
        }
    }
}