using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Online_Cosmetics_Shop
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_uname.Text == "admin" && txt_pass.Text == "123")
            {
                MessageBox.Show(" Login successfully");
                Response.Redirect("~/admindashboard.aspx");
            }
            else
                MessageBox.Show(" Login unsuccessfully");
        }

        
    }
}