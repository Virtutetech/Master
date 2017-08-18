<%@ Page Title="Forgot Password - Indian Dental Mart" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="ForgotPassword.aspx.vb" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Main Container -->
<section class="main-container col1-layout">
  <div class="main container">
    <div class="account-login">
      <div class="page-title">
        <h2>Login or Create an Account</h2>
      </div>
      <fieldset class="col2-set">
        <div class="col-1 new-users"><strong>New Customers</strong>
          <div class="content">
            <p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
            <div class="buttons-set">
              <button class="button create-account"><span><a href="Register.aspx">Create an Account</a></span></button>
            </div>
          </div>
            <br /><br /><br />
            <strong>Member Login</strong>
          <div class="content">
            <p>If you are already registered with us or already have an account, please login using the link below:</p>
            <div class="buttons-set">
              <button class="button create-account"><span><a href="Login.aspx">Member Login</a></span></button>
            </div>
          </div>
        </div>
        <div class="col-2 registered-users"><strong>Enter your Email to Recover Password</strong><br /><br />
          <div class="content">
            <ul class="form-list">
              <li>
                <label for="email">Enter Email Address <span class="required">*</span></label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" type="text" title="Email Address" CssClass="input-text" />
              </li>
              <%--<li>
                <label for="pass">Password <span class="required">*</span></label>
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input-text" />
              </li>--%>
            </ul>
            <div class="buttons-set">
              <asp:Button ID="btnLogin" runat="server" CssClass="button login" Text="Submit" />
          </div>
              <div>
                  <br /><br />
                  <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
              </div>
              </div>
        </div>
      </fieldset>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
  </div>
</section>
<!-- Main Container End -->
</asp:Content>

