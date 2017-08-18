<%@ Page Title="Download Products" Language="VB" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="false" CodeFile="ProductDownload.aspx.vb" Inherits="ProductDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
				<div class="graphs">
					<h3 class="blank1">Download Data</h3>
						<div class="tab-content">
						<div class="tab-pane active" id="horizontal-form">

							
                            <div class="form-horizontal">
                                <div class="form-group mb-n">
									<label for="largeinput" class="col-sm-2 control-label label-input-lg">&nbsp;</label>
									<div class="col-sm-8">
										<asp:Button ID="btnExport" runat="server" CssClass="btn-success btn" Text="Export to Excel" />
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

                            
						</div>
					</div>
				</div>
			</div>

    <div>
        <asp:HiddenField ID="hdnIdfr" runat="server" />
    </div>
</asp:Content>



