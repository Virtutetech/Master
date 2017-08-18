<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Enter Folder Name
        <br />
        <asp:TextBox ID="txtFolder" runat="server"></asp:TextBox>
      
        <br /><br />
        Select a file to upload
        <br /><br />
        <asp:FileUpload ID="fp1" runat="server"></asp:FileUpload>
        <br /><br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" BackColor="Red" ForeColor="White" OnClick="btnUpload_Click" />
        <br /><br />
         <asp:Label ID="lblresult" runat="server" ForeColor="Red"></asp:Label>
        <br /><br />
        <asp:LinkButton Text="Download" runat="server" ID="lnkbtn" OnClick="lnkbtn_Click" />
    </div>
    </form>
</body>
</html>
