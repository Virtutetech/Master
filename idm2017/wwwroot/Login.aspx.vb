
Partial Class Login
    Inherits System.Web.UI.Page
    Dim obj As New LoginClass
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dt As New Data.DataTable
        Try
            dt = obj.GetLoginDetails(txtEmail.Text.Trim.Replace("'", "`"), txtPassword.Text.Trim.Replace("'", "`"))
            If dt.Rows.Count <= 0 Then
                lblmsg.Text = "Invalid Username/Password"
                Exit Sub
            End If

        Catch ex As Exception
            lblmsg.Text = ex.Message
            Exit Sub
        End Try
        If dt.Rows(0).Item("UserLevel").ToString = "SUPERADMIN" Then
            Session("UserIdfr") = dt.Rows(0).Item("UserIdfr")
            Session("UserLevel") = dt.Rows(0).Item("UserLevel")
            Response.Redirect("SuperAdminHome.aspx", True)
        ElseIf dt.Rows(0).Item("UserLevel").ToString = "USER" Then
            Session("UserIdfr") = dt.Rows(0).Item("UserIdfr")
            Session("UserLevel") = dt.Rows(0).Item("UserLevel")
            MoveTempCarttoUserCart()
        End If
    End Sub

    Sub MoveTempCarttoUserCart()
        If Request.Cookies("IDMCart") Is Nothing Then
            Response.Redirect("Default.aspx", True)
        Else
            Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
            lblmsg.Text = obj.MoveTemptoUserCart(Session("UserIdfr"), IDMCookie.Values("CartId"))
            If lblmsg.Text = "OK" Then
                Response.Redirect("Default.aspx", True)
            End If
        End If
    End Sub


End Class

#Region "LoginClass"

Public Class LoginClass
    Inherits ConnectionClass
    Public Function GetLoginDetails(Username As String, Password As String) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select UserLevel,UserIdfr from IMART_LoginDetails where Username='" & Username & "' and Password='" & Password & "'", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function MoveTemptoUserCart(ByVal UserIdfr As Integer, CartId As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Insert into IMART_TempUserCart(UserIdfr,ProductIdfr,CartDate,Quantity) Select " & UserIdfr & ",t1.ProductIdfr,t1.CartDate,t1.Quantity from IMART_TempGuestCart t1 where CartId='" & CartId & "' and NOT EXISTS (SELECT PRODUCTIDFR from IMART_TempUserCart t2 where t2.ProductIdfr=t1.ProductIdfr)"
            cmd.ExecuteNonQuery()
            Return "OK"
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



