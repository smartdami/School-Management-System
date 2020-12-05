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
    public partial class FeeConcessionSelection : System.Web.UI.Page
    {
        string regno, totalfee, concessionwant, std;
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");

        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clr_btn_Click(object sender, EventArgs e)
        {

        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("management_info.aspx");
        }

        protected void res_btn_Click(object sender, EventArgs e)
        {
            Regno_txtbx.Text = "";
            concession_txtbx.Text = "";
        }

        protected void view_btn_Click(object sender, EventArgs e)
        {
            sts_lbl.Visible = false;
            da.SelectCommand = new OleDbCommand("select * from feeconcessionreg where std='" + std_dpdown.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sts_label.Visible = true;
                sts_label.ForeColor = System.Drawing.Color.Red;
                sts_label.Text = "No Students Applied for Concession....";
            }
            else
            {
                view_grid.DataSource = ds;
                view_grid.DataBind();
                sts_label.Visible = false;
            }
        }

        protected void view_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select * from feeconcessionreg where std='" + std_dpdown.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            Regno_txtbx.Text = ds.Tables[0].Rows[0][0].ToString();
            ok_btn.Enabled = true;
        }

        protected void ok_btn_Click(object sender, EventArgs e)
        {

            sts_label.Visible = false;
            GridViewRow gr = view_grid.SelectedRow;
            regno = gr.Cells[1].Text;
            totalfee = gr.Cells[2].Text;
            concessionwant = gr.Cells[3].Text;
            std = gr.Cells[4].Text;
            con.Open();
            da.InsertCommand = new OleDbCommand("insert into feeconselect(regnno,concession,std) values('" + regno + "','" + concessionwant + "','" + std +"')", con);
            sts_lbl.Visible = true;
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Text = "Values Are Stored Into Database";
            da.InsertCommand.ExecuteNonQuery();
            da.UpdateCommand = new OleDbCommand("update schooladmission set sfee='" + concession_txtbx.Text + "'", con);
            da.UpdateCommand.ExecuteNonQuery();
            da.DeleteCommand = new OleDbCommand("Delete from feeconcessionreg where regno='" + Regno_txtbx.Text + "'", con);
            da.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }
    }

    }