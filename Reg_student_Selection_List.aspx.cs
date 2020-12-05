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
    public partial class Reg_student_Selection_List : System.Web.UI.Page
    {
        
        string sname, fname, mname, gen, nation, dob, std, community, religion, bgroup, prevstudied, contactno,status, address, applyhostel,mail,pass;

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("management_info.aspx");
        }

        protected void Reset_btn_Click(object sender, EventArgs e)
        {
            sts_lbl.Visible = false;
            efee_txtbx.Text = "";
            lfee_txtbx.Text = "";
            sfee_txtbx.Text = "";
            regno_txtbx.Text = "";
            admit_btn.Enabled = false;
        }

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbConnection feecon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        DataSet dselect = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void view_btn_Click(object sender, EventArgs e)
        {
            
            da.SelectCommand = new OleDbCommand("select * from schoolreg where standard='" + std_dpdown.Text + "'",con);
            ds.Clear();
            da.Fill(ds);
            view_grid.DataSource = ds;
            view_grid.DataBind();
           
            regno_rq.Enabled = true;
        }

        protected void view_grid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
            da.SelectCommand = new OleDbCommand("select sfee,efee,libfee from sefee where std='" +std_dpdown.Text + "'", feecon);
            dselect.Clear();
            da.Fill(dselect);
            sfee_txtbx.Text = dselect.Tables[0].Rows[0][0].ToString();
            efee_txtbx.Text = dselect.Tables[0].Rows[0][1].ToString();
            lfee_txtbx.Text= dselect.Tables[0].Rows[0][2].ToString();
            admit_btn.Enabled = true;

        }

        protected void admit_btn_Click(object sender, EventArgs e)
        {
           
            da.SelectCommand = new OleDbCommand("select * from schooladmission where regno='" + regno_txtbx.Text + "'",con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                sts_lbl.Text = "Register Number Already Exists....";
            }
            else
            {
                status = "NotPaid";
                GridViewRow gr = view_grid.SelectedRow;
                sname = gr.Cells[1].Text;
                fname= gr.Cells[2].Text;
                mname = gr.Cells[3].Text;
                gen = gr.Cells[4].Text;
                nation = gr.Cells[5].Text;
                dob = gr.Cells[6].Text;
                std = gr.Cells[7].Text;
                community = gr.Cells[8].Text;
                religion = gr.Cells[9].Text;
                bgroup = gr.Cells[10].Text;
                prevstudied = gr.Cells[11].Text;
                contactno = gr.Cells[12].Text;
                applyhostel = gr.Cells[13].Text;
                address = gr.Cells[14].Text;
                mail = gr.Cells[15].Text;
                pass = gr.Cells[16].Text;
                con.Open();
               da.InsertCommand=new OleDbCommand("insert into schooladmission(regno,sname,fname,mname,gender,nationality,dob,standard,community,religion,bgroup,prevstudied,contactno,address,sfee,status,email,pass) values('" + regno_txtbx.Text + "','" + sname + "','" + fname + "','" + mname + "','" + gen + "','" + nation + "','" + dob + "','" + std + "','" + community + "','" + religion + "','" + bgroup + "','" + prevstudied + "','" + contactno + "','" + address + "','" + sfee_txtbx.Text + "','" + status + "','" + mail + "','" + pass + "')", con);
                da.InsertCommand.ExecuteNonQuery();
                sts_lbl.Visible = true;
                sts_lbl.Text = "Values Are Stored Into Database";
                con.Close();
                feecon.Open();
                da.InsertCommand = new OleDbCommand("insert into libraryfee(regno,sname,lfee,status,standard) values('" + regno_txtbx.Text + "','" + sname + "','" + lfee_txtbx.Text + "','NotPaid','" + std + "')", feecon);
                da.InsertCommand.ExecuteNonQuery();
                da.InsertCommand = new OleDbCommand("insert into examfee(regno,sname,efee,status,std) values('" + regno_txtbx.Text + "','" + sname + "','" + efee_txtbx.Text + "','NotPaid','" + std + "')", feecon);
                da.InsertCommand.ExecuteNonQuery();
                feecon.Close();
               

            }
        }
    }
}