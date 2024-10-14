using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Cosmetics_Shop
{
    public partial class User_Login : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
            
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            cmd=new SqlCommand();
            cmd.Connection=cn;
            cmd.CommandText="Select * from Customer where cust_email='"+txt_email.Text+"' and cust_pass='"+txt_pass.Text+"' ";
            dr=cmd.ExecuteReader();
            if (dr.Read())
            {
               // MessageBox.Show("Login successfully");
                Session["cid"] = dr[0];
                Session["cnm"] = dr[1];
                Response.Redirect("~/Search/Customer_dashboard.aspx");
            }
            else
                MessageBox.Show("Login unsuccessfully");

        }
    }
}