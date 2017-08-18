<%@ Page Title="Add Product Attributes" Language="VB" MasterPageFile="~/MasterAdmin.master" StylesheetTheme="MySkin" AutoEventWireup="false" CodeFile="AddAttributes.aspx.vb" Inherits="AddAttributes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Product Attributes</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							<div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Enter Attribute Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtAttribute" runat="server" type="text" class="form-control1 input-lg" />
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
                                                <asp:BoundField DataField="AttributeIdfr" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="AttributeName" HeaderText="Name" />
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





