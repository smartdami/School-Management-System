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
    public partial class FeeStructure : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void sub_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select sname,regno,sfee,standard from schooladmission where regno='" + regno_txtbx.Text + "'", con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fee_pan.Visible = true;
                name_lbl.Text = ds.Tables[0].Rows[0][0].ToString();
                rno_lbl.Text = ds.Tables[0].Rows[0][1].ToString();
                fee_lbl.Text = ds.Tables[0].Rows[0][2].ToString();
               std_lbl.Text = ds.Tables[0].Rows[0][3].ToString();
                datee_lbl.Text = System.DateTime.Today.ToShortDateString();

            }
            else
            {
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Enter Valid Register Number";
            }
        }

        protected void res_btn_Click(object sender, EventArgs e)
        {
            sts_lbl.Visible = false;
            fee_pan.Visible = false;
        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }
    }
}