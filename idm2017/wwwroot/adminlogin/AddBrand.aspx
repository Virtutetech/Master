<%@ Page Title="Add Brand" StylesheetTheme="MySkin" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="AddBrand.aspx.vb" Inherits="AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Brand</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							<div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Enter Brand Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtBrand" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>

                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Image ID="img1" runat="server" Width="100" Height="100" Visible="false" />
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
                                                <asp:BoundField DataField="BrandIdfr" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="BrandName" HeaderText="Name" />
                                                <asp:TemplateField HeaderText="Image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="img1" runat="server" Width="40" Height="50" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
        <asp:HiddenField ID="hdnIdfr" runat="server" />
    </div>
</asp:Content>



