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
    public partial class lib_addnewbook : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("Select accsno from addbook", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                con.Open();
                da.InsertCommand = new OleDbCommand("insert into addbook(accsno,bookname,authorname,category,edition,copies) values('" + accessionno_txtbx.Text + "','" + bname_txtbx.Text + "','" + authorname_txtbx.Text + "','" + category_txtbx.Text + "'," + edition_txtbx.Text + "," + copies_txtbx.Text + ")", con);
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Green;
                sts_lbl.Text = "Book Added Into Database....";
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Enter Different Accession No";
            }
        }

        protected void clear_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("lib_addnewbook.aspx");
        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("management_info.aspx");
        }
    }
}