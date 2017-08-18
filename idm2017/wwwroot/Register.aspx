<%@ Page Title="New Member Registration - Indian Dental Mart" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

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
        <legend>Login or Create an Account</legend>
        <div class="col-1 new-users"><strong>Existing Customers</strong>
          <div class="content">
            <p>If you are already registered with us or already have an account, please login using the link below:</p>
            <div class="buttons-set">
              <button class="button create-account"><span><a href="Login.aspx">Member Login</a></span></button>
            </div>
          </div>
        </div>
        <div class="col-2 registered-users"><strong>New User Registration</strong><br /><br />
          <div class="content">
            <ul class="form-list">
              <li>
                <label for="email">Enter Email Address <span class="required">*</span></label>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" type="text" title="Email Address" CssClass="input-text" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email" ValidationGroup="A" 
           ControlToValidate="txtEmail" CssClass="msg">*</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="reg" runat="server" CssClass="msg" ValidationGroup="A" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
              </li>
              <%--<li>
                <label for="pass">Password <span class="required">*</span></label>
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="input-text" />
              </li>--%>
            </ul>
            <div class="buttons-set">
              <asp:Button ID="btnLogin" runat="server" CssClass="button login" Text="Signup" ValidationGroup="A" />
          </div>
              
              <div>
                  <br /><br />
                  <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
              </div>
              <div>
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" CssClass="msg" />
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

