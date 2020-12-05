using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace School_Management_System
{
    public partial class BusRegistration : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbConnection fcon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        DataSet fds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chk_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select * from schooladmission where regno='" + reg_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sts_lbl1.Visible = true;
                sts_lbl1.ForeColor = System.Drawing.Color.Red;
                sts_lbl1.Text = "Register Number Invalid....";
            }
            else
            {
                sts_lbl1.Visible = false;
                name_txtbx.Text = ds.Tables[0].Rows[0][1].ToString();

            }
        }

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select price from busprice where area='" + area_dpdown.Text + "'", con);
            fds.Clear();
            da.Fill(fds);
            Label12.Visible = true;
            Fare_lbl.Visible = true;
            Fare_lbl.Text = fds.Tables[0].Rows[0][0].ToString();
            confirm_btn.Visible = true;
            confirm_btn.Enabled = true;
        }

        protected void confirm_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select regno from busreg where regno='" + reg_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sts_lbl2.Visible = true;
                sts_lbl2.Text = "The Student Already Registered...";
            }
            else
            {
                con.Open();

                da.InsertCommand = new OleDbCommand("insert into busreg(regno,sname,area,fare,status) values('" + reg_txtbx.Text + "','" + name_txtbx.Text + "','" + area_dpdown.Text + "','" + Fare_lbl.Text + "','notpaid')", con);
                sts_lbl2.Visible = true;
                sts_lbl2.Text = "Values are inserted into Database...";
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
                confirm_btn.Enabled = false;
            }
        }

        protected void Reset_btn_Click(object sender, EventArgs e)
        {
            reg_txtbx.Text = "";
            name_txtbx.Text = "";
            area_dpdown.Text = "";
            Fare_lbl.Visible = false;
            Label12.Visible = false;
            sts_lbl1.Visible = false;
            sts_lbl2.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}