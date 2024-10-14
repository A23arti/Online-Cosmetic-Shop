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
    public partial class Item_category : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        static int flag = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();
            setGridview();
        }
        public void clearText()
        {
            //txt_cid.Text = "";
            txt_cnm.Text="";
        }
        public void EnabledText()
        {
            txt_cid.Enabled = false;
            txt_cnm.Enabled = true;
        }
        public void DisableText()
        {
            txt_cid.Enabled = false;
            txt_cnm.Enabled = false;
        }
        public void setGridview()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Item_Category";
            dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
        }
        public int getnewid()
        {
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Select Max(cat_id) from Item_Category";

            Object x = cmd.ExecuteScalar();
            if (Convert.ToString(x) == "")
                return 1;
            else
                return (Convert.ToInt32(x) + 1);
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            flag = 1;
            txt_cid.Text = Convert.ToString(getnewid());
            EnabledText();
            btn_new.Enabled = false;
            btn_save.Enabled = true;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Item_Category values(" + txt_cid.Text + ",'" + txt_cnm.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
            }

            if (flag == 2)
            {
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "update Item_Category set cat_nm='"+txt_cnm.Text+"' where cat_id="+txt_cid.Text;
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

        protected void btn_update_Click(object sender, EventArgs e)
        {
            flag= 2;
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
            cmd.CommandText = "Delete from Item_Category where cat_id="+txt_cid.Text;
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
            txt_cid.Text = GridView1.SelectedRow.Cells[1].Text;
            txt_cnm.Text = GridView1.SelectedRow.Cells[2].Text;

            btn_new.Enabled = false;
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            btn_delete.Enabled = true;
        }


    }
}