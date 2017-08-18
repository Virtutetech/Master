<%@ Page Title="Bulk Upload Products" StylesheetTheme="MySkin" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="ProductUpload.aspx.vb" Inherits="ProductUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Upload Bulk Data</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">
                            
                             <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">Upload Excel File</label>
									<div class="col-sm-8">
										<asp:FileUpload ID="fileupload1" runat="server" />
									</div>
								</div>
							</div>
							
                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Button ID="btnUpload" runat="server" CssClass="btn-success btn" Text="Upload to DB" />
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
									<div class="col-sm-12">
										<asp:GridView ID="gv" runat="server" SkinID="MyGrid" width="100%" AutoGenerateColumns="true">
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

