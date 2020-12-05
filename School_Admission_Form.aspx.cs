using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace School_Management_System
{
    public partial class School_Admission_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dob_txtbx.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void sub_btn_Click(object sender, EventArgs e)
        {
            OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
            my_con.Open();
            OleDbCommand o_cmd = new OleDbCommand("insert into schoolreg values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p)", my_con);
            o_cmd.Parameters.AddWithValue("a", name_txtbx.Text);
            o_cmd.Parameters.AddWithValue("b", fname_txtbx.Text);
            o_cmd.Parameters.AddWithValue("c", mname_txtbx.Text);
            o_cmd.Parameters.AddWithValue("d", gen_dpdown.Text);
            o_cmd.Parameters.AddWithValue("e", Nat_txtbx.Text);
            o_cmd.Parameters.AddWithValue("f", dob_txtbx.Text);
            o_cmd.Parameters.AddWithValue("g", std_dpdown.Text);
            o_cmd.Parameters.AddWithValue("h", com_dpdown.Text);
            o_cmd.Parameters.AddWithValue("i", rel_dpdown.Text);
            o_cmd.Parameters.AddWithValue("j", blood_dpdown.Text);
            o_cmd.Parameters.AddWithValue("k", pstud_txtbx.Text);
            o_cmd.Parameters.AddWithValue("l", cno_txtbx.Text);
            o_cmd.Parameters.AddWithValue("m", hos_dpdown.Text);
            o_cmd.Parameters.AddWithValue("n", add_txtbx.Text);
            o_cmd.Parameters.AddWithValue("o", email_txtbx.Text);
            o_cmd.Parameters.AddWithValue("p", dob_txtbx.Text);
            o_cmd.ExecuteNonQuery();
            my_con.Close();
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Visible = true;
        }

        protected void clr_btn_Click(object sender, EventArgs e)
        {
            name_txtbx.Text = "";
            fname_txtbx.Text="";
           mname_txtbx.Text= "";  
           Nat_txtbx.Text= "";
            dob_txtbx.Text= "";           
             pstud_txtbx.Text= "";
            cno_txtbx.Text= "";
            add_txtbx.Text= "";
             email_txtbx.Text= "";
            sts_lbl.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}