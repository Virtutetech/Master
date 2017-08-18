<%@ Page Title="User Cart -  Indian Dental Mart" Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="Cart.aspx.vb" Inherits="Cart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
         #ContentPlaceHolder1_gvSCart
         {
             width:100%;
             border:1px solid transparent;
         }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <!-- Main Container -->
<section class="main-container col1-layout">
  <div class="main container">
    <div class="col-main">
      <div class="cart">
        <div class="page-title">
          <h2>Shopping Cart</h2>
        </div>
        <div class="table-responsive">
            <h2><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></h2>
            <fieldset>
                    <asp:GridView ID="gvSCart" CssClass="data-table cart-table" OnRowCreated="gvSCart_RowCreated" runat="server" EmptyDataText="Your cart is empty" AutoGenerateColumns="false" ShowHeader="true" ShowFooter="true">
                        <HeaderStyle CssClass="first last" />
                        <RowStyle CssClass="first odd" />
                        <Columns>
                             <asp:BoundField HeaderText="ProductIdfr" DataField="ProductIdfr" Visible="false" />
                            <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="img1" runat="server" Width="50px" Height="50px" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <button class="button btn-continue" title="Continue Shopping" type="button"><span><span><a href="Default.aspx">Continue Shopping</a></span></span></button>
                                    <asp:Button ID="btnUpdate" runat="server" Cssclass="button btn-update" OnClick="btnUpdate_Click" Text="Update Cart" title="Update Cart" />
                                    <asp:Button ID="btnEmpty" runat="server" Cssclass="button btn-empty" Text="Clear Cart" OnClick="btnEmpty_Click" />
                                </FooterTemplate>

<FooterStyle HorizontalAlign="Left"></FooterStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                    <asp:BoundField HeaderText="Product" DataField="ProductName" />
                    <asp:BoundField HeaderText="MRP" DataField="MRP" />
                    <asp:BoundField HeaderText="SalePrice" DataField="SalePrice" />
                            <asp:TemplateField HeaderText="Qty" FooterStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" MaxLength="10" runat="server" Text="1" CssClass="input-text" Width="50px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="txtQty_FilteredTextBoxExtender" runat="server" FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890" Enabled="True" TargetControlID="txtQty">
                </asp:FilteredTextBoxExtender>
                                </ItemTemplate>

<FooterStyle HorizontalAlign="Left"></FooterStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                   <asp:ImageButton ID="imgbtnRemove" runat="server" ImageUrl="~/images/emptycart.png" OnClick="imgbtnRemove_Click" />
                                   <asp:ConfirmButtonExtender ID="imgbtnRemove_ConfirmButtonExtender" runat="server" ConfirmText="Do you really want to Delete ?" Enabled="True" TargetControlID="imgbtnRemove">
                                          </asp:ConfirmButtonExtender>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

            </fieldset>
        </div>
          <br /><br /><br />
        <!-- BEGIN CART COLLATERALS -->
        <div class="cart-collaterals row">
          
          <div class="col-sm-4">
            <div class="discount">
            <h3>Discount Codes</h3>
              <label for="coupon_code">Enter your coupon code if you have one.</label>
              <input type="hidden" value="0" id="remove-coupone" name="remove">
              <input type="text" name="coupon_code" id="coupon_code" class="input-text fullwidth">
              <button value="Apply Coupon" class="button coupon " title="Apply Coupon" type="button"><span>Apply Coupon</span></button>
          </div>
        </div>
            <div class="col-sm-4">
           &nbsp;
          </div>
        <div class="totals col-sm-4">
          <h3>Shopping Cart Total</h3>
          <div class="inner">
            <table class="table shopping-cart-table-total" id="shopping-cart-totals-table">
              <colgroup>
              <col>
              <col />
              </colgroup>
              <tfoot>
                <tr>
                  <td colspan="1" class="a-left"><strong>Grand Total</strong></td>
                  <td class="a-right"><strong><span class="price"><asp:Label ID="lblGTotal" runat="server"></asp:Label></span></strong></td>
                </tr>
              </tfoot>
              <tbody>
                <tr>
                  <td colspan="1" class="a-left"> Subtotal </td>
                  <td class="a-right"><span class="price"><asp:Label ID="lblSubTotal" runat="server"></asp:Label></span></td>
                </tr>
              </tbody>
            </table>
            <ul class="checkout">
              <li style="float:right;">
                <asp:Button ID="btnCheckout" runat="server" CssClass="button btn-proceed-checkout" title="Proceed to Checkout" ForeColor="White" Text="Place Order" OnClick="btnCheckout_Click" BackColor="#ED5565" Height="71px" Width="250px" />
                  <%--<span><a href="Checkout.aspx" style="color:white;">Proceed to Checkout</a></span></asp:Button>--%>
              </li>
            </ul>
          </div>
          <!--inner--> 
          
        </div>
      </div>
      
      <!--cart-collaterals--> 
      
    </div>
   
  </div>
  </div>
  </section>
  <!-- Main Container End -->
</asp:Content>

