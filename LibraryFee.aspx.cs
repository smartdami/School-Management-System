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
    public partial class LibraryFee : System.Web.UI.Page
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbConnection feecon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ok_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select * from libraryfee where regno='" + regno_txtbx.Text + "'", feecon);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string chkfee = ds.Tables[0].Rows[0][3].ToString();
                if (chkfee == "NotPaid")
                {
                    fee_pan.Visible = true;
                    sts_lbl.Visible = false;
                    name_lbl.Text = ds.Tables[0].Rows[0][1].ToString();
                    std_lbl.Text = ds.Tables[0].Rows[0][4].ToString();
                    fee_lbl.Text = ds.Tables[0].Rows[0][2].ToString();


                }
                else
                {
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Green;
                    sts_lbl.Text = "The Student Already Paid the Library Fee";
                }

            }
            else
            {
                sts_lbl.Visible = true;
               sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Please Check the Register No";
            }
        }

        protected void pay_btn_Click(object sender, EventArgs e)
        {
            feecon.Open();
            da.UpdateCommand = new OleDbCommand("update libraryfee set status='Paid' where regno='" + regno_txtbx.Text + "'", feecon);
            da.UpdateCommand.ExecuteNonQuery();
            fsts_lbl.Visible = true;
            fsts_lbl.ForeColor = System.Drawing.Color.Green;
            fsts_lbl.Text = "Payment Successful";
            feecon.Close();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            name_lbl.Text = "";
            sts_lbl.Text = "";
            fee_lbl.Text = "";
            sts_lbl.Visible = false;
            fsts_lbl.Visible = false;
            fee_pan.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}