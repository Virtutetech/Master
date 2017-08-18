
Partial Class ForgotPassword
    Inherits System.Web.UI.Page
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim obj As New ForgotPasswordClass
            lblmsg.Text = obj.GetPassword(txtEmail.Text.Trim.Replace("'", "`"))
            If lblmsg.Text.StartsWith("Error: ") = False Then
                SendEmail(lblmsg.Text)
                lblmsg.Text = "Password sent to your Email"
            End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub
    Sub SendEmail(Password As String)
        Dim msg As New System.Net.Mail.MailMessage()

        msg.From = New System.Net.Mail.MailAddress("Shopping@IndianDentalMart.com")

        msg.To.Add(txtEmail.Text.Trim)
        msg.Bcc.Add("shkzameer@gmail.com")

        msg.Subject = "IndianDentalMart - Password Recovery"

        msg.Body = "<table width='700px'><tr><td colspan='2'>Dear Customer,<br/><br/></td></tr><tr><td colspan='2'>Welcome to Indian Dental Mart. Please find below your Login details:</td></tr><tr><td><br/><br/>Please find below your Login details:</td></tr><tr><td><br/><br/>Username: " & txtEmail.Text.Trim & "<br/><br/></td></tr><tr><td>Password: " & Password & "</td></tr><tr><td colspan='2'><br/><br/>with regards,</td></tr><tr><td colspan='2'><br/><br/><a href='http://www.IndianDentalMart.com'>IDM Sales Team</a></td></tr></table>"
        msg.IsBodyHtml = True
        msg.Priority = System.Net.Mail.MailPriority.High
        Dim c As New System.Net.Mail.SmtpClient("mail.indianDentalmart.com", 25)

        c.Credentials = New System.Net.NetworkCredential("Shopping@IndianDentalMart.com", "idm@1234")
        c.EnableSsl = False
        Try
            c.Send(msg)
            ' lblmsg.Text = "Email Sent Successfully"
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

End Class

#Region "ForgotPasswordClass"

Public Class ForgotPasswordClass
    Inherits ConnectionClass

    Public Function GetPassword(ByVal Email As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Select Password from IMART_LoginDetails where Username='" & Email & "'"
            If cmd.ExecuteScalar Is Nothing Then
                Return "Error: Invalid Email/Username"
            Else
                Return CType(cmd.ExecuteScalar, String)
            End If
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


