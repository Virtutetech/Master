<%@ Page Title="Contact - Indian Dental Mart" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .mybtn
        {
            border: 1px #ed5565 solid;
    background: #f1f6f9;
    border-radius: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
<div class="breadcrumbs">
  <div class="container">
    <div class="row">
      <ul>
        <li class="home"> <a title="Go to Home Page" href="Default.aspx">Home</a><span>&mdash;›</span></li>
        <li class="category13"><strong>Contact Us</strong></li>
      </ul>
    </div>
  </div>
</div>
<!-- Breadcrumbs End -->
<!-- Main Container -->
<div class="main-container col2-right-layout">
  <div class="main container">
    <div class="row">
      <section class="col-main col-sm-6">
          <div class="page-title">
          <h2>Company Address</h2>
        </div>
          <div class="block block-company">
          <div class="block-content">
                <h4><a>Indian Dental Mart</a></h4>
              <p><a>313, 2nd Floor</a></p>
              <p><a>24th main, 6th Phase, JP Nagar</a></p>
              <p><a>Bengaluru, Karnataka 560078</a></p>
              <p><a>+91 89719 23442</a></p>
              <p><a>Pavan@indiandentalmart.com</a></p>
              <p><a>Whatsapp: +91 89719 23442</a></p>
          </div>
        </div>

        <div class="page-title">
          <h2>Write to Us</h2>
        </div>
        <div class="static-contain">
          <fieldset class="group-select">
            <ul>
              <li id="billing-new-address-form">
                <fieldset>
                  <legend>New Address</legend>
                  <ul>
                    <li>
                      <div class="customer-name">
                        <div class="input-box name-firstname">
                          <label> Name<span class="required">*</span></label>
                          <br />
                          <input type="text" id="billing:firstname" name="billing[firstname]" title="First Name" class="input-text " />
                        </div>
                      </div>
                    </li>
                    <li>
                      <div class="input-box">
                        <label>Email<span class="required">*</span></label>
                        <br />
                        <input type="text" name="billing[company]" title="Company" class="input-text" />
                      </div>
                     
                    </li>
                    <li>
                      <div class="input-box">
                        <label>Phone</label>
                        <br />
                        <input type="text" name="billing[company]" title="Company" class="input-text" />
                      </div>
                    </li>
                    <li class="">
                      <label>Message<em class="required">*</em></label>
                      <br />
                      <div style="float:none" class="">
                        <textarea name="comment" id="comment" title="Comment" class="input-text" cols="5" rows="3"></textarea>
                      </div>
                    </li>
                  </ul>
                </fieldset>
              </li>
              
            </ul>
              <div class="buttons-set">
                <asp:Button ID="btnSubmit" runat="server" CssClass="button submit" Text="Submit"></asp:Button>
              </div>
          </fieldset>
        </div>

           
      </section>

      <aside class="col-right sidebar col-sm-6">
<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3889.0544243828986!2d77.58346031425121!3d12.904221990900117!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bae1514a5ef4b8b%3A0x8f90340bb4d0bc5b!2sIndian+Dental+Mart!5e0!3m2!1sen!2sin!4v1498736050055" width="100%" height="565" frameborder="0" style="border:0" allowfullscreen></iframe>
      </aside>
    </div>
  </div>
</div>
<!-- Main Container End -->
</asp:Content>

