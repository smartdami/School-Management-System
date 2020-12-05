using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Management_System
{
    public partial class LeaveForm_Generation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Print_btn_Click(object sender, EventArgs e)
        {
            sts_lbl.Visible = true;
            sts_lbl.ForeColor = System.Drawing.Color.Green;
            sts_lbl.Text = "Leave Application Submitted to the Principle Desk";
        }

      
        protected void can_btn_Click(object sender, EventArgs e)
        {
            sts_lbl.Visible = false;
            reg_txtbx.Text = "";
            leavedays_txtbx.Text = "";
            leave_dpdown.Text = "";
            reg_txtbx.Text = "";
            to_leave_txtbx.Text = "";
            reason_txtbx.Text = "";
            fromleave_txtbx.Text = "";
        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("student_info.aspx");
        }
    }
}