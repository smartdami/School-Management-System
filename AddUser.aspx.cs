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
    public partial class AddUser : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select userid from logintable where userid='" + id_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count==0)
            {
                con.Open();
                da.InsertCommand=new OleDbCommand("insert into logintable(userid,pass,username,jposition) values('" + id_txtbx.Text + "','" + pass_txtbx.Text + "','" + uname_txtbx.Text + "','" + pos_dpdown.Text + "')", con);
                da.InsertCommand.ExecuteNonQuery();
                sts_lbl.Text = "User Added Successfully";
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Green;
                con.Close();
            }
            else
            {
                sts_lbl.Text = "Enter Different User ID";
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void clr_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_login.aspx");
        }
    }
}