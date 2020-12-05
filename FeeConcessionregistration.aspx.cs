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
    public partial class FeeConcessionregistration : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Chk_btn_Click(object sender, EventArgs e)
        {
            
            da.SelectCommand = new OleDbCommand("select sfee,standard from schooladmission where regno='" + regno_txtbx.Text  +"'" , con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sts_label.Visible = true;
                sts_label.ForeColor = System.Drawing.Color.Red;
                sts_label.Text = "Register Number Invalid....";
            }
            else
            {
                sts_label.Visible = false;
                fee_txtbx.Text = ds.Tables[0].Rows[0][0].ToString();
                std_txtbx.Text = ds.Tables[0].Rows[0][1].ToString();

            }
            RequiredFieldValidator2.Enabled = true;
        }

        protected void Apply_btn_Click(object sender, EventArgs e)
        {
           
            con.Open();
            da.InsertCommand = new OleDbCommand("insert into feeconcessionreg(regno,totalfee,concessionwant,std) values('" + regno_txtbx.Text + "','" + fee_txtbx.Text + "','" + Concession_txtbx.Text +"','"+std_txtbx.Text+ "')", con);
            da.InsertCommand.ExecuteNonQuery();
            sts_lbl.Visible = true;
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Text = "Fee Concession Registration Successful....";
            con.Close();
        }

        protected void Concession_txtbx_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void resbtn_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator2.Enabled = false;
            Response.Redirect("FeeConcessionregistration");
        }

        protected void home_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}