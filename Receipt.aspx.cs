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
    public partial class Receipt : System.Web.UI.Page
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
            txt_rid.Text = Convert.ToString(getnewid());
            TextBox1.Text = Convert.ToString(Session["cnm"]);
            txt_rdate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            txt_ramt.Text = Convert.ToString(Session["grand"]);
            
        }
        public void clearText()
        {
            //txt_rid.Text = "";
            txt_rdate.Text = "";
            txt_ramt.Text="";

        }
       /* public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Receipt";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }*/
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(Rec_id) from Receipt";

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
            cmd.CommandText = "insert into Receipt values("+txt_rid.Text+",'"+txt_rdate.Text+"',"+Session["cid"]+","+txt_ramt.Text+")";
            cmd.ExecuteNonQuery();
            
    
            if (RadioButton1.Checked == true)
            {
                MessageBox.Show("Order Recived");
                Response.Redirect("~/html/index.html");
            }
            if (RadioButton2.Checked == true)
            {
                Response.Redirect("~/Bill.aspx");
            }
           // setGridview();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            TextBox2.Enabled = true;
            btn_save.Enabled = true;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
        }

       /* protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rid.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_rdate.Text = GridView1.SelectedRow.Cells[2].Text;
            txt_ramt.Text = GridView1.SelectedRow.Cells[3].Text;
        }*/
    }
}