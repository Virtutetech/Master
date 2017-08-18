<%@ Page Title="Address Book" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="MyAddressBook.aspx.vb" Inherits="MyAddressBook" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
         <style>
         #ContentPlaceHolder1_gvOrders
         {
             width:100%;
             border:1px solid transparent;
         }
       
    </style>
    <style type="text/css">
.modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}
</style>
    <script type="text/javascript">
        function Hidepopup() {
            $find("bh1").hide();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
           <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
        <div class="my-account">
          <div class="page-title">
            <h2>My AddressBook</h2>
          </div>
          <div class="dashboard">
            <div class="welcome-msg" style="text-align:right!important;"> 
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Address" CssClass="btn" />
            </div>
            <div class="recent-orders">
              <div class="title-buttons"><strong>Address List</strong></div>
                <div class="title-buttons"><strong><asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></strong></div>

              <div class="table-responsive">
                    <asp:GridView ID="gvOrders" CssClass="data-table" OnRowDataBound="gvOrders_RowDataBound" Width="100%" runat="server" AutoGenerateColumns="false" ShowHeader="true" EmptyDataText="No Orders found">
                        <HeaderStyle CssClass="first last" />
                        <RowStyle CssClass="first odd" />
                        <Columns>
                            <asp:BoundField DataField="AddressIdfr" HeaderText="AddressIdfr" Visible="false" />
        <asp:BoundField DataField="PersonName" HeaderText="PersonName" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Landmark" HeaderText="Landmark" />
                            <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="State" HeaderText="State" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnView" runat="server" Text="Edit" ForeColor="Blue" Font-Underline="true" OnClick="lnkbtnView_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>



         
              </div>
            </div>
          </div>
        </div>
          
           <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                  <asp:ModalPopupExtender ID="popup" BehaviorID="bh1" runat="server" DropShadow="false"
PopupControlID="pnlAddEdit" TargetControlID = "lnkFake"
BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
                  <asp:Panel ID="pnlAddEdit" runat="server" BackColor="White" style = "display:none;padding:9px;">
                    <div style="height:300px;overflow:auto;">
                      <div><asp:Button ID="btnCancel" runat="server" Text="X" Font-Size="Larger" BackColor="white" ForeColor="Red" OnClientClick = "return Hidepopup()"/>
                          <asp:HiddenField ID="hdnIdfr" runat="server" Value="" />
                      </div>
                            <div class="page-title">
          <h1><asp:Label ID="lblAddEdit" runat="server"></asp:Label></h1>
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
                                <label> PersonName<span class="required">*</span></label>
                                <br />
                                <asp:TextBox ID="txtName" runat="server" title="Person Name" MaxLength="50" CssClass="input-text" />
                               <asp:RequiredFieldValidator ID="rq1" runat="server" ErrorMessage="Enter Name" ValidationGroup="A" 
           ControlToValidate="txtName" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                          <li>
                            <label>Address <span class="required">*</span></label>
                            <br />
                            <asp:TextBox ID="txtAddress" runat="server" title="Address" MaxLength="500" CssClass="input-text" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Address" ValidationGroup="A" 
           ControlToValidate="txtAddress" CssClass="msg">*</asp:RequiredFieldValidator>
                          </li>
                             <li>
                            <label>Landmark </label>
                            <br />
                            <asp:TextBox ID="txtLandmark" runat="server" MaxLength="500" title="Address" CssClass="input-text" />
                          </li>
                            <li>
                            <label>Pincode <span class="required">*</span></label>
                            <br />
                            <asp:TextBox ID="txtPincode" runat="server" title="Address" MaxLength="6" CssClass="input-text" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Pincode" ValidationGroup="A" 
           ControlToValidate="txtPincode" CssClass="msg">*</asp:RequiredFieldValidator>
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
                              <asp:TextBox ID="txtPhone1" runat="server" title="Phone" CssClass="input-text" MaxLength="10" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Phone" ValidationGroup="A" 
           ControlToValidate="txtPhone1" CssClass="msg">*</asp:RequiredFieldValidator>
                               <asp:FilteredTextBoxExtender ID="txtPhone1_FilteredTextBoxExtender" runat="server" FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890" Enabled="True" TargetControlID="txtPhone1">
                </asp:FilteredTextBoxExtender>
                          </li>
                          <li>
                            <asp:Label ID="lblpopupmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
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
</asp:Panel>
               </ContentTemplate>
                </asp:UpdatePanel>
      </div>
      <aside class="col-right sidebar col-sm-3">
        <div class="block block-account">
          <div class="block-title">My Account</div>
          <div class="block-content">
            <ul>
             <li><a href="Dashboard.aspx">Account Dashboard</a></li>
              <li><a href="MyProfile.aspx">Account Information</a></li>
                <li><a href="ChangePassword.aspx">Change Password</a></li>
              <li class="current"><a href="#">Address Book</a></li>
              <li class="last"><a href="MyWishlist.aspx">My Wishlist</a></li>
            </ul>
          </div>
        </div>
      </aside>
    </div>
  </div>
</section>


   
<!-- Main Container End -->
</asp:Content>


