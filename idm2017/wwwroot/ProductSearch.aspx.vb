
Partial Class ProductSearch
    Inherits System.Web.UI.Page
    Dim obj As New ProductsSearchClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        If Not IsPostBack Then
            Try
                Dim ProductName As String = Request.QueryString("Cat")
                Dim Brand As String = Request.QueryString("mn")

                Dim dtProducts As New Data.DataTable
                If Not ProductName Is Nothing Then
                    hlnkGrid.NavigateUrl = "ProductSearchGG.aspx?Cat=" & ProductName
                    BindBreadCrumb(ProductName)
                    dtProducts = obj.GetProducts(ProductName, 0)
                    BindManufacturers(dtProducts)
                    BindGrid(dtProducts)
                End If
                If Not Brand Is Nothing Then
                    hlnkGrid.NavigateUrl = "ProductSearchGG.aspx?mn=" & Brand
                    dtProducts = obj.GetProducts(ProductName, Brand)
                    BindManufacturers(dtProducts)
                    BindGrid(dtProducts)
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub BindBreadCrumb(ProductName As String)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul>")
        str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
        str.Append("<li Class='category13'><strong>Search results: " & ProductName & "</strong></li>")
        str.Append("</ul>")
        divbread.InnerHtml = str.ToString
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

    Sub BindGrid(dtProducts As Data.DataTable)
        gvProducts.DataSource = dtProducts
        gvProducts.DataBind()
        For i As Integer = 0 To gvProducts.Rows.Count - 1
            CType(gvProducts.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dtProducts.Rows(i).Item("ProductIdfr").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dtProducts.Rows(i).Item("ProductIdfr").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblProductName"), Label).Text = dtProducts.Rows(i).Item("ProductName").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dtProducts.Rows(i).Item("MRP").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dtProducts.Rows(i).Item("SalePrice").ToString

            If dtProducts.Rows(i).Item("ShortDescription").ToString = "" Then
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).Attributes.Add("style", "color:white;")
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = "Sed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blanditSed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blandit"
            Else
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = dtProducts.Rows(i).Item("ShortDescription").ToString
            End If
            If i = 0 Then
                CType(gvProducts.Rows(i).Cells(0).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item first")
            ElseIf i = 1 Then
                CType(gvProducts.Rows(i).Cells(0).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item even")
            ElseIf (i Mod 2 = 0) Then
                CType(gvProducts.Rows(i).Cells(0).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item even")
            Else
                CType(gvProducts.Rows(i).Cells(0).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item odd")
            End If
            CType(gvProducts.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dtProducts.Rows(i).Item("ImagePath").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("hlnkImg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dtProducts.Rows(i).Item("ProductIdfr").ToString
        Next
    End Sub

    Sub clear()
        'txtCustomerName.Text = ""
        'txtMobile.Text = ""
        'txtAddress.Text = ""
        'txtEmail.Text = ""
        'txtMobile2.Text = ""
        'hdnCustomer.Value = ""
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs)
        Try
            Dim TotalPrice As Decimal = 0
            Dim TotalQty As Integer = 0

            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

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

            Dim btn As New Button
            btn = sender
            Dim tr As TableRow = btn.Parent.Parent.Parent

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1(0) = CType(tr.Cells(0).FindControl("hdnIdfr"), HiddenField).Value
            dr1(1) = CType(tr.Cells(0).FindControl("lblProductName"), Label).Text
            dr1(2) = CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text
            TotalPrice = TotalPrice + CDec(CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text)
            dr1(3) = CType(tr.Cells(0).FindControl("img1"), Image).ImageUrl
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
    End Sub

End Class

#Region "ProductsSearchClass"

Public Class ProductsSearchClass
    Inherits ConnectionClass

    Public Function GetProducts(ProductName As String, BrandIdfr As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        If BrandIdfr = 0 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where ProductName like '%" & ProductName & "%' and AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr", Con)
        Else
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where BrandIdfr=" & BrandIdfr & " and AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr", Con)
        End If
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region


