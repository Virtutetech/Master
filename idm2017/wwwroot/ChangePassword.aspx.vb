
Partial Class ChangePassword
    Inherits System.Web.UI.Page
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Response.Redirect("Default.aspx", True)
        End If
        If Session("UserIdfr").ToString = "" Then
            Response.Redirect("Default.aspx", True)
        End If
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtPassword.Text.ToString.Contains("/") Or txtPassword.Text.ToString.Contains("'") Or txtPassword.Text.ToString.Contains("&") Then
                lblmsg.Text = "Password cannot contain Special characters ( / ' &)"
                Exit Sub
            End If
            Dim obj As New ChangePasswordClass
            lblmsg.Text = obj.UpdatePassword(Session("UserIdfr"), txtOldPassword.Text.Trim.Replace("'", "`"), txtPassword.Text.Trim.Replace("'", "`"))
            If lblmsg.Text = "OK" Then
                lblmsg.Text = "Password updation success"
            End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

End Class

#Region "ChangePasswordClass"

Public Class ChangePasswordClass
    Inherits ConnectionClass

    Public Function UpdatePassword(ByVal UserIdfr As Integer, OldPassword As String, NewPassword As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Select password from IMART_LoginDetails where UserIdfr=" & UserIdfr & " and Password='" & OldPassword & "'"
            If cmd.ExecuteScalar Is Nothing Then
                Return "Error: Invalid Current Password"
            Else
                cmd.CommandText = "Update IMART_LoginDetails set password='" & NewPassword & "' where UserIdfr=" & UserIdfr & ""
                cmd.ExecuteNonQuery()
            End If
            Return "OK"
        Catch ex As Data.SqlClient.SqlException
            Return "Error: " & ex.Message
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region


