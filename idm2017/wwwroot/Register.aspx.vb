
Partial Class Register
    Inherits System.Web.UI.Page
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim obj As New RegisterClass
            Dim Password As String = AutoCode()
            lblmsg.Text = obj.CheckUniqueEmail(txtEmail.Text.Trim.Replace("'", "`"))
            If lblmsg.Text = "OK" Then
                lblmsg.Text = obj.Insert(txtEmail.Text.Trim.Replace("'", "`"), Password)
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = "Password sent to your Email"
                    SendEmail(Password)
                End If
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

        msg.Subject = "IndianDentalMart - Login Details"

        msg.Body = "<table width='700px'><tr><td colspan='2'>Dear Customer,<br/><br/></td></tr><tr><td colspan='2'>Welcome to Indian Dental Mart. Thankyou for registering with us.</td></tr><tr><td><br/><br/>Please find below your Login details:</td></tr><tr><td><br/><br/>Username: " & txtEmail.Text.Trim & "<br/><br/></td></tr><tr><td>Password: " & Password & "</td></tr><tr><td colspan='2'><br/><br/>with regards,</td></tr><tr><td colspan='2'><br/><br/><a href='http://www.IndianDentalMart.com'>IDM Sales Team</a></td></tr></table>"
        msg.IsBodyHtml = True
        msg.Priority = System.Net.Mail.MailPriority.High
        Dim c As New System.Net.Mail.SmtpClient("mail.indiandentalmart.com", 25)

        c.Credentials = New System.Net.NetworkCredential("Shopping@IndianDentalMart.com", "idm@1234")
        c.EnableSsl = False
        Try
            c.Send(msg)
            ' lblmsg.Text = "Email Sent Successfully"
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub
    Function AutoCode() As String
        Dim obj As New RegisterClass
        Dim randObj As New Random()
        Dim x As String = ""
        For i As Byte = 0 To 9
            x &= randObj.Next(1, 9)
            'If (Now.Second + Now.Minute) >= 65 And (Now.Second + Now.Minute) <= 90 Then
            '     x &= Chr(randObj.Next(65, 90))
            ' ElseIf (Now.Second + Now.Minute) >= 49 And (Now.Second + Now.Minute) <= 57 Then
            '     x &= Chr(randObj.Next(65, 90))
            ' ElseIf (Now.Second + Now.Minute) >= 97 And (Now.Second + Now.Minute) <= 122 Then
            '     x &= Chr(randObj.Next(65, 90))
            ' Else
            '     x &= randObj.Next(1, 9)
            ' End If
        Next
        If obj.CheckUnique(x) <> "OK" Then
            x = AutoCode()
        End If

        Return x
    End Function

End Class

#Region "RegisterClass"

Public Class RegisterClass
    Inherits ConnectionClass
    Public Function CheckUnique(ByVal Password As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Select Username from IMART_LoginDetails where Password='" & Password & "'"
            If cmd.ExecuteScalar Is Nothing Then
                Return "OK"
            Else
                Return "Password already exists"
            End If
        Catch ex As Data.SqlClient.SqlException
            Return ex.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function CheckUniqueEmail(ByVal Email As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Select Username from IMART_LoginDetails where Username='" & Email & "'"
            If cmd.ExecuteScalar Is Nothing Then
                Return "OK"
            Else
                Return "Email already registered.. Try another"
            End If
        Catch ex As Data.SqlClient.SqlException
            Return ex.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Insert(Email As String, Password As String) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Insert into IMART_LoginDetails(Username,password,UserLevel,OTP,OTPStatus,RegDate,RegId,LastLoginDate,DeviceType,UserStatus) values ('" & Email & "','" & Password & "','USER','" & Password & "','NO','" & DateTime.Now.AddMinutes(1) & "','-','" & DateTime.Now.AddMinutes(1) & "','W','ACTIVE')"
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            Return "OK"
        Catch ex As Data.SqlClient.SqlException
            myTrans.Rollback()
            Return ex.Message
        Catch ex As Exception
            myTrans.Rollback()
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region

