﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace School_Management_System
{
    public partial class admin_login : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        string pos = "admin";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select pass from logintable where userid='" + userid_txtbx.Text + "' AND jposition='" + pos + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Visible = true;
                sts_lbl.Text = "Please Check Your Admin ID";
            }
            else
            {
                if ((ds.Tables[0].Rows[0][0].ToString()) == pass_txtbx.Text)
                {

                    Response.Redirect("AddUser.aspx");
                }
                else
                {
                    sts_lbl.Visible = true;
                    sts_lbl.Text = "Please Check Your Password";
                }
            }
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}