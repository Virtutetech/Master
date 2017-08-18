
Partial Class MyProfile
    Inherits System.Web.UI.Page
    Dim obj As New MyProfileClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Response.Redirect("Default.aspx", True)
        End If
        If Session("UserIdfr").ToString = "" Then
            Response.Redirect("Default.aspx", True)
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                BindGrid()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If

    End Sub

    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetDetails(Session("UserIdfr"))
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtName.Text = .Item("ClientName").ToString
                txtAddress.Text = .Item("Address").ToString
                txtPhone1.Text = .Item("Phone").ToString
                txtEmail.Text = .Item("Email").ToString
                txtCity.Text = .Item("CityName").ToString
                txtState.Text = .Item("StateName")
            End With
        End If
    End Sub


    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblmsg.Text = obj.UpdateDetails(Session("UserIdfr"), txtName.Text.Trim.Replace("'", "`"), txtAddress.Text.Trim.Replace("'", "`"), txtPhone1.Text.Trim.Replace("'", "`"), txtEmail.Text.Trim.Replace("'", "`"), txtCity.Text.Trim.Replace("'", "`"), txtState.Text.Trim.Replace("'", "`"))
    End Sub
End Class

#Region "MyProfileClass"

Public Class MyProfileClass
    Inherits ConnectionClass
    Public Function GetDetails(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ClientName,Address,Phone,Email,CityName,StateName from IMART_CustomerDetails where CustomerIdfr=" & UserIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function UpdateDetails(UserIdfr As Integer, ClientName As String, Address As String, Phone As String, Email As String, CityName As String, StateName As String) As String
        Try
            Con.Open()

            cmd.CommandText = "Update IMART_CustomerDetails set ClientName='" & ClientName & "',Address='" & Address & "',Phone='" & Phone & "',Phone2='-',Email='" & Email & "',CityName='" & CityName & "',StateName='" & StateName & "' where CustomerIdfr=" & UserIdfr & ""
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

End Class

#End Region


