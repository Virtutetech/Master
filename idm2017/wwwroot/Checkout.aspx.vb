
Imports System.Data.SqlClient

Partial Class Checkout
    Inherits System.Web.UI.Page
    Dim obj As New CheckoutClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Response.Redirect("Login.aspx", True)
        Else
            Page.MasterPageFile = "MasterUser.master"
            Response.ClearHeaders()
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate")
            Response.AddHeader("Pragma", "no-cache")
        End If
        If Session("UserIdfr").ToString = "" Then
            Response.Redirect("Login.aspx", True)
        Else
            Page.MasterPageFile = "MasterUser.master"
            Response.ClearHeaders()
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate")
            Response.AddHeader("Pragma", "no-cache")
        End If


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        If Not IsPostBack Then
            Try

                MultiView1.ActiveViewIndex = 0
                BindAddress()
                BindCart()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub BindAddress()
        Dim dt As New Data.DataTable
        dt = obj.GetAddresses(Session("UserIdfr"))
        ddlAddress.DataSource = dt
        ddlAddress.DataValueField = "AddressIdfr"
        ddlAddress.DataTextField = "AddressName"
        ddlAddress.DataBind()
        If dt.Rows.Count <= 0 Then
            ddlAddress.Items.Add(New ListItem("New Address", 0))
            Exit Sub
        End If
        ddlAddress.Items.Add(New ListItem("New Address", 0))
        Dim dr() As System.Data.DataRow = dt.Select("AddressIdfr=" & ddlAddress.SelectedValue)
        With dr(0)
            txtName.Text = .Item("PersonName").ToString
            txtAddress.Text = .Item("Address").ToString
            txtLandmark.Text = .Item("Landmark").ToString
            txtZipcode.Text = .Item("Pincode").ToString
            txtCity.Text = .Item("City").ToString
            txtState.Text = .Item("State").ToString
            txtPhone.Text = .Item("Phone").ToString
        End With
    End Sub
    Sub BindCart()

        Dim dt As New Data.DataTable
        dt = obj.GetUserTempCart(Session("UserIdfr"))
        Dim str As New System.Text.StringBuilder
            str.Append("<dl>")
            str.Append("<dt Class='complete'> Product | Qty | Price</dt>")
            Dim TotalPrice As Decimal = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                str.Append("<dd Class='complete'>" & dt.Rows(i).Item("ProductName") & "<br />Qty - " & dt.Rows(i).Item("Quantity").ToString & "<br/>")
                str.Append("<span Class='price'>Price: " & dt.Rows(i).Item("SalePrice") & "</span><hr/> </dd>")
                TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice")) * Val(dt.Rows(i).Item("Quantity").ToString))
            Next
            str.Append("<dt Class='complete'>Total Amount</dt>")
            str.Append("<dd Class='complete'><span Class='price'>" & TotalPrice & "</span></dd>")

            str.Append("</dl>")
            divCartSummary.InnerHtml = str.ToString
            lblTotal.Text = TotalPrice
            lblGTotal.Text = TotalPrice


    End Sub

    Protected Sub ddlAddress_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAddress.SelectedIndexChanged
        txtName.Text = ""
        txtAddress.Text = ""
        txtLandmark.Text = ""
        txtZipcode.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtPhone.Text = ""
        Dim dt As New Data.DataTable
        dt = obj.GetAddressDetails(ddlAddress.SelectedValue)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                txtName.Text = .Item("PersonName").ToString
                txtAddress.Text = .Item("Address").ToString
                txtLandmark.Text = .Item("Landmark").ToString
                txtZipcode.Text = .Item("Pincode").ToString
                txtCity.Text = .Item("City").ToString
                txtState.Text = .Item("State").ToString
                txtPhone.Text = .Item("Phone").ToString
            End With
        End If
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If TryCast(Session("CartTable"), Data.DataTable) Is Nothing Then

        Else
            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
            If gvCart.Rows.Count <= 0 Then
                lblmsg.Text = "Your Shopping Cart is empty"
                Exit Sub
            End If

            Dim CartId As String = ""
            If Request.Cookies("IDMCart") Is Nothing Then
            Else 'If Cookie already exists
                Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                CartId = IDMCookie.Values("CartId")
            End If

            lblmsg.Text = obj.Insert(Session("UserIdfr"), lblGTotal.Text, "COD", ddlAddress.SelectedValue, CartId, txtName.Text.Trim.Replace("'", "`"), txtAddress.Text.Trim.Replace("'", "`"), txtLandmark.Text.Trim.Replace("'", "`"), txtZipcode.Text.Trim.Replace("'", "`"), txtCity.Text.Trim.Replace("'", "`"), txtState.Text.Trim.Replace("'", "`"), txtPhone.Text.Trim.Replace("'", "`"))
            If lblmsg.Text.StartsWith("OK") Then
                CType(Page.Master.FindControl("gvCart"), GridView).DataSource = Nothing
                CType(Page.Master.FindControl("gvCart"), GridView).DataBind()

                CType(Session("CartTable"), Data.DataTable).Rows.Clear()
                CType(Session("CartTable"), Data.DataTable).Columns.Clear()

                CType(Page.Master.FindControl("lblTotalQty"), Label).Text = 0
                CType(Page.Master.FindControl("lblTotalAmt"), Label).Text = 0

                MultiView1.ActiveViewIndex = 1
                lblOrderNo.Text = lblmsg.Text.Replace("OK", "")
            End If
        End If
    End Sub

End Class

#Region "CheckoutClass"

Public Class CheckoutClass
    Inherits ConnectionClass
    Public Function GetAddresses(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select AddressIdfr,PersonName +', '+Address+','+Landmark+','+Pincode+','+City+','+State+','+Phone as AddressName,PersonName,Address,Landmark,Pincode,City,State,Phone from IMART_ShippingAddress where UserIdfr=" & UserIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function GetAddressDetails(AddressIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select AddressIdfr,PersonName,Address,Landmark,Pincode,City,State,Phone from IMART_ShippingAddress where AddressIdfr=" & AddressIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function Insert(UserIdfr As Integer, PaidAmount As Decimal, PaymentMode As String, AddressIdfr As Integer, CartId As String, Optional Name As String = "-", Optional Address As String = "-", Optional Landmark As String = "-", Optional Pincode As String = "-", Optional City As String = "-", Optional State As String = "-", Optional Phone As String = "-") As String
        Dim daTempCart As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,Quantity from IMART_TempUserCart where UserIdfr=" & UserIdfr & "", Con)
        Dim dtTempCart As New Data.DataTable
        daTempCart.Fill(dtTempCart)

        Dim myTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim cmd As New Data.SqlClient.SqlCommand
        Try
            cmd.Connection = Con
            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            If AddressIdfr = 0 Then
                cmd.CommandText = "Insert into IMART_ShippingAddress(UserIdfr,PersonName,Address,Landmark,Pincode,City,State,Phone) values(" & UserIdfr & ",'" & Name & "','" & Address & "','" & Landmark & "','" & Pincode & "','" & City & "','" & State & "','" & Phone & "');select max(AddressIdfr) from IMART_ShippingAddress"
                AddressIdfr = CType(cmd.ExecuteScalar, Integer)
            End If

            cmd.CommandText = "Insert into IMART_CustomerOrders(UserIdfr,SaleDate,PaidAmount,PaymentMode,AddressIdfr) values (" & UserIdfr & ",'" & DateTime.Now.AddMinutes(800) & "'," & PaidAmount & ",'" & PaymentMode & "'," & AddressIdfr & ");select max(OrderIdfr) from IMART_CustomerOrders"
            Dim Idfr As Integer = CType(cmd.ExecuteScalar, Integer)

            For i As Integer = 0 To dtTempCart.Rows.Count - 1
                cmd.CommandText = "Insert into IMART_CustomerOrderGoods(OrderIdfr,ProductIdfr,ProductName,MRP,SalePrice,Quantity,AddressIdfr,ImagePath) Select " & Idfr & ",ProductIdfr,ProductName,MRP,SalePrice," & dtTempCart.Rows(i).Item("Quantity") & "," & AddressIdfr & ",ImagePath from IMART_Products where ProductIdfr=" & dtTempCart.Rows(i).Item("ProductIdfr") & ""
                cmd.ExecuteNonQuery()
            Next

            cmd.CommandText = "Delete from IMART_TempUserCart where UserIdfr=" & UserIdfr & ""
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Delete from IMART_TempGuestCart where CartId='" & CartId & "'"
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            Return "OK" & Idfr
        Catch ex As SqlException
            myTrans.Rollback()
            Return ex.Message
        Catch ex As Exception
            myTrans.Rollback()
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Update(ByVal CustomerIdfr As Integer, ByVal CustomerName As String, Address As String, ByVal Mobile1 As String, ByVal Mobile2 As String, Email As String) As String
        Try
            Con.Open()
            cmd.CommandText = "Update SMS_CustomerDetails set CustomerName='" & CustomerName & "',Email='" & Email & "',Mobile1='" & Mobile1 & "',Address='" & Address & "',Mobile2='" & Mobile2 & "' where CustomerIdfr = " & CustomerIdfr & ""
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region


