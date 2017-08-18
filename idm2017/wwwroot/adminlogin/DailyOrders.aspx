<%@ Page Title="Today Orders" Language="VB" StylesheetTheme="MySkin" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="DailyOrders.aspx.vb" Inherits="DailyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <!-- main content start-->
		<div class="main-content main-content4">
			
			<div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Daily Orders</h3>
                    <h3><asp:Label ID="lblmsg" runat="server"></asp:Label></h3>
					 <div class="xs tabls">
						<div class="bs-example4" data-example-id="contextual-table">
                            <asp:GridView ID="gv" runat="server" SkinID="RptGrid">
    </asp:GridView>
						
					   </div>
					 
					</div>
				</div>
			</div>
		</div>
</asp:Content>

