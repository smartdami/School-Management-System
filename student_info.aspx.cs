using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School_Management_System
{

    public partial class student_info : System.Web.UI.Page
    {
        string regno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["regno"] != null)
                regno = Request.QueryString["regno"];
        }

        protected void pinfo_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_details.aspx?regno=" +regno,false);
        }

        protected void res_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schoolresult.aspx");
        }

        protected void br_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("book_borrow_return.aspx");
        }

        protected void bodafied_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("BonafiedcertificateGen.aspx");
        }

        protected void leave_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveForm_Generation.aspx");
        }

        protected void fee_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeeStructure.aspx");
        }

        protected void log_btn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Student_login.aspx");
        }
    }
}