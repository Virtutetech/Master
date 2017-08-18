<%@ Page Title="Wishlist - Indian Dental Mart" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="MyWishlist.aspx.vb" Inherits="MyWishlist" %>
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
        <div class="my-account">
          <div class="page-title">
            <h2>My Wishlist</h2>
          </div>
          <div class="dashboard">
            <div class="recent-orders">
                <div class="title-buttons"><strong><asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></strong></div>
              <div class="table-responsive">
                    <asp:GridView ID="gvOrders" CssClass="data-table" OnRowDataBound="gvOrders_RowDataBound" Width="100%" runat="server" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="true" EmptyDataText="No Orders found">
                        <HeaderStyle CssClass="first last" />
                        <RowStyle CssClass="first odd" />
                        <Columns>
                            <asp:BoundField HeaderText="ProductIdfr" DataField="ProductIdfr" Visible="false" />
                                 <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-Width="50" ControlStyle-Height="50"></asp:ImageField>
                    <asp:BoundField HeaderText="Product" DataField="ProductName" />
                    <asp:BoundField HeaderText="MRP" DataField="MRP" />
                    <asp:BoundField HeaderText="SalePrice" DataField="SalePrice" />
                            <asp:TemplateField HeaderText="Move to Cart">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnCart" runat="server" ImageUrl="~/images/cart.png" OnClick="imgbtnCart_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnRemove" runat="server" ImageUrl="~/images/emptycart.png" OnClick="imgbtnRemove_Click" />
                                      <asp:ConfirmButtonExtender ID="imgbtnRemove_ConfirmButtonExtender" runat="server" ConfirmText="Do you really want to Delete ?" Enabled="True" TargetControlID="imgbtnRemove">
                    </asp:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
              </div>
            </div>
          </div>
        </div>
      </div>
      <aside class="col-right sidebar col-sm-3">
        <div class="block block-account">
          <div class="block-title">My Account</div>
          <div class="block-content">
            <ul>
             <li class="current"><a href="#">Account Dashboard</a></li>
              <li><a href="MyProfile.aspx">Account Information</a></li>
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
<!-- Main Container End -->
</asp:Content>


