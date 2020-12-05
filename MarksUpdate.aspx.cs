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
    public partial class MarksUpdate : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");

        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void update_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select regno from marksupdate where regno='" + REGNO_TXTBX.Text + "'",con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count==0)
            {
                con.Open();
                da.InsertCommand = new OleDbCommand("insert into marksupdate(regno,standard,tamil,english,maths,science,ss) values('" + REGNO_TXTBX.Text + "','" + sts_dpdown.Text + "','" + tamil_txtbx.Text + "','" + english_txtbx.Text + "','" + maths_txtbx.Text + "','" + science_txtbx.Text + "','" + ss_txtbx.Text + "')", con);
                res_lbl.Visible = true;
                res_lbl.ForeColor = System.Drawing.Color.Green;
                res_lbl.Text = "Values inserted into Database";
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                res_lbl.Visible = true;
                res_lbl.ForeColor = System.Drawing.Color.Red;
                res_lbl.Text = "The Marks are already Updated for this student";
            }
            
        }

        protected void can_btn_Click(object sender, EventArgs e)
        {
            res_lbl.Visible = false;
            REGNO_TXTBX.Text = "";
            tamil_txtbx.Text = "";
            english_txtbx.Text = "";
            maths_txtbx.Text = "";
            science_txtbx.Text = "";
            ss_txtbx.Text = "";
        }

        protected void lg_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("stafflogin.aspx");
        }
    }
}