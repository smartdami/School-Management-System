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


    public partial class Personal_details : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        string regno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["regno"] != null)
                regno = Request.QueryString["regno"];
            da.SelectCommand = new OleDbCommand("select * from schooladmission where regno='" + regno + "'", con);
            ds.Clear();
            da.Fill(ds);
            disp_pan.Visible = true;
            name_lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            fname_lbl.Text = ds.Tables[0].Rows[0][2].ToString();
            mname_lbl.Text = ds.Tables[0].Rows[0][3].ToString();
            gen_lbl.Text = ds.Tables[0].Rows[0][4].ToString();
            nation_lbl.Text = ds.Tables[0].Rows[0][5].ToString();
            dob_lbl.Text = ds.Tables[0].Rows[0][6].ToString();
            std_lbl.Text = ds.Tables[0].Rows[0][7].ToString();
            community_lbl.Text = ds.Tables[0].Rows[0][8].ToString();
            bg_lbl.Text = ds.Tables[0].Rows[0][9].ToString();
            pstud_lbl.Text = ds.Tables[0].Rows[0][10].ToString();
            cno_lbl.Text = ds.Tables[0].Rows[0][11].ToString();
            hosteller_lbl.Text = ds.Tables[0].Rows[0][12].ToString();
            address_lbl.Text = ds.Tables[0].Rows[0][13].ToString();

        }

      

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }
    }
}
