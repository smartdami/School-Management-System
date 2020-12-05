using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Management_System
{
    public partial class management_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reg_student_Selection_List.aspx");
        }

        protected void con_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeeConcessionSelection.aspx");
        }

        protected void lib_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("lib_addnewbook.aspx");
        }

        protected void r_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewRoom.aspx");
        }

        protected void room_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoomDetail.aspx");
        }

        protected void log_btn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Management_login.aspx");
        }
    }
}