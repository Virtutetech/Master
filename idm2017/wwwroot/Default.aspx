<%@ Page Title="Indian Dental Mart - Home" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- header service -->
<div class="header-service">
  <div class="container">
   <%-- <div class="row">
      <div class="col-lg-3 col-md-3 col-sm-6 col-xs-3">
        <div class="content">
          <div class="icon-truck">&nbsp;</div>
          <span class="hidden-xs">FREE SHIPPING on order over 999</span></div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-6 col-xs-3">
        <div class="content">
          <div class="icon-support">&nbsp;</div>
          <span class="hidden-xs">Customer Support Service</span></div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-6 col-xs-3">
        <div class="content">
          <div class="icon-money">&nbsp;</div>
          <span class="hidden-xs">3 days Money Back Guarantee</span></div>
      </div>
      <div class="col-lg-3 col-md-3 col-sm-6 col-xs-3">
        <div class="content">
          <div class="icon-dis">&nbsp;</div>
          <span class="hidden-xs">5% discount on order over 1999</span></div>
      </div>
    </div>--%>
  </div>
</div>
<!-- End header service --> 

<!-- Slider -->
<div id="magik-slideshow" class="magik-slideshow">
  <div class="container">
    <div class="row">
      <div class="col-lg-8 col-sm-12 col-md-12">
        <div id='rev_slider_4_wrapper' class='rev_slider_wrapper fullwidthbanner-container' >
          <div id='rev_slider_4' class='rev_slider fullwidthabanner'>
            <ul>
              <li data-transition='random' data-slotamount='7' data-masterspeed='1000' data-thumb='images/slider_img_2.html'>
                  <img src='images/comgsoon.jpg' data-bgposition='left top' data-bgfit='cover' data-bgrepeat='no-repeat' alt="banner"/>
              </li>
              <li data-transition='random' data-slotamount='7' data-masterspeed='1000' data-thumb='images/slider_img_2.jpg' class="black-text">
                  <img src='images/comgsoon.jpg'  data-bgposition='left top'  data-bgfit='cover' data-bgrepeat='no-repeat' alt="banner"/>
              </li>
            </ul>
            <div class="tp-bannertimer"></div>
          </div>
        </div>
      </div>
      <aside class="col-xs-12 col-sm-12 col-md-4">
        <div class="RHS-banner">
          <div class="add"><a href="#"><img alt="banner-img" src="images/comgsoonapp.png" /></a></div>
        </div>
      </aside>
    </div>
  </div>
</div>
<!-- end Slider --> 

        <!-- Latest Blog -->
<section class="latest-blog wow bounceInDown animated">
  <div class="container">
    <div class="row">
     <div class="blog-title">
        <h2><span>Latest Events</span></h2>
      </div>
         <asp:Repeater ID="rptEvents" runat="server">
                    <ItemTemplate>
                        <div class="col-xs-12 col-sm-4">
        <div class="blog_inner">
          <div class="blog-img blog-l"> <asp:Image ID="img1" runat="server" alt="Event image" />
            <div class="mask"> <asp:HyperLink ID="hlnkmore" runat="server" class="info">click here for details</asp:HyperLink> </div>
          </div>
          <h2><asp:HyperLink ID="hlnkTitle" runat="server"><asp:Label ID="lblTitle" runat="server"></asp:Label> </asp:HyperLink> </h2>
          <div class="post-date"><i class="icon-calendar"></i> <asp:Label ID="lblDate" runat="server"></asp:Label></div>
          <p><asp:Label ID="lblDesc" runat="server"></asp:Label></p>
        </div>
      </div>
                        </ItemTemplate>
             </asp:Repeater>

    </div>
  </div>
</section>
<!-- End Latest Blog --> 

<!-- main container -->
<div class="main-col">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="std"> 
          <!-- Best Seller Slider -->
          <div class="best-seller-pro wow bounceInUp animated">
            <div class="slider-items-products">
              <div class="new_title center">
                <h2>Recent Products</h2>
              </div>
              <div id="best-seller-slider" class="product-flexslider hidden-buttons">
                <%--<div class="slider-items slider-width-col6" id="divlatest" runat="server"> --%>
                  <div class="slider-items slider-width-col6"> 
                  
                  <!-- Item -->
                 <asp:Repeater ID="rptCustomers" runat="server" OnItemCommand="rptCustomers_ItemCommand">
                    <ItemTemplate>
                        <div class="item">
                    <div class="col-item">
                      <div class="sale-label sale-top-right">New</div>
                      <div class="item-inner">
                        <div class="product-wrapper">
                          <div class="thumb-wrapper"><asp:HyperLink ID="hlnkimg" runat="server" CssClass="thumb flip"><span class="face"><asp:Image ID="imgF" runat="server" /></span><span class="face back"><asp:Image ID="imgB" runat="server"  /></span></asp:HyperLink></div>
                          <%--<div class="actions"><span class="add-to-links"> <a href="Login.aspx" class="link-wishlist" title="Add to Wishlist"><span>Add to Wishlist</span></a> </span> </div>--%>
                            <div class="actions"><span class="add-to-links"> <asp:LinkButton ID="lnkbtnWish" runat="server" CssClass="link-wishlist" title="Add to Wishlist" CommandName="lnkbtnWish"></asp:LinkButton> </span> </div>
                        </div>
                        <div class="item-info">
                          <div class="info-inner">
                             <div class="item-title"> <asp:HyperLink ID="hlnkName" runat="server"> <asp:Label ID="lblProductName" runat="server"></asp:Label></asp:HyperLink>
                                 <asp:HiddenField ID="hdnIdfr" runat="server"></asp:HiddenField> </div>
                            <div class="item-content">
                            
                              <div class="item-price">
                                <div class="price-box"> <span class="regular-price"> <span class="price" style="text-decoration:line-through;"><asp:Label ID="lblMRP" runat="server"></asp:Label></span> </span> </div>
                                  <div class="price-box"> <span class="regular-price"> <span class="price"><asp:Label ID="lblSalePrice" runat="server"></asp:Label></span> </span> </div>
                              </div>
                            </div>
                          </div>
                          <div class="actions">
                            <asp:Button ID="btnCart" runat="server" CssClass="button btn-cart" Text="Add to Cart" CommandName="btnCart" UseSubmitBehavior="false" />
                              <asp:Button ID="btnBuy" runat="server" CssClass="button btn-cart" Text="Buy Now" CommandName="btnBuy" UseSubmitBehavior="false" />
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                    </ItemTemplate>
                 </asp:Repeater>
                    
                  <!-- End Item --> 
                  
                </div>
              </div>
            </div>
          </div>
          <!-- End Best Seller Slider --> 
        </div>
      </div>
    </div>
  </div>
</div>
<!-- end main container --> 


<!-- middle slider -->
<section class="small-product-slider">
  <div class="container">
    <div class="row">
      <div class="col-md-6">
        <div class="bag-product-slider small-pr-slider  wow bounceInLeft animated">
          <div class="slider-items-products">
            <div class="new_title center">
              <h2><asp:Label ID="lblCategory1" runat="server"></asp:Label></h2>
            </div>
            <div id="bag-seller-slider" class="product-flexslider hidden-buttons">
              <div class="slider-items slider-width-col3"> 
                <!-- Item -->
                  <asp:Repeater ID="rptCat1" runat="server" OnItemCommand="rptCustomers_ItemCommand">
                      <ItemTemplate>
                          <div class="item">
                  <div class="col-item">
                    <div class="sale-label sale-top-right">Sale</div>
                    <div class="item-inner">
                      <div class="product-wrapper">
                          <div class="thumb-wrapper"><asp:HyperLink ID="hlnkimg" runat="server" CssClass="thumb flip"><span class="face"><asp:Image ID="imgF" runat="server" /></span><span class="face back"><asp:Image ID="imgB" runat="server" /></span></asp:HyperLink></div>
                          <div class="actions"><span class="add-to-links"> <asp:LinkButton ID="lnkbtnWish" runat="server" CssClass="link-wishlist" title="Add to Wishlist" CommandName="lnkbtnWish"></asp:LinkButton> </span> </div>
                        </div>
                      <div class="item-info">
                        <div class="info-inner">
                            <div class="item-title"> <asp:HyperLink ID="hlnkName" runat="server"> <asp:Label ID="lblProductName" runat="server"></asp:Label></asp:HyperLink>
                                 <asp:HiddenField ID="hdnIdfr" runat="server"></asp:HiddenField> </div>
                            <div class="item-content">
                            <div class="item-price">
                              <div class="price-box"> <span class="regular-price"> <span class="price" style="text-decoration:line-through;"><asp:Label ID="lblMRP" runat="server"></asp:Label></span> </span> </div>
                              <div class="price-box"> <span class="regular-price"> <span class="price"><asp:Label ID="lblSalePrice" runat="server"></asp:Label></span> </span> </div>
                            </div>
                          </div>
                        </div>
                        <div class="actions">
                          <asp:Button ID="btnCart" runat="server" CssClass="button btn-cart" title="Add to Cart" Text="Add to Cart" CommandName="btnCart" UseSubmitBehavior="false" />
                            <asp:Button ID="btnBuy" runat="server" CssClass="button btn-cart" Text="Buy Now" CommandName="btnBuy" UseSubmitBehavior="false" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                      </ItemTemplate>
                  </asp:Repeater>
                
                <!-- End Item --> 
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-6">
        <div class="shoes-product-slider small-pr-slider  wow bounceInRight animated">
          <div class="slider-items-products">
            <div class="new_title center">
              <h2><asp:Label ID="lblCategory2" runat="server"></asp:Label></h2>
            </div>
            <div id="bag-seller-slider1" class="product-flexslider hidden-buttons">
              <div class="slider-items slider-width-col3"> 
                
                <!-- Item -->
                  <asp:Repeater ID="rptCat2" runat="server" OnItemCommand="rptCustomers_ItemCommand">
                      <ItemTemplate>
                            <div class="item">
                  <div class="col-item">
                    <div class="sale-label sale-top-right">Sale</div>
                    <div class="item-inner">
                      <div class="product-wrapper">
                          <div class="thumb-wrapper"><asp:HyperLink ID="hlnkimg" runat="server" CssClass="thumb flip"><span class="face"><asp:Image ID="imgF" runat="server"  /></span><span class="face back"><asp:Image ID="imgB" runat="server" /></span></asp:HyperLink></div>
                          <div class="actions"><span class="add-to-links"> <asp:LinkButton ID="lnkbtnWish" runat="server" CssClass="link-wishlist" title="Add to Wishlist" CommandName="lnkbtnWish"></asp:LinkButton> </span> </div>
                        </div>
                      <div class="item-info">
                        <div class="info-inner">
                          <div class="item-title"> <asp:HyperLink ID="hlnkName" runat="server"> <asp:Label ID="lblProductName" runat="server"></asp:Label></asp:HyperLink>
                                 <asp:HiddenField ID="hdnIdfr" runat="server"></asp:HiddenField> </div>
                            <div class="item-content">
                            <div class="item-price">
                              <div class="price-box"> <span class="regular-price"> <span class="price"><asp:Label ID="lblMRP" runat="server"></asp:Label></span> </span> </div>
                              <div class="price-box"> <span class="regular-price"> <span class="price"><asp:Label ID="lblSalePrice" runat="server"></asp:Label></span> </span> </div>
                            </div>
                          </div>
                        </div>
                        <div class="actions">
                          <asp:Button ID="btnCart" runat="server" CssClass="button btn-cart" title="Add to Cart" Text="Add to Cart" CommandName="btnCart" UseSubmitBehavior="false" />
                            <asp:Button ID="btnBuy" runat="server" CssClass="button btn-cart" Text="Buy Now" CommandName="btnBuy" UseSubmitBehavior="false" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                       </ItemTemplate>
                  </asp:Repeater>
                <!-- End Item --> 
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
<!-- End middle slider --> 


</asp:Content>

