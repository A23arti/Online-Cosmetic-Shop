<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admindashboard.aspx.cs" Inherits="Online_Cosmetics_Shop.admindashboard" %>

<!DOCTYPE html>
<html lang="en">
   <head>
      <!-- basic -->
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <!-- mobile metas -->
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="viewport" content="initial-scale=1, maximum-scale=1">
      <!-- site metas -->
      <title>Admin Login</title>
      <meta name="keywords" content="">
      <meta name="description" content="">
      <meta name="author" content="">
      <!-- bootstrap css -->
      <link rel="stylesheet" type="text/css" href="html/css/bootstrap.min.css">
      <!-- style css -->
      <link rel="stylesheet" type="text/css" href="html/css/style.css">
      <!-- Responsive-->
      <link rel="stylesheet" href="html/css/responsive.css">
      <!-- fevicon -->
      <link rel="icon" href="html/images/fevicon.png" type="image/gif" />
      <!-- Scrollbar Custom CSS -->
      <link rel="stylesheet" href="css/jquery.mCustomScrollbar.min.css">
      <!-- Tweaks for older IEs-->
      <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">
      <!-- fonts -->
      <link href="https://fonts.googleapis.com/css?family=Great+Vibes|Open+Sans:400,700&display=swap&subset=latin-ext" rel="stylesheet">
      <!-- owl stylesheets --> 
      <link rel="stylesheet" href="html/css/owl.carousel.min.css">
      <link rel="stylesheet" href="html/css/owl.theme.default.min.css">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen">
      <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />



       <!-----end 1st---->

    
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
   <body>
      <!-- header section start -->
      <div class="header_section">
         <div class="container-fluid">
            <nav class="navbar navbar-light bg-light justify-content-between">
               <div id="mySidenav" class="sidenav">
                  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
                   <a href="../html/index.html">Home</a>
                  <!----<a href="products.html">Products</a>
                  <a href="about.html">About</a>
                  <a href="client.html">Client</a>
                  <a href="contact.html">Contact</a>---->
               </div>
               <span class="toggle_icon" onclick="openNav()"><img src="html/images/toggle-icon.png"></span>
               <a class="logo" href="html/index.html"><img src="html/images/logo.png"></a></a>
               <form class="form-inline ">
                  <div class="login_text">
                     <ul>
                        <li><a href="../html/index.html" style="color:black"><!----<img src="../html/images/user-icon.png">--->Log Out</a></li>
                        <li><a href="#"><!---<img src="html/images/bag-icon.png">---></a></li>
                        <li><a href="#"><img src="html/images/search-icon.png"></a></li>
                     </ul>
                  </div>
               </form>
            </nav>
         </div>
      </div>
      <!-- header section end -->
      <!-- contact section start -->
       <br />
        <br /> <br /> <br /> 
      <strong> <h1 align="center"><b>Admin Dashboard</b></h1></strong>



       <!----2 nd end--->
        <br /> <br /> <br /> 
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td style="font-weight: 700; text-align: center">Manage</td>
                <td style="font-weight: 700; text-align: center">List Report</td>
                <td style="font-weight: 700; text-align: center">Dynamic Report</td>
                <td style="font-weight: 700; text-align: center">Datewise Report</td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Brand_Master.aspx">Brand Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Report/frm_BrandMaster.aspx">Brand Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Report/Brandmaster_wise_itemmaster.aspx">Brand Master wise Item Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/Report/datewise_SaleMaster.aspx">Date wise Sale Master</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Item_category.aspx">Item Category</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Report/frm_ItemCategory.aspx">Item Category</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Report/ItemCategory_wise_ItemMaster.aspx">Item Category wise Item Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/Report/datewise_Receipt.aspx">Date wise Receipt</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Item_Master.aspx">Item Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Report/frm_Item_master.aspx">Item Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Report/Customer_wise_SaleMaster.aspx">Customer wise Sale Master</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center">
                    &nbsp;</td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Report/frm_SaleMaster.aspx">Sale Master</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Report/SaleMaster_wise_SaleDetails.aspx">Sale Master wise Sale Detail</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center">
                    &nbsp;</td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Report/frm_Sale_Detail.aspx">Sale Details</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Report/ItemMaster_wise_SaleDetails.aspx">Item Master wise Sale Details</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center">
                    &nbsp;</td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Report/frm_Customer.aspx">Customer</asp:HyperLink>
                </td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Report/Customer_wise_Receipt.aspx">Customer wise Receipt</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center">
                    &nbsp;</td>
                <td class="text-center">
                    <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Report/frm_Receipt.aspx">Receipt</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
<!-------3rd start---->

     
       
       
        <!-- contact section end -->
  
  
      <!-- Javascript files-->
      <script src="html/js/jquery.min.js"></script>
      <script src="html/js/popper.min.js"></script>
      <script src="html/js/bootstrap.bundle.min.js"></script>
      <script src="html/js/jquery-3.0.0.min.js"></script>
      <script src="html/js/plugin.js"></script>
      <!-- sidebar -->
      <script src="html/js/jquery.mCustomScrollbar.concat.min.js"></script>
      <script src="html/js/custom.js"></script>
      <!-- javascript --> 
      <script src="html/js/owl.carousel.js"></script>
      <script src="https:cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>  
      <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
      <script>
          function openNav() {
              document.getElementById("mySidenav").style.width = "100%";
          }

          function closeNav() {
              document.getElementById("mySidenav").style.width = "0";
          }
      </script> 
   </body>
</html>
<!---3 rdend--->