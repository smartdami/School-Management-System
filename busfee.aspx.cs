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
    public partial class busfee : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet dt = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sub_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("Select * from busreg where regno='" + regno_txtbx.Text + "'", con);
            dt.Clear();
            da.Fill(dt);
            if ((dt.Tables[0].Rows.Count)>0)
            {
                if (dt.Tables[0].Rows[0][4].ToString() == "notpaid")
                {
                    fee_panel.Visible = true;
                    name_lbl.Text = dt.Tables[0].Rows[0][1].ToString();
                    area_lbl.Text = dt.Tables[0].Rows[0][2].ToString();
                    fare_lbl.Text = dt.Tables[0].Rows[0][3].ToString();
                   
                }
                else
                {
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Green;
                    sts_lbl.Text = "Fee Already Paid";
                }
                    
            }
            else
            {
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Invalid User";
            }
        }

        protected void pay_btn_Click(object sender, EventArgs e)
        {
            con.Open();
            da.UpdateCommand = new OleDbCommand("update busreg set status='Paid' where regno='" + regno_txtbx.Text+"'", con);
            fres_lbl.Visible = true;
            fres_lbl.ForeColor = System.Drawing.Color.Green;
            fres_lbl.Text = "Payment Successful";
            da.UpdateCommand.ExecuteNonQuery();
            con.Close();
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            regno_txtbx.Text = "";
            fee_panel.Visible = false;
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}