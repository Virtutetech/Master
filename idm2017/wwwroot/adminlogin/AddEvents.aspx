<%@ Page Title="Add Events" Language="VB" StylesheetTheme="MySkin" ValidateRequest="false" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="AddEvents.aspx.vb" Inherits="AddEvents" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    </div>
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Add Events</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							<div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Event Title</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtEventTitle" runat="server" type="text" class="form-control1 input-lg" />
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Event Date</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtDate" runat="server" type="text" class="form-control1 input-lg" />
									    <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
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
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Event Description</label>
									<div class="col-sm-8">
										<asp:TextBox ID="txtDesc" runat="server" type="text" class="form-control1 input-lg" Height="200" />
									    <asp:HtmlEditorExtender ID="txtDesc_HtmlEditorExtender" runat="server" Enabled="True" TargetControlID="txtDesc">
                                        </asp:HtmlEditorExtender>
									</div>
								</div>
							</div>

                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Image</label>
									<div class="col-sm-8">
										<asp:Image ID="img" runat="server" Width="50px" Height="50px" />
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
                                                <asp:BoundField DataField="EventIdfr" HeaderText="EventIdfr" Visible="false" />
                                                <asp:BoundField DataField="EventTitle" HeaderText="EventTitle" />
                                                <asp:BoundField DataField="EventDate" HeaderText="EventDate" />
                                                <asp:BoundField DataField="ShortDesc" HeaderText="Description" />
                                                
                                                  <asp:TemplateField HeaderText="Image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="img1" runat="server" Width="40" Height="50" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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

