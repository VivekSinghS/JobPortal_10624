﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace JobPortal_10624.JobRecruiterModule
{
    public partial class JobRecruiter_ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchangpasword_Click(object sender, EventArgs e)
        {

            if (txtnewpasword.Text == txtconfirmpasword.Text)
            {
                if (txtnewpasword.Text != txtcurrentpasword.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Proc_JobRecruiter_Registration", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "ChangePassword");
                    cmd.Parameters.AddWithValue("@jrid", Session["JRID"]);
                    cmd.Parameters.AddWithValue("@jrcurrentpassword", txtcurrentpasword.Text);
                    cmd.Parameters.AddWithValue("@jrnewpassword", txtnewpasword.Text);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    
                    if (i == 0)
                    {
                        lblmsg.Text = "your Current Password is not Matched ...!!";
                    }
                    else
                    {
                        lblmsg.Text = "your Current Password has been change successfully ...!!";
                    }
                   
                }
                else
                {
                    lblmsg.Text = "Current Password and New Password should not be same !";
                }
            }
            else
            {
                lblmsg.Text = "Password do not matched ...!!";
            }

            
        }
    }
}