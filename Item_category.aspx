﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_category.aspx.cs" Inherits="Online_Cosmetics_Shop.Item_category" %>

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
      <title>Item Category</title>
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



       <!-----end 1st---->   <script type="text/javascript" language="javascript">

        function formValidator(){
            // Make quick references to our fields
            var cat_id = document.getElementById("txt_cid");
            var cat_nm = document.getElementById("txt_cnm");

            // Check each input in the order that it appears in the form!
            if(notEmpty(cat_nm,"Name Must be given") && isAlphabet(cat_nm, "Please enter only letters for your name"))
            {
                //if(notEmpty(addr ,"Address Must be given") && isAlphanumeric(addr, "Numbers and Letters Only for Address")){
                    //if(notEmpty(phno,"Phone No Must be given") && validmobile(phno) && isNumeric(phno, "Please enter a valid phone no")){
				
                       // if(notEmpty(email ,"Email Must be given") &&  emailValidator(email, "Please enter a valid email address")){
                           // if(notEmpty(salary ,"Salary Must be given") &&  isNumeric(salary, "Please enter only digit for employee salary")){
                                return true;
                            }
                       // }
                    //}
                //}
           // }
            return false;
        }

        function notEmpty(elem, helperMsg) {

            if (elem.value.length == 0) {
                alert(helperMsg);
                elem.focus(); // set the focus to this input
                return false;
            }
            return true;
        }


        function isNumeric(elem, helperMsg) {
            var numericExpression = /^[0-9]+$/;
            if (elem.value.match(numericExpression)) {
                return true;
            } else {
                elem.value = "";
                alert(helperMsg);
                elem.focus();
                return false;
            }
        }

        function isAlphabet(elem, helperMsg) {
            var alphaExp = /^[a-zA-Z ]+$/;
            if (elem.value.match(alphaExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function isAlphanumeric(elem, helperMsg) {
            var alphaExp = /^[0-9a-zA-Z ]+$/;
            if (elem.value.match(alphaExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function validmobile(elem) {
            var uInput = elem.value;
            if (uInput.length == 10) {
                return true;
            } else {
                alert("Please enter valid mobile Or Phone No");
                elem.value = "";
                elem.focus();
                return false;
            }
        }


        function lengthRestriction(elem, min, max) {
            var uInput = elem.value;
            if (uInput.length >= min && uInput.length <= max) {
                return true;
            } else {
                alert("Please enter between " + min + " and " + max + " characters");
                elem.value = "";
                elem.focus();
                return false;
            }
        }

        function madeSelection(elem, helperMsg) {
            if (elem.value == "Please Choose") {
                alert(helperMsg);
                elem.focus();
                return false;
            } else {
                return true;
            }
        }

        function emailValidator(elem, helperMsg) {
            var emailExp = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
            if (elem.value.match(emailExp)) {
                return true;
            } else {
                alert(helperMsg);
                elem.value = "";
                elem.focus();
                return false;
            }
        }
</script>



    
	

</head>
   <body>
      <!-- header section start -->
      <div class="header_section">
         <div class="container-fluid">
            <nav class="navbar navbar-light bg-light justify-content-between">
               <div id="mySidenav" class="sidenav">
                  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
                  <a href="html/index.html">Log Out</a>
                  <a href="admindashboard.aspx">
                      Dashboard
                  </a>
               </div>
               <span class="toggle_icon" onclick="openNav()"><img src="html/images/toggle-icon.png"></span>
               <a class="logo" href="html/index.html"><img src="html/images/logo.png"></a></a>
               <form class="form-inline ">
                  <div class="login_text">
                     <ul>
                       <!--- <li><a href="#"><img src="html/images/user-icon.png"></a></li>
                        <li><a href="#"><img src="html/images/bag-icon.png"></a></li>
                        <li><a href="#"><img src="html/images/search-icon.png"></a></li>---->
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
      <strong> <h1 align="center"><b>Item Category</b></h1></strong>



       <!----2 nd end--->
  
    <form id="form1" runat="server">
    <div>
         <div class="container"><div class="row"><div class="col-md-12">

        
        <asp:TextBox ID="txt_cid" CssClass="form-control" placeholder="Id" runat="server" Enabled="False"></asp:TextBox>
        <br />
        
        <asp:TextBox ID="txt_cnm" CssClass="form-control" placeholder="Name" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_new" runat="server" CssClass="btn-dark" OnClick="btn_new_Click" Text="New" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_save" runat="server" Enabled="False" CssClass="btn-dark" OnClick="btn_save_Click" Text="Save" OnClientClick="return formValidator()"/>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_update" runat="server" Enabled="False" CssClass="btn-dark" OnClick="btn_update_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_delete" runat="server" Enabled="False" CssClass="btn-dark" OnClick="btn_delete_Click" Text="Delete" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        </div></div></div>
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
