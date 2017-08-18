<%@ Page Title="Search Results" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="ProductSearch.aspx.vb" Inherits="ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        #ContentPlaceHolder1_gvProducts tr td{
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
<div class="breadcrumbs">
  <div class="container">
    <div class="row">
      <div class="inner" id="divbread" runat="server">
        <%--<ul>
          <li class="home"> <a title="Go to Home Page" href="#">Home</a><span>&mdash;&rsaquo;</span></li>
          <li class=""> <a title="Go to Home Page" href="#">Women</a><span>&mdash;&rsaquo;</span></li>
          <li class="category13"><strong>Tops & Tees</strong></li>
        </ul>--%>
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
            <h2><asp:Label ID="lblCategory" runat="server"></asp:Label></h2>
          </div>
          <div class="toolbar wow bounceInUp animated">
            <div class="sorter">
                <div class="view-mode"> <asp:HyperLink ID="hlnkGrid" runat="server" NavigateUrl="GridG.aspx" title="Grid" CssClass="button button-grid">Grid</asp:HyperLink>&nbsp; <span title="List" class="button button-active button-list">List</span>&nbsp; </div>
              </div>    
          <%--  <div id="sort-by">
              <label class="left">Sort By: </label>
              <ul>
                <li><a href="#">Position<span class="right-arrow"></span></a>
                  <ul>
                    <li><a href="#">Name</a></li>
                    <li><a href="#">Price</a></li>
                    <li><a href="#">Position</a></li>
                  </ul>
                </li>
              </ul>
              <a class="button-asc left" href="#" title="Set Descending Direction"><span class="glyphicon glyphicon-arrow-up"></span></a> </div>
            <div class="pager">
              <div id="limiter">
                <label>View: </label>
                <ul>
                  <li><a href="#">15<span class="right-arrow"></span></a>
                    <ul>
                      <li><a href="#">20</a></li>
                      <li><a href="#">30</a></li>
                      <li><a href="#">35</a></li>
                    </ul>
                  </li>
                </ul>
              </div>
              <div class="pages">
                <label>Page:</label>
                <ul class="pagination">
                  <li><a href="#">&laquo;</a></li>
                  <li class="active"><a href="#">1</a></li>
                  <li><a href="#">2</a></li>
                  <li><a href="#">3</a></li>
                  <li><a href="#">4</a></li>
                  <li><a href="#">5</a></li>
                  <li><a href="#">&raquo;</a></li>
                </ul>
              </div>
            </div>--%>
          </div>
          <div class="category-products wow bounceInUp animated">
            <ol class="products-list" id="products-list">
                <asp:GridView ID="gvProducts" runat="server" BorderStyle="None" BorderWidth="0" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                  <li class="item first" id="limy" runat="server">
                <div class="product-image"> <asp:HyperLink ID="hlnkImg" runat="server"><asp:Image ID="img1" runat="server" ImageUrl="~/img-di/17.jpg" CssClass="small-image" /> </asp:HyperLink> </div>
                <div class="product-shop">
                  <h2 class="product-name"><asp:HyperLink ID="hlnkName" runat="server"><asp:Label ID="lblProductName" runat="server"></asp:Label></asp:HyperLink></h2>
                     <asp:HiddenField ID="hdnIdfr" runat="server" />
                  <div class="price-box">
                    <p class="old-price"> <span class="price-label"></span> <span id="old-price-212" class="price"> <asp:Label ID="lblMRP" runat="server"></asp:Label> </span> </p>
                    <p class="special-price"> <span class="price-label"></span> <span class="price"> <asp:Label ID="lblSalePrice" runat="server"></asp:Label> </span> </p>
                  </div>
                  <div class="ratings">
                    <div class="rating-box">
                      <div style="width:50%" class="rating"></div>
                    </div>
                    <p class="rating-links"> <a href="#">1 Review(s)</a> <span class="separator">|</span> <a href="#">Add Your Review</a> </p>
                  </div>
                  <div class="desc std">
                    <p id="Pdesc" runat="server">Sed sed interdum diam. Donec sit ametenim tempor, dapibus nunc eu, 
                      tincidunt mi. Vivamus dictum nec... </p>
                  </div>
                  <div class="actions">
                    <asp:Button ID="btnCart" runat="server" CssClass="button btn-cart ajx-cart" title="Add to Cart" Text="Add to Cart" OnClick="btnCart_Click" />
                    <span class="add-to-links"> <a title="Add to Wishlist" class="button link-wishlist" href="#"><span>Add to Wishlist</span></a> 
                        </span> </div>
                </div>
              </li>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            
            </ol>
          </div>
        </article>
        <!--	///*///======    End article  ========= //*/// --> 
      </div>
      <div class="col-left sidebar col-sm-3 col-xs-12 col-sm-pull-9">
        <aside class="col-left sidebar wow bounceInLeft animated">
          <div class="block block-layered-nav">
            <div class="block-content">
              <p class="block-subtitle">Shopping Options</p>
              <dl id="narrow-by-list">
                <dt class="odd">Price</dt>
                <dd class="odd">
                    <div id="divPrice" runat="server">
                  <ol>
                    <li> <a href="#"><span class="price">0.00</span> - <span class="price">99.99</span></a> (6) </li>
                    <li> <a href="#"><span class="price">100.00</span> and above</a> (6) </li>
                  </ol>
                  </div>
                </dd>
                <dt class="even">Manufacturer</dt>
                <dd class="even">
                    <div id="divManufacturer" runat="server">
                 
                        </div>
                </dd>
              </dl>
            </div>
          </div>
          <div class="block block-cart">
            <div class="block-content">
              <p class="block-subtitle">Recently added item(s) </p>
              <ul>
                <li class="item"> <a href="#" class="product-image"><img width="60" src="img-di/1.jpg" /></a>
                  <div class="product-details">
                    <div class="access"> <a href="#" title="Remove This Item" class="btn-remove1"> <span class="icon"></span> Remove </a> </div>
                    <p class="product-name"> <a href="#">Gloves</a> </p>
                    <strong>1</strong> x <span class="price">19.99</span> </div>
                </li>
                <li class="item last"> <a href="#" class="product-image"><img width="60" src="img-di/2.jpg" /></a>
                  <div class="product-details">
                    <div class="access"> <a href="#" title="Remove This Item" class="btn-remove1"> <span class="icon"></span> Remove </a> </div>
                    <p class="product-name"> <a href="#"> Gloves </a> </p>
                    <strong>1</strong> x <span class="price">8.00</span> 
                    <!--access clearfix--> 
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </aside>
      </div>
    </div>
  </div>
</div>
<!-- Main Container End --> 
</asp:Content>



