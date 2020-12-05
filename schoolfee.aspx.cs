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
    public partial class schoolfee : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void view_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select sname,standard,sfee,status from schooladmission where regno='" + regno_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                string chkfee=ds.Tables[0].Rows[0][3].ToString();
                if ( chkfee== "NotPaid")
                {
                    name_lbl.Text= ds.Tables[0].Rows[0][0].ToString();
                    std_lbl.Text= ds.Tables[0].Rows[0][1].ToString();
                    fee_lbl.Text=ds.Tables[0].Rows[0][2].ToString();
                    reg_sts_lbl.Visible = false;
                    schoolfee_pan.Visible = true;
     
                }
                else
                {
                    reg_sts_lbl.Visible = true;
                    reg_sts_lbl.ForeColor = System.Drawing.Color.Green;
                    reg_sts_lbl.Text = "The Student Already Paid the School Fee";
                }

            }
            else
            {
                reg_sts_lbl.Visible = true;
                reg_sts_lbl.ForeColor = System.Drawing.Color.Red;
               reg_sts_lbl.Text = "Please Check the students Details";
            }
        }

        protected void pay_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            da.UpdateCommand = new OleDbCommand("update schooladmission set status='Paid' where regno='" + regno_txtbx.Text + "'", con);
            da.UpdateCommand.ExecuteNonQuery();
            sts_lbl.Visible = true;
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Text = "Payment Successful";
            con.Close();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            name_lbl.Text = "";
            fee_lbl.Text = "";
            std_lbl.Text = "";
          reg_sts_lbl.Visible = false;
            sts_lbl.Visible = false;
            schoolfee_pan.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}