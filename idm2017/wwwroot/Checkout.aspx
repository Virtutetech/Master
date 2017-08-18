<%@ Page Title="Checkout" EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewcheckout" runat="server">
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
        <div class="page-title">
          <h1>Checkout</h1>
        </div>
        <ol class="one-page-checkout" id="checkoutSteps">
          <li id="opc-billing" class="section allow active">
            <div class="step-title">
              <h3 class="one_page_heading">Shipping Information</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
            <div id="checkout-step-billing" class="step a-item">
              <%--<form id="co-billing-form">--%>
                <fieldset class="group-select">
                  <ul>
                    <li id="billing-new-address-form">
                      <fieldset>
                        <ul>
                           <li>
                            <label>Select Delivery Address <span class="required">*</span></label>
                            <br />
                            <asp:DropDownList ID="ddlAddress" runat="server" CssClass="input-text" AutoPostBack="true"></asp:DropDownList>
                          </li>
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
                              <label>Landmark</label>
                            <br />
                            <asp:TextBox ID="txtLandmark" runat="server" title="Landmark" CssClass="input-text" />
                          </li>
                          <li>
                            <div class="input-box">
                              <label>City <span class="required">*</span></label>
                              <br />
                              <asp:TextBox ID="txtCity" runat="server" title="City" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter City" ValidationGroup="A" 
           ControlToValidate="txtCity" CssClass="msg">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="input-box">
                              <label>State/Province <span class="required">*</span></label>
                              <br />
                             <asp:TextBox ID="txtState" runat="server" title="State" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter State" ValidationGroup="A" 
           ControlToValidate="txtState" CssClass="msg">*</asp:RequiredFieldValidator>
                            </div>
                          </li>
                          <li>
                            <div class="input-box">
                              <label>Zip/Postal Code <span class="required">*</span></label>
                              <br />
                              <asp:TextBox ID="txtZipcode" runat="server" title="Zipcode" CssClass="input-text" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Zipcode" ValidationGroup="A" 
           ControlToValidate="txtZipcode" CssClass="msg">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="input-box">
                              <label>Telephone <span class="required">*</span></label>
                              <br />
                              <asp:TextBox ID="txtPhone" runat="server" title="Phone" CssClass="input-text" />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Phone" ValidationGroup="A" 
           ControlToValidate="txtPhone" CssClass="msg">*</asp:RequiredFieldValidator>
                            </div>
                          </li>
                          <li>
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" CssClass="msg" />
                          </li>
                        </ul>
                      </fieldset>
                    </li>
                  </ul>
                  <%--<asp:Button ID="btnConfirm" runat="server" CssClass="button continue" Text="Confirm" />--%>
                </fieldset>
              <%--</form>--%>
            </div>
          </li>
          <li id="opc-payment" class="section">
            <div class="step-title"> 
              <h3 class="one_page_heading">Payment Information</h3>
              <!--<a href="#">Edit</a>--> 
            </div>
              <div id="checkout-step-billing1" class="step a-item">
               <fieldset class="group-select">
                  <ul>
                    <li>
                      <fieldset>
                        <ul>
                           <li>
                            <div class="input-box">
                              <label>Total Amount</label>
                            </div>
                            <div class="input-box">
                              <asp:Label ID="lblTotal" runat="server" ForeColor="Red" Font-Bold="true" Text="0"></asp:Label>
                            </div>
                          </li>
                            <li>
                            <div class="input-box">
                              <label>Shippping</label>
                            </div>
                            <div class="input-box">
                              <asp:Label ID="lblShipping" Text="0" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </div>
                          </li>
                            <li>
                            <div class="input-box">
                              <label>Taxes</label>
                            </div>
                            <div class="input-box">
                              <asp:Label ID="lblTax" Text="0" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </div>
                          </li>
                            <li>
                                <hr />
                            </li>
                            <li>
                            <div class="input-box">
                              <label><b>Grand Total</b></label>
                            </div>

                            <div class="input-box">
                              <asp:Label ID="lblGTotal" runat="server" ForeColor="Red" Font-Bold="true" Text="0"></asp:Label>
                            </div>
                          </li>
                            <li>
                                <hr />
                            </li>
                            </ul>
                          </fieldset>
                        </li>
                      </ul>
                   </fieldset>
                  </div>
            <div id="checkout-step-payment" class="step a-item">
                <dl id="checkout-payment-method-load">
                  <%--<dt>
                    <input type="radio" value="checkmo" name="payment[method]" title="Check / Money order" class="radio" />
                    <label>Check / Money order</label>
                  </dt>
                  
                  <dt>
                    <input type="radio" value="ccsave" name="payment[method]" title="Credit Card (saved)" class="radio" />
                    <label>Debit/Credit Card</label>
                  </dt>--%>
                  <dt>
                    <input type="radio" value="checkCOD" checked="checked" name="payment[method]" title="Cash on Delivery" class="radio" />
                    <label>COD</label>
                  </dt>
                </dl>
              <div class="buttons-set1" id="payment-buttons-container">
                <asp:Button ID="btnConfirm" runat="server" CssClass="button continue" Text="Confirm Order" ValidationGroup="A" />
                </div>
              <div style="clear: both;"></div>
            </div>
          </li>
        </ol>
      </div>
      <aside class="col-right sidebar col-sm-3">
        <div class="block block-progress">
          <div class="block-title ">Cart Summary</div>
          <div class="block-content" id="divCartSummary" runat="server">
          </div>
        </div>
        </aside>
    </div>
  </div>
</section>
<!-- Main Container end --> 
            </asp:View>
        <asp:View ID="viewSuccess" runat="server">
             <!-- Main Container -->
<section class="content-wrapper">
  <div class="container">
    <div class="std">
      <div class="page-not-found">
        <h2>Success</h2>
        <h3><img src="images/succes.png" alt="success image" />Your order has been placed successfully.<br />Your Order NO is: <span style="color:red;"><asp:Label ID="lblOrderNo" runat="server"></asp:Label></span></h3>
        <div><a href="Default.aspx" class="btn-home"><span>Continue Shopping</span></a></div>
      </div>
    </div>
  </div>
</section>
<!-- Main Container End --> 
        </asp:View>
    </asp:MultiView>
</asp:Content>

