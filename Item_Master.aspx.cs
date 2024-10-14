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
    public partial class Item_Master : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr1;
        static int flag = 0;
        static String filenm = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
            
            setGridview();

            if (!IsPostBack)
            {
                setdropdown();
                setdropdown1();
            }

            
                
        }
        public void clearText()
        {
            txt_iid.Text = "";
            txt_inm.Text = "";

            txt_rate.Text = "";
            txt_quan.Text = "";
            //txt_photo.Text = "";
        }
        public void EnabledText()
        {
            //txt_iid.Enabled = true;
            txt_inm.Enabled = true;

            txt_rate.Enabled = true;
            txt_quan.Enabled = true;
            //txt_photo.Enabled = true;
        }
        public void DisableText()
        {
            txt_iid.Enabled = false;
            txt_inm.Enabled = false;

            txt_rate.Enabled = false;
            txt_quan.Enabled = false;
            //txt_photo.Enabled = false;
        }
        public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Item_Master";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(Item_id) from Item_Master";
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
            cmd.CommandText = "Select * from Brand_Master";
            dr = cmd.ExecuteReader();
            DropDownList2.DataSource = dr;
            DropDownList2.DataTextField = "brand_nm";
            DropDownList2.DataValueField = "brand_id";
            DropDownList2.DataBind();
            dr.Close();
           /* cmd.CommandText = "Select * from Item_Category";
            dr = cmd.ExecuteReader();
            
            DropDownList1.DataSource = dr;
            DropDownList1.DataTextField = "cat_nm";
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataBind();*/
        }
       public void setdropdown1()
        {
            cmd = new SqlCommand();
            cmd.Connection=cn;
            cmd.CommandText = "Select * from Item_Category";
            dr1 = cmd.ExecuteReader();
            DropDownList1.DataSource = dr1;
            DropDownList1.DataTextField = "cat_nm";
            DropDownList1.DataValueField = "cat_id";
            DropDownList1.DataBind();
            dr1.Close();
        }



        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_iid.Text = Convert.ToString(getnewid());
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            flag = 2;
            EnabledText();
            btn_save.Enabled = true;
            btn_new.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete from Item_Master where item_id=" + txt_iid.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data deleted");

            clearText();
            DisableText();
            setGridview();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_iid.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_inm.Text = GridView1.SelectedRow.Cells[2].Text;
            DropDownList2.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[4].Text;
            txt_rate.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_quan.Text = GridView1.SelectedRow.Cells[6].Text;
           // txt_photo.Text = GridView1.SelectedRow.Cells[4].Text;

            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }

        protected void btn_save_Click1(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Item_Master values (" + txt_iid.Text + ",'" + txt_inm.Text + "'," + DropDownList2.SelectedValue + ", " + DropDownList1.SelectedValue + "," + txt_rate.Text + "," + txt_quan.Text + ",'" + filenm + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
            }

            if (flag == 2)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Item_Master set item_nm='" + txt_inm.Text + "', brand_id=" + DropDownList2.SelectedValue + ",cat_id=" + DropDownList1.SelectedValue + ", rate=" + txt_rate.Text + ", qty=" + txt_quan.Text + " , photo='" + filenm + "' where item_id=" + txt_iid.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated");
            }

            clearText();
            DisableText();
            setGridview();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        protected void btn_show_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true)
            {
                string basedir = Server.MapPath("~/Upload/");
                filenm = FileUpload1.FileName;
                FileUpload1.SaveAs(basedir + FileUpload1.FileName);
                Image1.ImageUrl = "~/Upload//" + FileUpload1.FileName;

            }
            else
            {
                MessageBox.Show("You must Select Photos");
            }
        }
    }
}
        


     