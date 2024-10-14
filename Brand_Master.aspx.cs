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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;
        static string filenm;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
            setGridview();
        }
        public void clearText()
        {
            //txt_bid.Text = "";
            txt_bnm.Text = "";
        }
        public void EnabledText()
        {
            txt_bid.Enabled = false;
            txt_bnm.Enabled = true;
        }
        public void DisableText()
        {
            txt_bid.Enabled = false;
            txt_bnm.Enabled = false;
        }
        public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Brand_Master";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(Brand_id) from Brand_Master";
            Object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
            
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_bid.Text = Convert.ToString(getnewid());
            EnabledText();
            btn_save.Enabled = true;
            btn_new.Enabled = false;

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText="insert into Brand_Master values("+txt_bid.Text+",'"+txt_bnm.Text+"','"+filenm+"')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
            }

            if (flag == 2)
            { 
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText="update Brand_Master set Brand_nm='"+txt_bnm.Text+"',brand_photo='"+filenm+"' where Brand_id="+txt_bid.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
            }
            clearText();
            DisableText();
            setGridview();
            btn_new.Enabled = true;
            btn_save.Enabled = false;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
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
            cmd.CommandText = "Delete from Brand_Master where Brand_id=" + txt_bid.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted");

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
            txt_bid.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_bnm.Text = GridView1.SelectedRow.Cells[2].Text;
            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
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