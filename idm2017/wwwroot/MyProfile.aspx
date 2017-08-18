<%@ Page Title="My Account Information" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="MyProfile.aspx.vb" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
        <div class="page-title">
          <h1>My Profile</h1>
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
                                <label> Name<span class="required">*</span></label>
                                <br />
                                <asp:TextBox ID="txtName" runat="server" title="First Name" CssClass="input-text" />
                               <asp:RequiredFieldValidator ID="rq1" runat="server" ErrorMessage="Enter Name" ValidationGroup="A" 
           ControlToValidate="txtName" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                          <li>
                            <label>Address <span class="required">*</span></label>
                            <br />
                            <asp:TextBox ID="txtAddress" runat="server" title="Address" CssClass="input-text" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Address" ValidationGroup="A" 
           ControlToValidate="txtAddress" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                          <li>
                              <label>Email<span class="required">*</span></label>
                            <br />
                            <asp:TextBox ID="txtEmail" runat="server" title="Email" CssClass="input-text" />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Email" ValidationGroup="A" 
           ControlToValidate="txtEmail" CssClass="msg">*</asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="rg1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                          </li>
                          <li>
                           
                              <label>City <span class="required">*</span></label>
                              <br />
                              <asp:TextBox ID="txtCity" runat="server" title="City" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter City" ValidationGroup="A" 
           ControlToValidate="txtCity" CssClass="msg">*</asp:RequiredFieldValidator>
                            
                          </li>
                            <li>
                              <label>State/Province <span class="required">*</span></label>
                              <br />
                             <asp:TextBox ID="txtState" runat="server" title="State" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter State" ValidationGroup="A" 
           ControlToValidate="txtState" CssClass="msg">*</asp:RequiredFieldValidator>
                            </li>
                          <li>
                              <label>Phone<span class="required">*</span></label>
                              <br />
                              <asp:TextBox ID="txtPhone1" runat="server" title="Phone" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Phone" ValidationGroup="A" 
           ControlToValidate="txtPhone1" CssClass="msg">*</asp:RequiredFieldValidator>
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
              <li class="current"><a href="#">Account Information</a></li>
                <li><a href="ChangePassword.aspx">Change Password</a></li>
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

