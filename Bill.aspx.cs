using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace Online_Cosmetics_Shop
{
    public partial class Bill : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        string cust_id, cust_fnm, cust_lnm, cust_shipping_addr, cust_billing_addr, cust_city, cust_pincode, cust_mobile, cust_email, Sale_id, date, total, gst, grandtot;


        ArrayList itennmlist = new ArrayList();
        ArrayList Sale_det_id_list = new ArrayList();
        ArrayList rate_list = new ArrayList();
        ArrayList qty_list = new ArrayList();
        ArrayList amt_list = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-L0SVT00\\SQLEXPRESS02;Initial Catalog=cosmeticDB;Integrated Security=True";
            cn.Open();


            String ord_id = Convert.ToString(Session["ordid"]);


            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "select cust_nm,cust_addr,cust_phno,cust_email,cust_pass,item_master.item_nm,sale_details.rate,sale_details.sale_det_id,sale_details.qty,sale_details.amt,sale_master.sale_date from sale_details,item_master,customer ,sale_master where sale_master.sale_id=sale_details.sale_id and sale_details.item_id=item_master.item_id and sale_master.cust_id=customer.cust_id and sale_master.sale_id="+ord_id;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //cust_id = dr[1].ToString();
                cust_fnm = dr[0].ToString();
                //cust_lnm = dr[4].ToString();
                //cust_shipping_addr = dr[5].ToString();
                cust_billing_addr = dr[1].ToString();
                //cust_city = dr[7].ToString();
                // cust_pincode = dr[8].ToString();
                cust_mobile = dr[2].ToString();
                cust_email = dr[3].ToString();
                //Sale_id = dr[11].ToString();
                date = dr[10].ToString();
                total = Convert.ToString(Session["total"]);
                gst = Convert.ToString(Session["gst"]);
                grandtot = Convert.ToString(Session["grand"]);

                itennmlist.Add(dr[5].ToString());
                Sale_det_id_list.Add(dr[7].ToString());
                rate_list.Add(dr[6].ToString());
                qty_list.Add(dr[8].ToString());
                amt_list.Add(dr[9].ToString());
            }
            dr.Close();
            PlaceHolder1.Controls.Add(new LiteralControl("<table width='600px' align='center'>" +
   " <tr>" +
       " <td class='auto-style2' colspan='5' style='font-size: x-large; background-color: #006699; color: #FFFFFF;'>&nbsp;&nbsp;<img src='html/images/logo.png' style='color: #FF9900' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cosmetic Products Invoice&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
       " <td colspan='5' style='background-color: #FF9999'>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
       " <td rowspan='5'>Bill To:<br />" +
            "" + cust_fnm + "<br />" +
           " " + cust_billing_addr + "<br />" +
            "" + cust_mobile + "<br />" +
           "" + cust_email + "<br/>" +
             "<b>Bill Date :   </b>" + System.DateTime.Now.ToString() + "<br/>" +
          " <td colspan='4'><img src='img1.jpeg' style='width: 328px; height: 146px; margin-left: 24px;'/></td>"+
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>" +
    "<tr>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
        "<td>&nbsp;</td>" +
    "</tr>"));





            PlaceHolder1.Controls.Add(new LiteralControl("<tr>" +
                "<td style='background-color: #FF9999; text-align: center;'>Sr.No</td>" +
                "<td style='background-color: #FF9999; text-align: center;'>Item Name</td>" +
                "<td style='background-color: #FF9999; text-align: center;'>Rate</td>" +
                "<td style='background-color: #FF9999; text-align: center;'>Quantity</td>" +
                "<td style='background-color: #FF9999; text-align: center;'>Amount</td>" +
            "</tr>" ));
                  for (int i = 0; i <= Sale_det_id_list.Count - 1; i++)
            {
                PlaceHolder1.Controls.Add(new LiteralControl("<tr>" +
                "<td style='text-align: center'>" + Sale_det_id_list[i] + "</td>" +
                "<td style='text-align: center'>" + itennmlist[i] + "</td>" +
                "<td>" + rate_list[i] + "</td>" +
                "<td>" + qty_list[i] + "</td>" +
                "<td>" + amt_list[i] + "</td>" +
            "</tr>"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>GST (18%)</td>" +
                "<td>&nbsp;</td>" +
                "<td>"+gst+"</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
               "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>Total Amount</td>" +
                "<td>&nbsp;</td>" +
                "<td>"+grandtot+"</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td colspan='5'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thank You For Your Order&nbsp;!</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td colspan='3' rowspan='3'>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<img src='1206px-XXXTentacion_signature.svg.png' align='center' style='width: 125px; height: 50px'/></td>" +
            "</tr>" +
            "<tr>" +
                "<td>Rajarampuri,Kolhapur</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>beautiflie@gmail.com</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>7689887650</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td style='text-align: center'>Signature</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
            "<tr>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
                "<td>&nbsp;</td>" +
            "</tr>" +
        "</table>"));
                dr.Close();
            }
        }
    }
