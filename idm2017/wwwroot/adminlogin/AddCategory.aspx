<%@ Page Title="Add Category - Indian Dental Mart" StylesheetTheme="MySkin" EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="AddCategory.aspx.vb" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Category</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							<div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Enter Category Name</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtCategory" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Parent Category</label>
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
										<asp:DropDownList ID="ddlCategory3" runat="server" class="myddl" />
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
                                        <asp:HiddenField ID="hdnIdfr" runat="server" />
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
                                                <asp:BoundField DataField="CategoryIdfr" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                                                <asp:BoundField DataField="CategoryIdfr1" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="MainCategory" HeaderText="MainCategory" />
                                                <asp:BoundField DataField="CategoryIdfr2" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="SubCategory1" HeaderText="SubCategory1" />
                                                <asp:BoundField DataField="CategoryIdfr3" HeaderText="Idfr" Visible="false" />
                                                <asp:BoundField DataField="SubCategory2" HeaderText="SubCategory2" />
                                                <asp:BoundField DataField="AStatus" HeaderText="Status" />
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

