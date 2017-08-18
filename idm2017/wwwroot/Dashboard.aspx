<%@ Page Title="Dashboard" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Dashboard" %>
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
            <h2>My Dashboard</h2>
          </div>
          <div class="dashboard">
            <div class="welcome-msg"> <strong>Hello, <asp:Label ID="lblName" runat="server"></asp:Label> !</strong>
              <p>From your Dashboard you have the ability to view a snapshot of your recent account activity. Select a link on left side to view your information.</p>
            </div>
            <div class="recent-orders">
              <div class="title-buttons"><strong>Orders History</strong></div>
                <div class="title-buttons"><strong><asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></strong></div>

              <div class="table-responsive">
                    <asp:GridView ID="gvOrders" CssClass="data-table" OnRowDataBound="gvOrders_RowDataBound" Width="100%" runat="server" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged" AutoGenerateColumns="false" ShowFooter="true" ShowHeader="true" EmptyDataText="No Orders found">
                        <HeaderStyle CssClass="first last" />
                        <RowStyle CssClass="first odd" />
                        <Columns>
                            <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
        <asp:BoundField DataField="SaleDate" HeaderText="SaleDate" />
                            <asp:BoundField DataField="PersonName" HeaderText="Ship To" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnView" runat="server" Text="Details" ForeColor="Blue" Font-Underline="true" OnClick="lnkbtnView_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
<asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                  <asp:ModalPopupExtender ID="popup" BehaviorID="bh1" runat="server" DropShadow="false"
PopupControlID="pnlAddEdit" TargetControlID = "lnkFake"
BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
                  <asp:Panel ID="pnlAddEdit" runat="server" BackColor="White" style = "display:none">
                              <table>
    <tr>
        <td align="right">
<asp:Button ID="btnCancel" runat="server" Text="X" Font-Size="Larger" BackColor="white" ForeColor="Red" OnClientClick = "return Hidepopup()"/>
</td>
</tr>
    <tr>
        <td style="padding:15px;">
            <asp:GridView ID="gvIn" runat="server" AutoGenerateColumns="false" CssClass="data-table">
                <Columns>
                    <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-Width="50" ControlStyle-Height="50"></asp:ImageField>
                    <asp:BoundField HeaderText="Product" DataField="ProductName" />
                    <asp:BoundField HeaderText="MRP" DataField="MRP" />
                    <asp:BoundField HeaderText="SalePrice" DataField="SalePrice" />
                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
</asp:Panel>


         
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

