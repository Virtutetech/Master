
Imports System.Data.SqlClient

Partial Class MyAddressBook
    Inherits System.Web.UI.Page
    Dim obj As New MyAddressBookClass
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
        dt = obj.GetAllAddresses(Session("UserIdfr"))
        gvOrders.Columns(0).Visible = True
        gvOrders.DataSource = dt
        gvOrders.DataBind()
        gvOrders.Columns(0).Visible = False
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No Address found"
        End If
    End Sub

    Protected Sub gvOrders_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If

    End Sub

    Protected Sub lnkbtnView_Click(sender As Object, e As EventArgs)
        Dim btn As New LinkButton
        btn = sender
        Dim tr As TableRow = btn.Parent.Parent
        hdnIdfr.Value = tr.Cells(0).Text
        txtName.Text = tr.Cells(1).Text
        txtAddress.Text = tr.Cells(2).Text
        txtLandmark.Text = tr.Cells(3).Text
        txtPincode.Text = tr.Cells(4).Text
        txtCity.Text = tr.Cells(5).Text
        txtState.Text = tr.Cells(6).Text
        txtPhone1.Text = tr.Cells(7).Text
        btnUpdate.Text = "Update"
        'gvIn.DataSource = obj.GetAllOrderGoodss(tr.Cells(0).Text)
        'gvIn.DataBind()
        lblAddEdit.Text = "Edit Address"
        popup.Show()
    End Sub
    Protected Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        hdnIdfr.Value = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtLandmark.Text = ""
        txtPincode.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtPhone1.Text = ""
        btnUpdate.Text = "Submit"
        lblAddEdit.Text = "Add New Address"
        popup.Show()
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If btnUpdate.Text = "Submit" Then
                lblpopupmsg.Text = obj.InsertOrders(Session("UserIdfr"), txtName.Text.Trim.Replace("'", "`"), txtAddress.Text.Trim.Replace("'", "`"), txtLandmark.Text.Trim.Replace("'", "`"), txtPincode.Text.Trim.Replace("'", "`"), txtCity.Text.Trim.Replace("'", "`"), txtState.Text.Trim.Replace("'", "`"), txtPhone1.Text.Trim.Replace("'", "`"))
                If lblpopupmsg.Text = "OK" Then
                    lblmsg.Text = "Insertion success"
                    BindGrid()
                    hdnIdfr.Value = ""
                    txtName.Text = ""
                    txtAddress.Text = ""
                    txtLandmark.Text = ""
                    txtPincode.Text = ""
                    txtCity.Text = ""
                    txtState.Text = ""
                    txtPhone1.Text = ""
                    popup.Hide()
                    lblpopupmsg.Text = ""
                Else
                    popup.Show()
                End If
            Else
                lblpopupmsg.Text = obj.UpdateOrders(Session("UserIdfr"), hdnIdfr.Value, txtName.Text.Trim.Replace("'", "`"), txtAddress.Text.Trim.Replace("'", "`"), txtLandmark.Text.Trim.Replace("'", "`"), txtPincode.Text.Trim.Replace("'", "`"), txtCity.Text.Trim.Replace("'", "`"), txtState.Text.Trim.Replace("'", "`"), txtPhone1.Text.Trim.Replace("'", "`"))
                If lblpopupmsg.Text = "OK" Then
                    lblmsg.Text = "Updation success"
                    BindGrid()
                    hdnIdfr.Value = ""
                    txtName.Text = ""
                    txtAddress.Text = ""
                    txtLandmark.Text = ""
                    txtPincode.Text = ""
                    txtCity.Text = ""
                    txtState.Text = ""
                    txtPhone1.Text = ""
                    popup.Hide()
                    lblpopupmsg.Text = ""
                    lblAddEdit.Text = "Add New Address"
                Else
                    popup.Show()
                End If
            End If

        Catch ex As Exception
            lblmsg.Text = ex.Message
            lblpopupmsg.Text = ex.Message
        End Try

    End Sub
End Class

#Region "MyAddressBookClass"

Public Class MyAddressBookClass
    Inherits ConnectionClass
    Public Function GetAllAddresses(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select [AddressIdfr],[UserIdfr],[PersonName],[Address],[Landmark],[Pincode],[City],[State],[Phone] from IMART_ShippingAddress where UserIdfr=" & UserIdfr & " order by AddressIdfr", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function UpdateOrders(UserIdfr As Integer, AddressIdfr As Integer, Name As String, Address As String, Landmark As String, Pincode As String, City As String, State As String, Phone As String) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand("Update IMART_ShippingAddress set PersonName='" & Name & "',Address='" & Address & "',Landmark='" & Landmark & "',Pincode='" & Pincode & "',City='" & City & "',State='" & State & "',Phone='" & Phone & "' where  AddressIdfr=" & AddressIdfr & " and UserIdfr=" & UserIdfr & "", Con)
            Con.Open()
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function InsertOrders(UserIdfr As Integer, Name As String, Address As String, Landmark As String, Pincode As String, City As String, State As String, Phone As String) As String
        Try
            cmd.CommandText = "Insert into IMART_ShippingAddress(UserIdfr,PersonName,Address,Landmark,Pincode,City,State,Phone) values(" & UserIdfr & ",'" & Name & "','" & Address & "','" & Landmark & "','" & Pincode & "','" & City & "','" & State & "','" & Phone & "')"
            Con.Open()
            cmd.ExecuteNonQuery()
            Return "OK"
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function GetUsername(UserIdfr As Integer) As String
        Try
            Con.Open()

            cmd.CommandText = "Select ClientName from IMART_CustomerDetails where CustomerIdfr=" & UserIdfr & ""
            Return CType(cmd.ExecuteScalar, String)
        Catch ex As SqlException
            Return ex.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region


