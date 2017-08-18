
Partial Class ProductSearchGG
    Inherits System.Web.UI.Page
    Dim obj As New ProductsSearchGridClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        If Not IsPostBack Then
            Try
                Dim ProductName As String = Request.QueryString("Cat")
                Dim Brand As String = Request.QueryString("mn")

                Dim dtProducts As New Data.DataTable
                If Not ProductName Is Nothing Then
                    hlnkList.NavigateUrl = "ProductSearch.aspx?Cat=" & ProductName
                    BindBreadCrumb(ProductName)
                    dtProducts = obj.GetProducts(ProductName, 0)
                    BindManufacturers(dtProducts)
                    BindGrid(dtProducts)
                End If
                If Not Brand Is Nothing Then
                    hlnkList.NavigateUrl = "ProductSearch.aspx?mn=" & Brand
                    dtProducts = obj.GetProducts(ProductName, Brand)
                    BindManufacturers(dtProducts)
                    BindGrid(dtProducts)
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub BindManufacturers(dtProducts As Data.DataTable)
        Dim dtnew As New Data.DataTable
        dtnew = dtProducts.DefaultView.ToTable(True, "BrandIdfr", "BrandName")

        Dim str As New System.Text.StringBuilder
        str.Append("<ol>")
        For i As Integer = 0 To dtnew.Rows.Count - 1
            str.Append("<li><a href='ProductSearch.aspx?mn=" & dtnew.Rows(i).Item("BrandIdfr").ToString & "'>" & dtnew.Rows(i).Item("BrandName") & "</a>(" & dtProducts.Select("BrandIdfr=" & dtnew.Rows(i).Item("BrandIdfr")).Length & ")</li>")
        Next
        str.Append("</ol>")

        divManufacturer.InnerHtml = str.ToString
    End Sub

    Sub BindBreadCrumb(ProductName As String)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul>")
        str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
        str.Append("<li Class='category13'><strong>Search results: " & ProductName & "</strong></li>")
        str.Append("</ul>")
        divbread.InnerHtml = str.ToString
    End Sub

    Sub BindGrid(dtProducts As Data.DataTable)
        dv.DataSource = dtProducts
        dv.DataBind()
        For i As Integer = 0 To dv.Items.Count - 1
            CType(dv.Items(i).FindControl("hdnIdfr"), HiddenField).Value = dtProducts.Rows(i).Item("ProductIdfr").ToString
            CType(dv.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dtProducts.Rows(i).Item("ProductIdfr").ToString
            CType(dv.Items(i).FindControl("lblProductName"), Label).Text = dtProducts.Rows(i).Item("ProductName").ToString
            CType(dv.Items(i).FindControl("lblMRP"), Label).Text = dtProducts.Rows(i).Item("MRP").ToString
            CType(dv.Items(i).FindControl("lblSalePrice"), Label).Text = dtProducts.Rows(i).Item("SalePrice").ToString

            CType(dv.Items(i).FindControl("imgF"), Image).ImageUrl = dtProducts.Rows(i).Item("ImagePath").ToString
            CType(dv.Items(i).FindControl("imgB"), Image).ImageUrl = dtProducts.Rows(i).Item("ImagePath").ToString
            CType(dv.Items(i).FindControl("hlnkImg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dtProducts.Rows(i).Item("ProductIdfr").ToString
        Next
    End Sub

    Protected Sub dv_ItemCommand(source As Object, e As DataListCommandEventArgs)
        If e.CommandName = "btnCart" Then
            Try
                Dim TotalPrice As Decimal = 0
                Dim TotalQty As Integer = 0
                Dim dt As New Data.DataTable
                dt.Columns.Add("Idfr", GetType(String))
                dt.Columns.Add("Name", GetType(String))
                dt.Columns.Add("SalePrice", GetType(String))
                dt.Columns.Add("ImageUrl", GetType(String))

                Dim gvCart As New GridView
                gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

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
                dr1(0) = CType(e.Item.FindControl("hdnIdfr"), HiddenField).Value
                dr1(1) = CType(e.Item.FindControl("lblProductName"), Label).Text
                dr1(2) = CType(e.Item.FindControl("lblSalePrice"), Label).Text
                TotalPrice = TotalPrice + CDec(CType(e.Item.FindControl("lblSalePrice"), Label).Text)
                dr1(3) = CType(e.Item.FindControl("imgF"), Image).ImageUrl
                dt.Rows.Add(dr1)

                gvCart.DataSource = dt
                gvCart.DataBind()

                For i As Integer = 0 To gvCart.Rows.Count - 1
                    CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImageUrl").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("Idfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("Name").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                Next

                CType(Me.Master.FindControl("lblTotalQty"), Label).Text = dt.Rows.Count
                CType(Me.Master.FindControl("lblTotalAmt"), Label).Text = TotalPrice

                Session("CartTable") = dt
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

        End If
    End Sub
End Class

#Region "ProductsSearchGridClass"

Public Class ProductsSearchGridClass
    Inherits ConnectionClass
    Public Function GetProducts(ProductName As String, BrandIdfr As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        If BrandIdfr = 0 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where (ProductName like '%" & ProductName & "%') and AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr", Con)
        Else
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where BrandIdfr=" & BrandIdfr & " and AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr", Con)
        End If
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function


End Class

#End Region



