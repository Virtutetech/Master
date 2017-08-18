
Imports System.Data.SqlClient

Partial Class Cart
    Inherits System.Web.UI.Page
    Dim obj As New UserCartClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
        If Session("UserIdfr").ToString = "" Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                FillCart()

                Dim dt As New Data.DataTable
                dt = obj.GetAllCategories
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        End If

    End Sub
    Sub FillCart()
        Try
            Dim TotalPrice As Decimal = 0
            Dim dt As New Data.DataTable

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then
                Else 'If Cookie already exists
                    'Fetch the Cookie using its Key.
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                    dt.Rows.Clear()
                    dt.Columns.Clear()
                    dt = obj.GetGuestTempCart(IDMCookie.Values("CartId"))
                    TotalPrice = 0
                    gvSCart.Columns(0).Visible = True
                    gvSCart.DataSource = dt
                    gvSCart.DataBind()
                    gvSCart.Columns(0).Visible = False
                    For i As Integer = 0 To gvSCart.Rows.Count - 1
                        CType(gvSCart.Rows(i).Cells(1).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                        CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text = dt.Rows(i).Item("Quantity").ToString
                        TotalPrice = TotalPrice + (CDec(gvSCart.Rows(i).Cells(4).Text) * (Val(CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text)))
                    Next
                    lblSubTotal.Text = TotalPrice
                    lblGTotal.Text = TotalPrice
                End If
                '&&&&&&&&&&&&&&&&&&&&&&  If Existing User &&&&&&&&&&&&&&&&&&&&&&
            Else
                TotalPrice = 0
                dt.Rows.Clear()
                dt.Columns.Clear()

                dt = obj.GetUserTempCart(Session("UserIdfr"))

                gvSCart.Columns(0).Visible = True
                gvSCart.DataSource = dt
                gvSCart.DataBind()
                gvSCart.Columns(0).Visible = False
                For i As Integer = 0 To gvSCart.Rows.Count - 1
                    CType(gvSCart.Rows(i).Cells(1).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                    CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text = dt.Rows(i).Item("Quantity").ToString
                    TotalPrice = TotalPrice + (CDec(gvSCart.Rows(i).Cells(4).Text) * (Val(CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text)))
                Next
                lblSubTotal.Text = TotalPrice
                lblGTotal.Text = TotalPrice
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub UpdateCartItems()
        Try
            Dim TotalPrice As Decimal = 0
            Dim TotalQty As Integer = 0

            Dim dt As New Data.DataTable
            dt.Columns.Add("ProductIdfr", GetType(String))
            dt.Columns.Add("ProductName", GetType(String))
            dt.Columns.Add("MRP", GetType(String))
            dt.Columns.Add("SalePrice", GetType(String))
            dt.Columns.Add("Quantity", GetType(String))
            dt.Columns.Add("ImagePath", GetType(String))

            For i As Integer = 0 To gvSCart.Rows.Count - 1
                Dim dr1 As Data.DataRow = dt.NewRow
                dr1("ProductIdfr") = gvSCart.Rows(i).Cells(0).Text
                dr1("ProductName") = gvSCart.Rows(i).Cells(2).Text
                dr1("MRP") = gvSCart.Rows(i).Cells(3).Text
                dr1("SalePrice") = gvSCart.Rows(i).Cells(4).Text
                dr1("Quantity") = CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text
                dr1("ImagePath") = CType(gvSCart.Rows(i).Cells(1).FindControl("img1"), Image).ImageUrl
                TotalPrice = TotalPrice + (CDec(gvSCart.Rows(i).Cells(4).Text) * (Val(CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text)))
                dt.Rows.Add(dr1)
            Next

            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then
                Else 'If Cookie already exists
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                    Dim strresponse As String = ""
                    strresponse = obj.UpdateGuestTempCart(IDMCookie.Values("CartId"), dt)
                    If strresponse = "OK" Then
                        dt.Rows.Clear()
                        dt.Columns.Clear()
                        dt = obj.GetGuestTempCart(IDMCookie.Values("CartId"))

                        TotalPrice = 0

                        gvCart.DataSource = dt
                        gvCart.DataBind()

                        For i As Integer = 0 To gvCart.Rows.Count - 1
                            CType(gvCart.Rows(i).Cells(0).FindControl("hlnkImage"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                            CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                            CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString

                            CType(gvCart.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                            CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                            CType(gvCart.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                            CType(gvCart.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                            CType(gvCart.Rows(i).Cells(0).FindControl("lblQty"), Label).Text = dt.Rows(i).Item("Quantity").ToString
                            TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice").ToString) * Val(dt.Rows(i).Item("Quantity").ToString))
                        Next

                        CType(Me.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
                        CType(Me.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice
                    End If

                End If

                '&&&&&&&&&&&&&&&&&&&&&&  If Existing User &&&&&&&&&&&&&&&&&&&&&&
            Else
                Dim strresponse As String = ""
                strresponse = obj.UpdateUserTempCart(Session("UserIdfr"), dt)
                If strresponse = "OK" Then
                    TotalPrice = 0
                    dt.Rows.Clear()
                    dt.Columns.Clear()

                    dt = obj.GetUserTempCart(Session("UserIdfr"))

                    gvCart.DataSource = dt
                    gvCart.DataBind()

                    For i As Integer = 0 To gvCart.Rows.Count - 1
                        CType(gvCart.Rows(i).Cells(0).FindControl("hlnkImage"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                        CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString

                        CType(gvCart.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblQty"), Label).Text = dt.Rows(i).Item("Quantity").ToString
                        TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice").ToString) * Val(dt.Rows(i).Item("Quantity").ToString))
                    Next

                    CType(Me.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
                    CType(Me.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Try
            UpdateCartItems()
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnEmpty_Click(sender As Object, e As EventArgs)

        If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
            If Request.Cookies("IDMCart") Is Nothing Then
            Else 'If Cookie already exists
                'Fetch the Cookie using its Key.
                Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                lblmsg.Text = obj.DeleteGuestTempCart(IDMCookie.Values("CartId"))
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = "Success"
                Else
                    Exit Sub
                End If
            End If
        Else
            lblmsg.Text = obj.DeleteUserTempCart(Session("UserIdfr"))
            If lblmsg.Text = "OK" Then
                lblmsg.Text = "Success"
            Else
                Exit Sub
            End If
        End If

        gvSCart.DataSource = Nothing
        gvSCart.DataBind()

        lblSubTotal.Text = 0
        lblGTotal.Text = 0

        CType(Page.Master.FindControl("gvCart"), GridView).DataSource = Nothing
        CType(Page.Master.FindControl("gvCart"), GridView).DataBind()

        CType(Page.Master.FindControl("lblTotalQty"), Label).Text = 0
        CType(Page.Master.FindControl("lblTotalAmt"), Label).Text = 0

    End Sub

    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs)
        If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
            Server.Transfer("Login.aspx", False)
        Else
            If gvSCart.Rows.Count <= 0 Then
                lblmsg.Text = "Your Shopping Cart is Empty"
                Exit Sub
            End If
            Server.Transfer("Checkout.aspx", False)
        End If

    End Sub

    Protected Sub imgbtnRemove_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim btn As New ImageButton
            btn = sender
            Dim tr As TableRow = btn.Parent.Parent

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then
                Else 'If Cookie already exists
                    'Fetch the Cookie using its Key.
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                    lblmsg.Text = obj.DeleteGuestTempCartProduct(IDMCookie.Values("CartId"), tr.Cells(0).Text)
                    If lblmsg.Text = "OK" Then
                        lblmsg.Text = "Success"
                    Else
                        Exit Sub
                    End If
                End If
            Else
                lblmsg.Text = obj.DeleteUserTempCartProduct(Session("UserIdfr"), tr.Cells(0).Text)
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = "Success"
                Else
                    Exit Sub
                End If
            End If

            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

            Dim TotalPrice As Decimal = 0
            Dim dt As New Data.DataTable

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then
                Else 'If Cookie already exists
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")

                    dt.Rows.Clear()
                    dt.Columns.Clear()
                    dt = obj.GetGuestTempCart(IDMCookie.Values("CartId"))

                    TotalPrice = 0

                    gvCart.DataSource = dt
                    gvCart.DataBind()

                    For i As Integer = 0 To gvCart.Rows.Count - 1
                        CType(gvCart.Rows(i).Cells(0).FindControl("hlnkImage"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                        CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString

                        CType(gvCart.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                        CType(gvCart.Rows(i).Cells(0).FindControl("lblQty"), Label).Text = dt.Rows(i).Item("Quantity").ToString
                        TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice").ToString) * Val(dt.Rows(i).Item("Quantity").ToString))
                    Next

                    CType(Me.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
                    CType(Me.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice


                End If

                '&&&&&&&&&&&&&&&&&&&&&&  If Existing User &&&&&&&&&&&&&&&&&&&&&&
            Else

                TotalPrice = 0
                dt.Rows.Clear()
                dt.Columns.Clear()

                dt = obj.GetUserTempCart(Session("UserIdfr"))

                gvCart.DataSource = dt
                gvCart.DataBind()

                For i As Integer = 0 To gvCart.Rows.Count - 1
                    CType(gvCart.Rows(i).Cells(0).FindControl("hlnkImage"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                    CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString

                    CType(gvCart.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblQty"), Label).Text = dt.Rows(i).Item("Quantity").ToString
                    TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice").ToString) * Val(dt.Rows(i).Item("Quantity").ToString))
                Next

                CType(Me.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
                CType(Me.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice
            End If

            gvSCart.Columns(0).Visible = True
            gvSCart.DataSource = dt
            gvSCart.DataBind()
            gvSCart.Columns(0).Visible = False
            For i As Integer = 0 To gvSCart.Rows.Count - 1
                CType(gvSCart.Rows(i).Cells(1).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text = dt.Rows(i).Item("Quantity").ToString
                TotalPrice = TotalPrice + (CDec(gvSCart.Rows(i).Cells(4).Text) * (Val(CType(gvSCart.Rows(i).Cells(5).FindControl("txtQty"), TextBox).Text)))
            Next
            lblSubTotal.Text = TotalPrice
            lblGTotal.Text = TotalPrice
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try

    End Sub
    Protected Sub gvSCart_RowCreated(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            If e.Row.Cells.Count > 2 Then
                For i As Integer = 2 To gvSCart.Columns.Count - 1
                    e.Row.Cells.RemoveAt(2)
                Next
                e.Row.Cells.RemoveAt(0)
                e.Row.Cells(0).ColumnSpan = gvSCart.Columns.Count
            End If
        End If
    End Sub
End Class

#Region "UserCartClass"

Public Class UserCartClass
    Inherits ConnectionClass
    Public Function GetAllCategories() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3 from IMART_Category order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetLatestProducts() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 6 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetCategoryProducts(CategoryIdfr As Integer) As Data.DataTable
        ' Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where CategoryIdfr1=" & CategoryIdfr & " order by ProductIdfr desc", Con)
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function Insert(ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
        Try
            Con.Open()
            cmd.CommandText = "Insert into IMART_Category(CategoryName,ParentCategoryIdfr) values ('" & CategoryName & "'," & ParentCategoryIdfr & ")"
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As SqlException
            Return ex.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function Delete(ByVal MainCategoryIdfr As Integer) As Boolean
        cmd.CommandText = "Delete from IMART_MainCategory where MainCategoryIdfr=" & MainCategoryIdfr & ""
        Try
            Con.Open()
            ' cmd.ExecuteNonQuery()
            Return True
        Catch SQL As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Update(CategoryIdfr As Integer, ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Update IMART_Category set ParentCategoryIdfr=" & ParentCategoryIdfr & ",CategoryName='" & CategoryName & "' where CategoryIdfr =" & CategoryIdfr & ""
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            Return "OK"
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

End Class

#End Region

