<%@ Page Title="Product Details" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="ProductDetails.aspx.vb" Inherits="ProductDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <!-- Main Container -->
<section class="main-container col1-layout">
  <div class="main container">
    <div class="col-main">
      <div class="row">

        <div class="product-view">
          <div class="product-essential">
              <div class="product-img-box col-sm-4 col-xs-12 col-lg-5 wow bounceInLeft animated">
                <div class="new-label new-top-left"> New </div>
                <div class="product-image">
                    <div class="large-image"> <asp:HyperLink ID="zoom1" runat="server" NavigateUrl="img-di/1.jpg" CssClass="cloud-zoom"> <asp:Image ID="imgMain" runat="server" ImageUrl="img-di/1.jpg" /> </asp:HyperLink> </div>
                    <div class="flexslider flexslider-thumb">
                      <ul class="previews-list slides">
                        <li><asp:HyperLink ID="hlnk1" runat="server" CssClass="cloud-zoom-gallery"><asp:Image ID="img1" runat="server" /></asp:HyperLink></li>
                        <%--<li><a href='img-di/1.jpg' class='cloud-zoom-gallery' rel="useZoom: 'zoom1', smallImage: 'img-di/1.jpg' "><asp:Image ID="img1" runat="server" ImageUrl="img-di/1.jpg" /></a></li>
                        <li><a href='img-di/2.jpg' class='cloud-zoom-gallery' rel="useZoom: 'zoom1', smallImage: 'img-di/2.jpg' "><asp:Image ID="img2" runat="server" ImageUrl="img-di/2.jpg" /></a></li>
                        <li><a href='img-di/3.jpg' class='cloud-zoom-gallery' rel="useZoom: 'zoom1', smallImage: 'img-di/3.jpg' "><asp:Image ID="img3" runat="server" ImageUrl="img-di/3.jpg" /></a></li>
                        <li><a href='img-di/4.jpg' class='cloud-zoom-gallery' rel="useZoom: 'zoom1', smallImage: 'img-di/4.jpg' "><asp:Image ID="img4" runat="server" ImageUrl="img-di/4.jpg" /></a></li>
                        <li><a href='img-di/5.jpg' class='cloud-zoom-gallery' rel="useZoom: 'zoom1', smallImage: 'img-di/5.jpg' "><asp:Image ID="img5" runat="server" ImageUrl="img-di/5.jpg" /></a></li>--%>
                      </ul>
                    </div>
                  </div>
                
                
                <!-- end: more-images -->
                
                <div class="clear"></div>
              </div>
              <div class="product-shop col-sm-8 col-xs-12 col-lg-7 wow bounceInRight animated">
                <div class="product-next-prev"> <a class="product-next" href="#"><span></span></a> <a class="product-prev" href="#"><span></span></a> </div>
                <div class="product-name">
                  <h1><asp:Label ID="lblProductName" runat="server"></asp:Label></h1>
                    <asp:HiddenField ID="hdnIdfr" runat="server" />
                </div>
               <%-- <div class="ratings">
                  <div class="rating-box">
                    <div style="width:60%" class="rating"></div>
                  </div>
                  <p class="rating-links"> <a href="#">1 Review(s)</a> <span class="separator">|</span> <a href="#">Add Your Review</a> </p>
                </div>--%>
                <p class="availability in-stock pull-right"><span>In Stock</span></p>
                <div class="price-block">
                  <div class="price-box">
                    <p class="old-price"> <span class="price-label">Regular Price:</span> <span class="price"> <asp:Label ID="lblMRP" runat="server"></asp:Label> </span> </p>
                    <p class="special-price"> <span class="price-label">Special Price</span> <span id="product-price-48" class="price"> <asp:Label ID="lblSalePrice" runat="server"></asp:Label> </span> </p>
                  </div>
                </div>
                <div class="short-description">
                  <h2>Quick Overview</h2>
                  <p><asp:Label ID="lblDesc" runat="server"></asp:Label></p>
                </div>
                <div class="add-to-box">
                  <div class="add-to-cart">
                    <label for="qty">Quantity:</label>
                    <div class="pull-left">
                      <div class="custom pull-left">
                        <asp:TextBox ID="txtqty" runat="server" CssClass="input-text qty" Text="1" maxlength="12" />
                        <button onClick="var result = document.getElementById('ContentPlaceHolder1_txtqty'); var qty = result.value; if( !isNaN( qty )) result.value++;return false;" class="increase items-count" type="button"><i class="icon-plus">&nbsp;</i></button>
                        <button onClick="var result = document.getElementById('ContentPlaceHolder1_txtqty'); var qty = result.value; if( !isNaN( qty ) &amp;&amp; qty &gt; 0 ) result.value--;return false;" class="reduced items-count" type="button"><i class="icon-minus">&nbsp;</i></button>
                      </div>
                    </div>
                    <div class="pull-left">
                      <%--<button onClick="productAddToCartForm.submit(this)" class="button btn-cart" title="Add to Cart" type="button"><span><i class="icon-basket"></i> Add to Cart</span></button>--%>
                        <asp:Button ID="btnCart" runat="server" CssClass="button btn-cart" title="Add to Cart" Text="Add to Cart" />
                        <asp:Button ID="btnBuy" runat="server" CssClass="button btn-cart" title="Buy" Text="Buy" BackColor="Blue" />
                    </div>
                  </div>
                  <div class="email-addto-box">
                    <ul class="add-to-links">
                      <li> <asp:LinkButton ID="lnkbtnWish" runat="server" Text="Add to Wishlist" ToolTip="Add to Wishlist" CssClass="link-wishlist"></asp:LinkButton></li>
                      <%--<li><span class="separator">|</span> <a class="link-compare" href="#"><span>Add to Compare</span></a></li>--%>
                    </ul>
                    <p class="email-friend"><a href="#" class=""><span>Email to a Friend</span></a></p>
                  </div>
                </div>


               <%--Attributes Gridview--%>

                 <div class="add-to-box">
                  <div class="add-to-cart">
                    <div class="pull-left">
                      <div class="custom pull-left">
                 <asp:GridView ID="gvAttributes" runat="server" AutoGenerateColumns="false">
                     <Columns>
                         <asp:TemplateField HeaderText="Attribute">
                             <ItemTemplate>
                                 <asp:DropDownList ID="ddlAttribute" runat="server" CssClass="input-text qty"></asp:DropDownList>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Value">
                             <ItemTemplate>
                                 <asp:DropDownList ID="ddlAttributeValue" runat="server" CssClass="input-text qty"></asp:DropDownList>
                         </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                      </div>
                    </div>
                  </div>
                </div>

              <%--Attributes Gridview End--%>

              </div>
          </div>
        </div>
       <div>
                           <div class="product-collateral wow bounceInUp animated">
          <div class="col-sm-12">
            <ul id="product-detail-tab" class="nav nav-tabs product-tabs">
              <li class="active" id="liDesc"> <a href="#product_tabs_description" data-toggle="tab"> Product Description </a> </li>
              <li id="liReview"> <a href="#product_tabs_tags" data-toggle="tab">Reviews</a> </li>
            </ul>
            <div class="tab-content" id="productTabContent">
              <div class="tab-pane fade in active" id="product_tabs_description">
                <div class="std">
                    <asp:Literal ID="lt1" runat="server"></asp:Literal>
                    <%--<asp:Label ID="lblLongDesc" runat="server"></asp:Label>--%>
                </div>
              </div>
              <div class="tab-pane fade" id="product_tabs_tags">
                <div class="box-collateral box-tags">
                  <div class="tags">
                    <div id="addTagForm">
                      <div class="form-add-tags">
                        <label for="productTagName">Add Tags:</label>
                        <div class="input-box">
                          <input class="input-text" name="productTagName" id="productTagName" type="text">
                          <button type="button" title="Add Tags" class=" button btn-add" onClick="submitTagForm()"> <span>Add Tags</span> </button>
                        </div>
                        <!--input-box--> 
                      </div>
                    </div>
                  </div>
                  <!--tags-->
                  <p class="note">Use spaces to separate tags. Use single quotes (') for phrases.</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        </div>
      </div>
    </div>
  </div>
</section>
<!-- Main Container End --> 

</asp:Content>

