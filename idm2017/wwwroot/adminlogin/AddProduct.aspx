<%@ Page Title="Add Product - Indian Dental Mart" StylesheetTheme="MySkin" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="AddProduct.aspx.vb" Inherits="AddProduct" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    </div>
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Product</h3>
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
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">MRP</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtMRP" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Sale Price</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtSalePrice" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>
                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Product Description</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtDesc" runat="server" type="text" class="form-control1 input-lg" Height="200" />
									    <asp:HtmlEditorExtender ID="txtDesc_HtmlEditorExtender" runat="server" Enabled="True" TargetControlID="txtDesc">
                                        </asp:HtmlEditorExtender>
									</div>
								</div>
							</div>
                         
                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Keywords</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtKeywords" runat="server" type="text" class="form-control1 input-lg" TextMode="MultiLine" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Image ID="img1" runat="server" Width="40" Height="50" Visible="false" />
									</div>
								</div>
							</div>


                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Upload Image</label>
									<div class="col-sm-8">
										<asp:FileUpload ID="fileupload1" runat="server" />
									</div>
								</div>
							</div>
                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Status</label>
									<div class="col-sm-8">
										<asp:DropDownList ID="ddlStatus" runat="server" class="myddl">
                                            <asp:ListItem Text="ACTIVE"></asp:ListItem>
                                            <asp:ListItem Text="INACTIVE"></asp:ListItem>
                                        </asp:DropDownList>
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
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Button ID="btnSubmit" runat="server" CssClass="btn-success btn" Text="Save" />
									</div>
								</div>
							</div>


                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<div class="col-sm-12">
										<asp:GridView ID="gv" runat="server" SkinID="MyGrid" width="100%" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" ForeColor="Blue" OnClick="lnkEdit_Click"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ProductIdfr" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="ProductName" HeaderText="Name" />
                                                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                                                <asp:BoundField DataField="ShortDescription" HeaderText="Desc" />
                                                <asp:BoundField DataField="MRP" HeaderText="MRP" />
                                                <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" />
                                                  <asp:TemplateField HeaderText="Image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="img1" runat="server" Width="40" Height="50" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BrandIdfr" HeaderText="Brand" />
                                                <asp:BoundField DataField="AStatus" HeaderText="Status" />
                                                <asp:BoundField DataField="Keywords" HeaderText="Keywords" Visible="false" />
                                            </Columns>
										</asp:GridView>
									</div>
								</div>
							</div>

						</div>
					</div>
				</div>
			</div>

    <div>
        <asp:HiddenField ID="hdnId" runat="server" />
    </div>
</asp:Content>

