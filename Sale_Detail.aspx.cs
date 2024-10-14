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
    public partial class Sale_Detail : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr1;
        //static int flag = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
           // setGridview();
            txt_sdid.Text = Convert.ToString(getnewid());
            if (!IsPostBack)
            {
                setdropdown();
                setdropdown1();
            }
        }
        public void clearText()
        {
           // txt_sdid.Text = "";
            txt_rate.Text = "";
            txt_qty.Text = "";
            txt_amt.Text = "";
        }
        /*public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Sale_Details";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }*/
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(sale_det_id) from Sale_Details";

            Object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }
        public void setdropdown()
        {
            cmd=new SqlCommand();
            cmd.Connection=cn;
            cmd.CommandText="Select * from Sale_Master";
            dr=cmd.ExecuteReader();
            DropDownList1.DataSource=dr;
            DropDownList1.DataTextField="sale_date";
            DropDownList1.DataValueField="sale_id";
            DropDownList1.DataBind();
            dr.Close();
        }
        public void setdropdown1()
        {
            cmd=new SqlCommand();
            cmd.Connection=cn;
            cmd.CommandText="Select * from Item_Master";
            dr1=cmd.ExecuteReader();
            DropDownList2.DataSource=dr1;
            DropDownList2.DataTextField="item_nm";
            DropDownList2.DataValueField="item_id";
            DropDownList2.DataBind();
            dr1.Close();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Sale_Details values("+txt_sdid.Text+","+DropDownList1.SelectedValue+","+DropDownList2.SelectedValue+","+txt_rate.Text+","+txt_qty.Text+","+txt_amt.Text+")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("data inserted");

            clearText();
            
        }

        
    }
}