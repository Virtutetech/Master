<%@ Page Title="Order Success" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="Success.aspx.vb" Inherits="Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main Container -->
<section class="content-wrapper">
  <div class="container">
    <div class="std">
      <div class="page-not-found">
        <h2>Success</h2>
        <h3><img src="images/succes.png" alt="success image" />Your order has been placed successfully.<br />Your Order NO is: <span style="color:red;">123</span></h3>
        <div><a href="UserHome.aspx" class="btn-home"><span>Continue Shopping</span></a></div>
      </div>
    </div>
  </div>
</section>
<!-- Main Container End --> 
</asp:Content>

