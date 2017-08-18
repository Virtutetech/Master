
Partial Class MyWishlist
    Inherits System.Web.UI.Page
    Dim obj As New WishlistClass
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
                lblmsg.Text = ex.Message
            End Try
        End If

    End Sub

    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetWishlist(Session("UserIdfr"))
        gvOrders.Columns(0).Visible = True
        gvOrders.DataSource = dt
        gvOrders.DataBind()
        gvOrders.Columns(0).Visible = False
        'For i As Integer = 0 To gvOrders.Rows.Count - 1
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lnkbtnOrderNo"), LinkButton).Text = dt.Rows(i).Item("OrderIdfr").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblDate"), Label).Text = dt.Rows(i).Item("SaleDate").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblShip"), Label).Text = dt.Rows(i).Item("PersonName").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblTotalAmount"), Label).Text = dt.Rows(i).Item("TotalAmount").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblStatus"), Label).Text = "Pending"



        'Next
        If dt.Rows.Count <= 0 Then
            'lblmsg.Text = "No Products found"
        End If
    End Sub

    Protected Sub gvOrders_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If

    End Sub

    'Protected Sub imgbtnRemove_Click(sender As Object, e As EventArgs)

    'End Sub

    Protected Sub imgbtnCart_Click(sender As Object, e As ImageClickEventArgs)
        Dim btn As New ImageButton
        btn = sender
        Dim tr As TableRow = btn.Parent.Parent

        Try
            Dim TotalPrice As Decimal = 0
            Dim TotalQty As Integer = 0

            Dim gvCart As New GridView
            gvCart = Page.Master.FindControl("gvCart")

            Dim dt As New Data.DataTable
            dt.Columns.Add("Idfr", GetType(String))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("SalePrice", GetType(String))
            dt.Columns.Add("ImageUrl", GetType(String))

            If TryCast(Session("CartTable"), Data.DataTable) Is Nothing Then
            Else
                For i As Integer = 0 To gvCart.Rows.Count - 1
                    Dim dr As Data.DataRow = dt.NewRow
                    dr("ImageUrl") = CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl
                    dr("Idfr") = CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value
                    dr("Name") = CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text
                    dr("SalePrice") = CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text
                    TotalPrice = TotalPrice + CDec(CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text)
                    dt.Rows.Add(dr)
                Next
            End If

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1(0) = tr.Cells(0).Text
            dr1(1) = tr.Cells(2).Text
            dr1(2) = tr.Cells(4).Text
            TotalPrice = TotalPrice + CDec(tr.Cells(4).Text)
            dr1(3) = CType(tr.Cells(1).Controls(0), Image).ImageUrl
            dt.Rows.Add(dr1)

            gvCart.DataSource = dt
            gvCart.DataBind()

            For i As Integer = 0 To gvCart.Rows.Count - 1
                CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImageUrl").ToString
                CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("Idfr").ToString
                CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("Name").ToString
                CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
            Next

            CType(Page.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
            CType(Page.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice

            Session("CartTable") = dt

            '  obj.Insert(Session("UserIdfr"), CType(tr.Cells(0).FindControl("hdnIdfr"), HiddenField).Value, 1)

            lblmsg.Text = "Product added to Cart"
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub
    Protected Sub imgbtnRemove_Click(sender As Object, e As ImageClickEventArgs)
        Dim btn As New ImageButton
        btn = sender
        Dim tr As TableRow = btn.Parent.Parent

        lblmsg.Text = obj.DeleteProduct(Session("UserIdfr"), tr.Cells(0).Text)
        If lblmsg.Text = "OK" Then
            lblmsg.Text = "Product removed"
            BindGrid()
        End If
    End Sub
End Class

#Region "WishlistClass"

Public Class WishlistClass
    Inherits ConnectionClass

    Public Function GetWishlist(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,ProductName,ImagePath,[MRP],[SalePrice] from IMART_Products where ProductIdfr in (Select ProductIdfr from IMART_Wishlist where UserIdfr=" & UserIdfr & ") order by ProductName", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function DeleteProduct(UserIdfr As Integer, ProductIdfr As Integer) As String
        Try
            Con.Open()

            cmd.CommandText = "Delete from IMART_Wishlist where UserIdfr=" & UserIdfr & " and ProductIdfr=" & ProductIdfr & ""
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region


