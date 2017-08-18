
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtUsername.Text.ToUpper = "ADMIN" And txtPassword.Text.ToUpper = "ADMIN" Then
            Server.Transfer("Dashboard.aspx", False)
        End If
    End Sub
End Class
