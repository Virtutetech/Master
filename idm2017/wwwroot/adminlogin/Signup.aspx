<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Signup.aspx.vb" Inherits="Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IndianDentalMart | Sign Up</title>
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Dental Products" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
 <!-- Bootstrap Core CSS -->
<link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
<!-- Custom CSS -->
<link href="css/style.css" rel='stylesheet' type='text/css' />
<!-- Graph CSS -->
<link href="css/font-awesome.css" rel="stylesheet" /> 
<!-- jQuery -->
<!-- lined-icons -->
<link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
<!-- //lined-icons -->
<!-- chart -->
<script src="js/Chart.js"></script>
<!-- //chart -->
<!--animate-->
<link href="css/animate.css" rel="stylesheet" type="text/css" media="all" />
<script src="js/wow.min.js"></script>
	<script>
		 new WOW().init();
	</script>
<!--//end-animate-->
<!----webfonts--->
<link href='//fonts.googleapis.com/css?family=Cabin:400,400italic,500,500italic,600,600italic,700,700italic' rel='stylesheet' type='text/css' />
<!---//webfonts---> 
 <!-- Meters graphs -->
<script src="js/jquery-1.10.2.min.js"></script>
<!-- Placed js at the end of the document so the pages load faster -->
</head>
<body class="sign-in-up">
    <form id="form1" runat="server">
     <section>
			<div id="page-wrapper" class="sign-in-wrapper">
				<div class="graphs">
					<div class="sign-in-form">
						<div class="sign-in-form-top">
							<p><span>Sign In to</span> <a href="Default.aspx">Admin</a></p>
						</div>
						<div class="signin">
							
							<div class="log-input">
								<div class="log-input-left">
								   <asp:TextBox ID="txtUsername" runat="server" CssClass="user" Text="Email address:" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email address:';}" />
								</div>
								<span class="checkbox2">
									<asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
								</span>
								<div class="clearfix"> </div>
							</div>
							<div class="log-input">
								<div class="log-input-left">
								   <asp:TextBox ID="txtPassword" runat="server" CssClass="lock" value="password" TextMode="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email address:';}"/>
								</div>
								<span class="checkbox2">
									<asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
								</span>
								<div class="clearfix"> </div>
							</div>
							<asp:Button ID="btnSubmit" runat="server" type="submit" Text="Signup" />
						</div>
						<div class="new_people">
							<a href="Login.aspx">Back to Member Login</a>
						</div>
					</div>
				</div>
			</div>
		<!--footer section start-->
			<footer>
			   <p>&copy 2017 Indian Dental Mart. All Rights Reserved | Design by <a href="https://www.ZingerGlobal.com/" target="_blank">Zinger Global Services.</a></p>
			</footer>
        <!--footer section end-->
	</section>
	
<script src="js/jquery.nicescroll.js"></script>
<script src="js/scripts.js"></script>
<!-- Bootstrap Core JavaScript -->
   <script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>
