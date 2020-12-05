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
    public partial class hostelfee : System.Web.UI.Page
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
            da.SelectCommand = new OleDbCommand("select sname,roomno,fee,status from hosteladmission where regno='" + regno_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string chkfee = ds.Tables[0].Rows[0][3].ToString();
                if (chkfee == "NotPaid")
                {
                    fee_pan.Visible = true;
                    name_lbl.Text = ds.Tables[0].Rows[0][1].ToString();
                    rno_lbl.Text = ds.Tables[0].Rows[0][1].ToString();
                    fee_lbl.Text = ds.Tables[0].Rows[0][2].ToString();
                    reg_sts_lbl.Visible = false;

                }
                else
                {
                    fee_pan.Visible = false;
                    reg_sts_lbl.Visible = true;
                    reg_sts_lbl.ForeColor = System.Drawing.Color.Red;
                    reg_sts_lbl.Text = "The Student Already Paid the Hostel Fee";
                }

            }
            else
            {
                fee_pan.Visible = false;
                reg_sts_lbl.Visible = true;
                reg_sts_lbl.ForeColor = System.Drawing.Color.Red;
                reg_sts_lbl.Text = "Please Check the Register Number";
            }
        }

        protected void pay_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            da.UpdateCommand = new OleDbCommand("update hosteladmission set status='Paid' where regno='" + regno_txtbx.Text + "'", con);
            da.UpdateCommand.ExecuteNonQuery();
            sts_lbl.Visible = true;
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Text = "Payment Successful";
            feecon.Close();
        }

        protected void can_btn_Click(object sender, EventArgs e)
        {
            name_lbl.Text = "";
            rno_lbl.Text = "";
           fee_lbl.Text = "";
            rno_lbl.Text = "";
            sts_lbl.Visible = false;
            reg_sts_lbl.Visible = false;
            fee_pan.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}