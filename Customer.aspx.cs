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
    public partial class Customer : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
           // setGridview();
            txt_csid.Text=Convert.ToString(getnewid());
            
        }
        public void clearText()
        {
          //  txt_csid.Text = "";
            txt_csnm.Text="";
            txt_csaddr.Text = "";
            txt_phono.Text = "";
            txt_email.Text = "";
            txt_cspass.Text = "";
        }
        /*public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Customer";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }*/
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(cust_id) from Customer";

            Object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Customer values("+txt_csid.Text+",'"+txt_csnm.Text+"','"+txt_csaddr.Text+"','"+txt_phono.Text+"','"+txt_email.Text+"','"+txt_cspass.Text+"')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted");
            clearText();
            Response.Redirect("~/Search/Customer_dashboard.aspx");
            
        }

        
    }
}