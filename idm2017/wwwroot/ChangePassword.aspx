<%@ Page Title="Change Password" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
        <div class="page-title">
          <h1>Update Password</h1>
        </div>
        <ol class="one-page-checkout" id="checkoutSteps">
          <li id="opc-billing" class="section allow active">
            <div id="checkout-step-billing" class="step a-item">
                <fieldset class="group-select">
                  <ul>
                    <li id="billing-new-address-form">
                      <fieldset>
                        <ul>
                             <li>
                                <label style="color:yellowgreen;"> Enter Current Password<span class="required">*</span></label>
                                <br />
                                <asp:TextBox ID="txtOldPassword" runat="server" title="First Name" CssClass="input-text" TextMode="Password" />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Old Password" ValidationGroup="A" 
           ControlToValidate="txtOldPassword" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                          <li>
                                <label> Enter New Password<span class="required">*</span></label>
                                <br />
                                <asp:TextBox ID="txtPassword" runat="server" title="First Name" CssClass="input-text" TextMode="Password" />
                               <asp:RequiredFieldValidator ID="rq1" runat="server" ErrorMessage="Enter Password" ValidationGroup="A" 
           ControlToValidate="txtPassword" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                          <li>
                            <label>Re-Enter Password <span class="required">*</span></label>
                            <br />
                            <asp:TextBox ID="txtPassword2" runat="server" title="Address" CssClass="input-text" TextMode="Password" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Re-Enter Password" ValidationGroup="A" 
           ControlToValidate="txtPassword2" CssClass="msg">*</asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password should match" CssClass="msg" Text="*" ValidationGroup="A" ControlToValidate="txtPassword" ControlToCompare="txtPassword2" Operator="Equal"></asp:CompareValidator>
                          </li>
                          <li>
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" CssClass="msg" />
                          </li>
                        </ul>
                      </fieldset>
                    </li>
                  </ul>
                  <asp:Button ID="btnUpdate" runat="server" CssClass="button continue" Height="50px" Width="150px" BackColor="#ED5565" Text="Update" ValidationGroup="A" />
                </fieldset>
            </div>
          </li>
        </ol>
      </div>
     <aside class="col-right sidebar col-sm-3">
        <div class="block block-account">
          <div class="block-title">My Account</div>
          <div class="block-content">
            <ul>
              <li><a href="Dashboard.aspx">Account Dashboard</a></li>
              <li><a href="MyProfile.aspx">Account Information</a></li>
                <li class="current"><a href="ChangePassword.aspx">Change Password</a></li>
              <li><a href="MyAddressBook.aspx">Address Book</a></li>
              <li class="last"><a href="MyWishlist.aspx">My Wishlist</a></li>
            </ul>
          </div>
        </div>
      </aside>
    </div>
  </div>
</section>
<!-- Main Container end --> 
</asp:Content>



