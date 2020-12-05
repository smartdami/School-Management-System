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
    public partial class book_borrow_return : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        string accsno, bookname, authorname, edition;
        string accs;
        int copies;
        string regno,  std;

        protected void Page_Load(object sender, EventArgs e)
        {
            bdate_txtbx.Text = DateTime.Now.ToString("dd/MM/yyyy");
            retdate_txtbx.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void sub_btn_Click(object sender, EventArgs e)
        {
            if (book_dpdown.Text == "Borrow")
            {
                borrow_pan.Visible = true;
                return_pan.Visible = false;
                da.SelectCommand = new OleDbCommand("select * from addbook where copies>0", con);
                ds.Clear();
                da.Fill(ds);
                book_grid.DataSource = ds;
                book_grid.DataBind();
                
            }
            else
            {
                borrow_pan.Visible = false;
                return_pan.Visible = true;
                regno_validate.Enabled = true;

            }
           
        }

        protected void reset0_btn_Click(object sender, EventArgs e)
        {

            stsret_lbl.Visible = false;
            return_pan.Visible = false;
        }

        protected void view_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            return_btn.Enabled = true;
            ret_val.Enabled = true;
        }

        protected void book_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            borrow_btn.Enabled = true;
            reg_val.Enabled = true;
            date_val.Enabled = true;

        }

        protected void book_dpdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(book_dpdown.SelectedItem.Text=="Borrow")
            {
                reg_val.Enabled = true;
                date_val.Enabled = true;
                return_pan.Visible = false;
            }
            else
            {
                regno_validate.Enabled = true;
               
                borrow_pan.Visible = false;
            }
        }

        protected void close_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }

        protected void borrow_btn_Click(object sender, EventArgs e)
        {
            
            GridViewRow gr = book_grid.SelectedRow;
            accsno = gr.Cells[1].Text;
            bookname = gr.Cells[2].Text;
            authorname = gr.Cells[3].Text;
            edition = gr.Cells[5].Text;
            copies = int.Parse(gr.Cells[6].Text);
            borrow_btn.Enabled = false;
            da.SelectCommand = new OleDbCommand("select * from schooladmission where regno='" + reg_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Please Check the Registration Number";
            }
            else
            {
                string std;
                std = ds.Tables[0].Rows[0][7].ToString();
                da.SelectCommand = new OleDbCommand("select regno,accsno from borrandret where regno='" + reg_txtbx.Text + "' AND accsno='"+accsno+"'", con);
                ds.Clear();
                da.Fill(ds);
             
                

                    if ((ds.Tables[0].Rows.Count==0))
                    {
                    copies = copies - 1;
                    con.Open();
                    da.InsertCommand = new OleDbCommand("insert into borrandret(regno,accsno,bookname,authorname,edition,borrdate,retdate,std) values('" + reg_txtbx.Text + "','" + accsno + "','" + bookname + "','" + authorname + "','" + edition + "','" + bdate_txtbx.Text + "','N/A','" + std + "')", con);
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Green;
                    sts_lbl.Text = "values are Inserted into table";
                    da.InsertCommand.ExecuteNonQuery();
                    da.UpdateCommand = new OleDbCommand("update addbook set copies='" + copies + "' where accsno='" + accsno + "'", con);
                    da.UpdateCommand.ExecuteNonQuery();
                    con.Close();

                }


                    else
                    {
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Red;
                    sts_lbl.Text = "The Selected Book Was Already Taken By The User";
                   
                          
               

                    }


                

            }

            reg_val.Enabled = false;
            date_val.Enabled = false;
    }
           

        
        protected void reset_btn_Click(object sender, EventArgs e)
        {
            borrow_pan.Visible = false;
            sts_lbl.Visible = false;
            da.SelectCommand = new OleDbCommand("select * from addbook where copies>0", con);
            ds.Clear();
            da.Fill(ds);
            book_grid.DataSource = ds;
            book_grid.DataBind();
            reg_txtbx.Text = "";
            bdate_txtbx.Text = "";
            reg_val.Enabled = true;
            

        }

        protected void return_btn_Click(object sender, EventArgs e)
        {

            GridViewRow gr = view_grid.SelectedRow;
            regno = gr.Cells[1].Text;
            accs = gr.Cells[2].Text;
            std = gr.Cells[7].Text;
            con.Open();
            da.UpdateCommand = new OleDbCommand("update borrandret set retdate='" + retdate_txtbx.Text + "' where accsno='" + accs + "' AND regno='" + regno_txtbx.Text + "'", con);
            da.SelectCommand = new OleDbCommand("select copies from addbook where accsno='" + accs + "'", con);
            ds.Clear();
            da.Fill(ds);
            int rcopies = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            rcopies++;
            da.UpdateCommand.ExecuteNonQuery();
            da.UpdateCommand = new OleDbCommand("update addbook set copies=" + rcopies + " where accsno='" + accs + "'", con);
            stsret_lbl.Visible = true;
            stsret_lbl.ForeColor = System.Drawing.Color.Green;
            stsret_lbl.Text = "Values Are Stored Into Database";
            da.UpdateCommand.ExecuteNonQuery();
            return_btn.Enabled = false;
            da.DeleteCommand=new OleDbCommand("delete * from borrandret where accsno='" + accs + "' AND regno='" + regno_txtbx.Text + "'", con);
            da.DeleteCommand.ExecuteNonQuery();
            con.Close();
            ret_val.Visible = false;
        }
            protected void regok_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select regno,accsno,bookname,authorname,edition,borrdate,std from borrandret where regno='" + regno_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                view_grid.DataSource = ds;
                view_grid.DataBind();
                st_lbl.Visible = false;
            }
            else
            {
                st_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Green;
                st_lbl.Text = "You have not Borrowed Any Books to return";
            }
            
        }

        

        
    }
}