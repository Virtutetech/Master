<%@ Page Title="Product List" Language="VB" MasterPageFile="~/MasterUser.master" AutoEventWireup="false" CodeFile="GriduList.aspx.vb" Inherits="GriduList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
<div class="breadcrumbs">
  <div class="container">
    <div class="row">
      <div class="inner" id="divbread" runat="server">
      </div>
    </div>
  </div>
</div>
<!-- Breadcrumbs End --> 
<!-- Main Container -->
<div class="main-container col2-left-layout">
  <div class="container">
    <div class="row">
      <div class="col-main col-sm-9 col-sm-push-3">
        <article class="col-main">
          <div class="page-title">
            <h2><asp:Label ID="lblProductCategory" runat="server"></asp:Label></h2>
          </div>
          
          <div class="toolbar">
            <div class="sorter">
                <div class="view-mode"> <span title="Grid" class="button button-active button-grid">Grid</span><asp:HyperLink ID="hlnkList" runat="server" NavigateUrl="ProductsList.aspx" title="List" CssClass="button-list">List</asp:HyperLink> </div>
              </div>
          </div>
          <div class="category-products pull-left wow bounceInUp animated">
               <ul class="pdt-list products-grid zoomOut play">
            <asp:DataList ID="dv" runat="server" RepeatColumns="3" OnItemCommand="dv_ItemCommand">
              
                <ItemTemplate>
                    <li class="item item-animate wide-first">
                <div class="item-inner">
                  <div class="product-wrapper">
                    <div class="thumb-wrapper">
                      <asp:HyperLink ID="hlnkImg" runat="server" CssClass="thumb flip"><span class="face"><asp:Image ID="imgF" runat="server" width="250" /></span><span class="face back"><asp:Image ID="imgB" runat="server" width="250" /></span></asp:HyperLink></div>
                    <div class="actions"><span class="add-to-links"> <a href="Login.aspx" class="link-wishlist" title="Add to Wishlist"><span>Add to Wishlist</span></a> </span> </div>
                  </div>
                  <div class="item-info">
                    <div class="info-inner">
                      <div class="item-title"> <asp:HyperLink ID="hlnkName" runat="server"><asp:Label ID="lblProductName" runat="server"></asp:Label> </asp:HyperLink> 
                          <asp:HiddenField ID="hdnIdfr" runat="server" />
                      </div>
                      <div class="item-content">
                        <div class="rating">
                          <div class="ratings">
                            <div class="rating-box">
                              <div class="rating" style="width:80%"></div>
                            </div>
                            <p class="rating-links"> <a href="#">1 Review(s)</a> <span class="separator">|</span> <a href="#">Add Review</a> </p>
                          </div>
                        </div>
                        <div class="item-price">
                          <div class="price-box"> <span class="regular-price"> <span class="price" style="text-decoration:line-through;"><asp:Label ID="lblMRP" runat="server"></asp:Label></span> </span> </div>
                            <div class="price-box"> <span class="regular-price"> <span class="price"><asp:Label ID="lblSalePrice" runat="server"></asp:Label></span> </span> </div>
                        </div>
                      </div>
                    </div>
                    <div class="actions">
                      <asp:Button CssClass="button btn-cart" CommandName="btnCart" Text="Add to Cart" ID="btnCart" runat="server"></asp:Button>
                    </div>
                  </div>
                </div>
              </li>
                </ItemTemplate>
             
            </asp:DataList>

                   </ul>
            <%--<ul class="pdt-list products-grid zoomOut play">
              <li class="item item-animate wide-first">
                <div class="item-inner">
                  <div class="product-wrapper">
                    <div class="thumb-wrapper">
                      <div class="sale-label sale-top-right">Sale</div>
                      <a href="#" class="thumb flip"><span class="face"><img src="products-images/p4.jpg" alt="pr_imgae" width="250"></span><span class="face back"><img  src="products-images/p4.jpg" alt="pr_imgae" width="250"><span class="quick-view" data-product_id="34"><span><i>&nbsp;</i>Quick View</span></span></span></a></div>
                    <div class="actions"><span class="add-to-links"> <a href="#" class="link-wishlist" title="Add to Wishlist"><span>Add to Wishlist</span></a> <a href="#" class="link-compare" title="Add to Compare"><span>Add to Compare</span></a></span> </div>
                  </div>
                  <div class="item-info">
                    <div class="info-inner">
                      <div class="item-title"> <a href="#" title="Retis lapen casen"> Retis lapen casen </a> </div>
                      <div class="item-content">
                        <div class="rating">
                          <div class="ratings">
                            <div class="rating-box">
                              <div class="rating" style="width:80%"></div>
                            </div>
                            <p class="rating-links"> <a href="#">1 Review(s)</a> <span class="separator">|</span> <a href="#">Add Review</a> </p>
                          </div>
                        </div>
                        <div class="item-price">
                          <div class="price-box"> <span class="regular-price"> <span class="price">$125.00</span> </span> </div>
                        </div>
                      </div>
                    </div>
                    <div class="actions">
                      <button class="button btn-cart" title="Add to Cart" type="button"><span>Add to Cart</span></button>
                    </div>
                  </div>
                </div>
              </li>
            
            </ul>--%>
          </div>
        </article>
      </div>
      <div class="col-left sidebar col-sm-3 col-xs-12 col-sm-pull-9">
        <aside class="col-left sidebar  wow bounceInLeft animated">
          
          <div class="block block-layered-nav">
            <div class="block-title">Shop By</div>
            <div class="block-content">
              <p class="block-subtitle">Shopping Options</p>
              <dl id="narrow-by-list">
                <dt class="odd">Price</dt>
                <dd class="odd">
                  <ol>
                    <li> <a href="#"><span class="price">0.00</span> - <span class="price">999.99</span></a> (6) </li>
                    <li> <a href="#"><span class="price">100.00</span> and above</a> (6) </li>
                  </ol>
                </dd>
                <dt class="even">Manufacturer</dt>
                <dd class="even">
                  <div id="divManufacturer" runat="server">
                 
                        </div>
                </dd>
              </dl>
            </div>
          </div>
        </aside>
      </div>
    </div>
  </div>
</div>
<!-- Main Container End --> 
</asp:Content>

