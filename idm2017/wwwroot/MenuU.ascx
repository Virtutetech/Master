<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuU.ascx.vb" Inherits="MenuU" %>
<%@ OutputCache Duration="600" VaryByControl="none" %>
<!-- Header -->
<header>
  <div class="header-container">
    <div class="header-top">
      <div class="container">
        <div class="row">
          <div class="col-sm-4 col-xs-7"> 
            <div class="phone">
            <div class="phone-box"><strong>Need help?</strong> <span>+1 800 123 1234</span></div>
          </div>
          </div>
          <div class="col-sm-8 col-xs-5">
            <div class="toplinks">
              <div class="links">
                  <div class="login"><a href="Profile.aspx"><span class="hidden-xs">My Account</span></a></div>
                <div class="login"><a href="Wishlist.aspx"><span class="hidden-xs">Wishlist</span></a></div>
                  <div class="login"><a href="Default.aspx"><span class="hidden-xs">Logout</span></a></div>
              </div>
              <!-- links --> 
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row">
        
        <div class="col-lg-7 col-md-4 col-xs-6"> 
          <!-- Header Logo -->
          <div class="logo"><a title="Indian Dental Mart" href="Default.aspx"><img alt="Indian Dental Mart" src="images/idmlogo.png" /></a> </div>
          <!-- End Header Logo --> 
        </div>
          <div class="col-lg-3 col-md-4">&nbsp;</div>
       <div class="col-lg-2 col-md-4 col-xs-6">
          <div class="top-cart-contain pull-right"> 
            <!-- Top Cart -->
            <div class="mini-cart">
              <div data-toggle="dropdown" data-hover="dropdown" class="basket dropdown-toggle"> <a href="#"> <i class="glyphicon glyphicon-shopping-cart"></i>
                <div class="cart-box"><span class="title">cart</span><span id="cart-total"><asp:Label ID="lblTotalQty" Text="2" runat="server"></asp:Label></span></div>
                </a></div>
              <div>
                <div style="display: none;" class="top-cart-content arrow_box">
                  <div class="block-subtitle">Recently added item(s)</div>
                  <ul id="cart-sidebar" class="mini-products-list">
                      <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="false">
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <li class="item even" id="myli" runat="server">
                                          <asp:Image ID="img1" runat="server" ImageUrl="img-di/1.jpg" width="80" />
                                            <div class="detail-item">
                                                <asp:HiddenField ID="hdnIdfr" runat="server"></asp:HiddenField>
                                                <%--<div class="product-details"> <a href="#" title="Remove This Item" onClick="" class="glyphicon glyphicon-remove">&nbsp;</a> <a class="glyphicon glyphicon-pencil" title="Edit item" href="#">&nbsp;</a>--%>
                                                    <p class="product-name"> <asp:Label ID="lblName" runat="server"></asp:Label> </p>
                                                <%--</div>--%>
                                                <div class="product-details-bottom"> <span class="price"><asp:Label ID="lblPrice" runat="server"></asp:Label></span> <span class="title-desc">Qty:</span> <strong><asp:Label ID="lblQty" runat="server"></asp:Label></strong> </div>
                                            </div>
                                      </li>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                    
                    <%--<li class="item last odd"> <a class="product-image" href="#" title="  Sample Product "><img alt="  Sample Product " src="products-images/p2.jpg" width="80"></a>
                      <div class="detail-item">
                        <div class="product-details"> <a href="#" title="Remove This Item" onClick="" class="glyphicon glyphicon-remove">&nbsp;</a> <a class="glyphicon glyphicon-pencil" title="Edit item" href="#">&nbsp;</a>
                          <p class="product-name"> <a href="#" title="  Sample Product "> Sample Product </a> </p>
                        </div>
                        <div class="product-details-bottom"> <span class="price">$320.00</span> <span class="title-desc">Qty:</span> <strong>2</strong> </div>
                      </div>
                    </li>--%>
                  </ul>
                  <div class="top-subtotal">Subtotal: <span class="price">$420.00</span></div>
                  <div class="actions">
                    <button class="btn-checkout" type="button"><span>Checkout</span></button>
                    <button class="view-cart" type="button"><span>View Cart</span></button>
                  </div>
                </div>
              </div>
            </div>
            <!-- Top Cart -->
            <div id="ajaxconfig_info" style="display:none"> <a href="#/"></a>
              <input value="" type="hidden">
              <input id="enable_module" value="1" type="hidden">
              <input class="effect_to_cart" value="1" type="hidden">
              <input class="title_shopping_cart" value="Go to shopping cart" type="hidden">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</header>
<!-- end header --> 
<nav>
  <div class="container">
    <div class="row">
      <div class="nav-inner"> 
 <!-- mobile-menu -->
        <div class="hidden-desktop" id="mobile-menu">
          <ul class="navmenu">
            <li>
              <div class="menutop">
                <div class="toggle"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span></div>
                <h2>Menu</h2>
              </div>
                <div id="divmobilemenu" runat="server">

                </div>
              <!--navmenu--> 
            </li>
          </ul>
        </div>
        <!--End mobile-menu -->
          <div id="divmainmenu" runat="server"></div>
        
        
        <!-- Search-col -->
       <%-- <div class="search-box pull-right">
            <input type="text" placeholder="Search entire store here..." value="Search" maxlength="70" name="search" id="search">
            <button type="button" class="btn btn-default  search-btn-bg"> <span class="glyphicon glyphicon-search"></span>&nbsp;</button>
        </div>--%>
        <!-- End Search-col --> 
 </div>
    </div>
  </div>
</nav>

