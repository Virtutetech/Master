<%@ Page Title="Event Details" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="EventDetails.aspx.vb" Inherits="EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
<div class="breadcrumbs">
  <div class="container">
    <div class="row">
      <ul>
        <li class="home"> <a title="Go to Home Page" href="Default.aspx">Home</a><span>&mdash;›</span></li>
          <li class=""> <a title="Events Page" href="Events.aspx">Events</a><span>&mdash;›</span></li>
        <li class="category13"><strong><asp:Label ID="lblEvent" runat="server"></asp:Label></strong></li>
      </ul>
    </div>
  </div>
</div>
<!-- Breadcrumbs End -->
    <!-- Main Container -->
<section class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <div class="col-main col-sm-9">
        <div class="blog-wrapper" id="main">
          <div class="site-content" id="primary">
            <div role="main" id="content">
              <article class="blog_entry clearfix wow bounceInLeft animated">
                <header class="blog_entry-header clearfix">
                  <div class="blog_entry-header-inner">
                    <h2 class="blog_entry-title"> <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                      <p> <asp:Label ID="lblEventDate" runat="server"></asp:Label></p>
                  </div>
                  <!--blog_entry-header-inner--> 
                </header>
                <!--blog_entry-header clearfix-->
                <div class="entry-content">
                  <div class="featured-thumb"><a href="#"><asp:Image ID="img1" runat="server" /></a></div>
                  <div class="entry-content" id="divContent" runat="server" style="padding-top:29px;">
                   
                  </div>
                </div>
              </article>
            </div>
          </div>
        </div>
      </div>
      <aside class="col-right sidebar col-sm-3 wow bounceInRight animated">
        <div role="complementary" class="widget_wrapper13" id="secondary">
          <!-- Banner Ad Block -->
          <div class="ad-spots widget widget__sidebar">
            <h3 class="widget-title">Exclusive Products</h3>
            <div class="widget-content"><img alt="offer banner" src="images/132A8787.jpg" style="max-width:100%;height:auto;vertical-align:top;" /></div>
          </div>
        </div>
      </aside>
    </div>
  </div>
</section>
<!-- Main Container End -->
</asp:Content>

