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
    public partial class Schoolresult : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");

        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    

        protected void view_grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Res_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select * from marksupdate where regno='" + res_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count==0)
            {
                Label15.Visible = true;
                view_grid.Visible = false;
                Label15.ForeColor = System.Drawing.Color.Red;
                Label15.Text = "Enter Correct Register Number";
            }
            else
            {
                view_grid.Visible = true;
                Label15.Visible = false;
                view_grid.DataSource = ds;
                view_grid.DataBind();
            }
           
        }

     

      

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }
    }
}