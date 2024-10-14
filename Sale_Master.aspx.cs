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
    public partial class Sale_Master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
       // static int flag = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
            //setGridview();
            txt_sid.Text = Convert.ToString(getnewid());
            if (!IsPostBack)
                setdropdown();
        }

        public void clearText()
        {
            txt_sdate.Text = "";
            txt_tamt.Text = "";
            txt_gamt.Text = "";
            txt_gtot.Text = "";

        }
        
       /* public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Sale_Master";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();

        }*/
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(sale_id) from Sale_Master";

            Object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);

        }
        public void setdropdown()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Customer";
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataTextField = "cust_nm";
            DropDownList1.DataValueField = "cust_id";
            DropDownList1.DataBind();
            dr.Close();

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Sale_Master values("+txt_sid.Text+","+DropDownList1.SelectedValue+",'"+txt_sdate.Text+"',"+txt_tamt.Text+","+txt_gamt.Text+","+txt_gtot.Text+")";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted");
            clearText();
           // setGridview();
        }

       /* protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_sid.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_sdate.Text = GridView1.SelectedRow.Cells[2].Text;
            txt_tamt.Text = GridView1.SelectedRow.Cells[3].Text;
            txt_gamt.Text = GridView1.SelectedRow.Cells[4].Text;
            txt_gtot.Text = GridView1.SelectedRow.Cells[5].Text;

            btn_delete.Enabled = true;
            
        }*/

       /* protected void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete from Sale_Master where sale_id=" + txt_sid.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data deleted");

            btn_save.Enabled = true;
            setGridview();
        }*/

       
        

        

        
    }
}