<%@ Page Title="Add Exclusive Products" StylesheetTheme="MySkin" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="AddExProduct.aspx.vb" Inherits="AddExProduct" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .mytxt
        {
            width:75%!important;
            margin:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Exclusive Product</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							<div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Main Category</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlCategory1" runat="server" class="myddl" AutoPostBack="true" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Sub Category1</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlCategory2" runat="server" class="myddl" AutoPostBack="true" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Sub Category2</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlCategory3" runat="server" class="myddl" AutoPostBack="true" />
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Sub Category3</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlCategory4" runat="server" class="myddl" AutoPostBack="true" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Manufacturer/Brand</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlBrand" runat="server" class="myddl" />
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Product Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtProduct" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Short Description</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtShortDesc" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>
                            
                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<div class="col-sm-10">
										<asp:GridView ID="gvAttributes" runat="server" SkinID="MyGrid" width="100%" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="AttributeIdfr" HeaderText="Idfr" Visible="false" />
                                                
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="AttributeName" HeaderText="Attribute" ItemStyle-VerticalAlign="Top" />
                                                <asp:TemplateField HeaderText="Enter Attributes Values">
                                                    <ItemTemplate>
                                                                        <asp:GridView ID="gvIn" runat="server" AutoGenerateColumns="false" SkinID="MyGrid" width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Value">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtValue" runat="server" CssClass="form-control1 input-lg mytxt"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Description">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control1 input-lg mytxt"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                        <br />
                                                        <div style="float:right;">
                                                        <asp:Button ID="btnMore" runat="server" Text="Add more" CssClass="btn-success btn" OnClick="btnMore_Click" />
                                                            </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
										</asp:GridView>
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-4 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-6">
										<asp:Button ID="btnContinue" runat="server" CssClass="btn-success btn" Text="Continue.." />
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
        </asp:View>
        <asp:View ID="View2" runat="server">
             <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Exclusive Product</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">
                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<div class="col-sm-12">
										<asp:GridView ID="gvAttPrices" runat="server" SkinID="MyGrid" width="100%" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Idfr" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="TransIdfr" HeaderText="Trans" Visible="false" />
                                                <asp:BoundField DataField="TransName" HeaderText="Product" />
                                                  <asp:TemplateField HeaderText="MRP">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtMRP" runat="server" CssClass="form-control1 input-lg mytxt"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SalePrice">
                                                                                    <ItemTemplate>
                                                                  <asp:TextBox ID="txtSalePrice" runat="server" CssClass="form-control1 input-lg mytxt"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Image">
                                                   <ItemTemplate>
                                                       <table width="100%">
                                                           <tr>
                                                               <td>
                                                                   <asp:FileUpload ID="fp1" runat="server" />&nbsp;
                                                               </td>
                                                               <td>
                                                                   <asp:Button ID="btnGo" runat="server" CssClass="btn" Width="75px" Text="Upload" BackColor="Green" OnClick="btnGo_Click" />
                                                               </td>
                                                           </tr>
                                                       <tr>
                                                           <td colspan="2"><asp:Label ID="lblupmsg" runat="server" ForeColor="Green"></asp:Label></td>
                                                       </tr>
                                                           </table>
                                                   </ItemTemplate>

                                               </asp:TemplateField>
                                                   
                                            </Columns>
										</asp:GridView>
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Label ID="lblmsg2" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Button ID="btnSubmit" runat="server" CssClass="btn-success btn" Text="Submit" />
									</div>
								</div>
							</div>
                            </div>
					</div>
				</div>
			</div>
        </asp:View>
    </asp:MultiView>
    

    <div>
        <asp:HiddenField ID="hdnId" runat="server" />
    </div>
</asp:Content>


