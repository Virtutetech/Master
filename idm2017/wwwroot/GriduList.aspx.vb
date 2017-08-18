
Imports System.Data.SqlClient

Partial Class GriduList
    Inherits System.Web.UI.Page
    Dim obj As New ProductsListGridUClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        If Not IsPostBack Then
            Try
                Dim Cat1 As String = "1"
                If Not Request.QueryString Is Nothing Then
                    Cat1 = Request.QueryString("Cat")
                    If IsNumeric(Cat1) = True Then
                        BindBreadCrumb(Cat1)
                        hlnkList.NavigateUrl = "ProductsListU.aspx?Cat=" & Cat1
                    End If
                End If
                '' If Me.Page.RouteData.Values.Count > 0 Then
                'Cat1 = Me.Page.RouteData.Values("Cat1")
                'Cat2 = Me.Page.RouteData.Values("Cat2")
                'Cat3 = Me.Page.RouteData.Values("Cat3")
                'Cat4 = Me.Page.RouteData.Values("Cat4")
                Dim dtProducts As New Data.DataTable
                dtProducts = obj.GetProducts(Cat1)
                BindManufacturers(dtProducts)
                BindGrid(dtProducts)
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub BindBreadCrumb(CategoryIdfr As String)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul>")

        Dim dtCategoryDetails As New Data.DataTable
        dtCategoryDetails = obj.GetCategoryDetails(CategoryIdfr)

        Dim dr() As System.Data.DataRow = dtCategoryDetails.Select("CategoryIdfr=" & CategoryIdfr)
        If dr.Length > 0 Then
            lblProductCategory.Text = dr(0).Item("CategoryName")

            With dr(0)
                If .Item("CategoryIdfr1") = "0" And .Item("CategoryIdfr2") = "0" And .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                ElseIf .Item("CategoryIdfr2") = "0" And .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                ElseIf .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr2") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr2")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                Else
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr2") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr2")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsListU.aspx?Cat=" & .Item("CategoryIdfr3") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr3")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                End If
            End With
        End If

        str.Append("</ul>")
        divbread.InnerHtml = str.ToString
    End Sub

    Sub BindManufacturers(dtProducts As Data.DataTable)
        Dim dtnew As New Data.DataTable
        dtnew = dtProducts.DefaultView.ToTable(True, "BrandIdfr", "BrandName")

        Dim str As New System.Text.StringBuilder
        str.Append("<ol>")
        For i As Integer = 0 To dtnew.Rows.Count - 1
            str.Append("<li><a href='#'>" & dtnew.Rows(i).Item("BrandName") & "</a>(" & dtProducts.Select("BrandIdfr=" & dtnew.Rows(i).Item("BrandIdfr")).Length & ")</li>")
        Next
        str.Append("</ol>")

        divManufacturer.InnerHtml = str.ToString
    End Sub

    Sub BindBreadCrumb(CatName1 As String, CatName2 As String, CatName3 As String, CatName4 As String)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul>")

        Dim CatIdfr1 As String = obj.GetCategoryIdfr(CatName1)
        Dim CatIdfr2 As String = obj.GetCategoryIdfr(CatName2)
        Dim CatIdfr3 As String = obj.GetCategoryIdfr(CatName3)
        Dim CatIdfr4 As String = obj.GetCategoryIdfr(CatName4)

        If CatName1 = "" And CatName2 = "" And CatName3 = "" And CatName4 = "" Then
            str.Append("<li Class='home'><a title='Go to Home Page' href='" & ResolveUrl("Default.aspx") & "'>Home</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class='category13'><strong>All Products</strong></li>")
        ElseIf CatName2 = "" And CatName3 = "" And CatName4 = "" Then
            str.Append("<li Class='home'><a title='Go to Home Page' href='" & ResolveUrl("Default.aspx") & "'>Home</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class='category13'><strong>" & CatName1 & "</strong></li>")
        ElseIf CatName3 = "" And CatName4 = "" Then
            str.Append("<li Class='home'><a title='Go to Home Page' href='" & ResolveUrl("Default.aspx") & "'>Home</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1) & "'>" & CatName1 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class='category13'><strong>" & CatName2 & "</strong></li>")
        ElseIf CatName4 = "" Then
            str.Append("<li Class='home'><a title='Go to Home Page' href='" & ResolveUrl("Default.aspx") & "'>Home</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1) & "'>" & CatName1 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1 & "/" & CatName2) & "'>" & CatName2 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class='category13'><strong>" & CatName3 & "</strong></li>")
        Else
            str.Append("<li Class='home'><a title='Go to Home Page' href='" & ResolveUrl("Default.aspx") & "'>Home</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1) & "'>" & CatName1 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1 & "/" & CatName2) & "'>" & CatName2 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class=''><a href='" & ResolveUrl("Products/" & CatName1 & "/" & CatName2 & "/" & CatName3) & "'>" & CatName3 & "</a><span>&mdash;&rsaquo;</span></li>")
            str.Append("<li Class='category13'><strong>" & CatName4 & "</strong></li>")
        End If
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

            'If dtProducts.Rows(i).Item("ShortDescription").ToString = "" Then
            '    CType(dv.Items(i).FindControl("Pdesc"), HtmlGenericControl).Attributes.Add("style", "color:white;")
            '    CType(dv.Items(i).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = "Sed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blanditSed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blandit"
            'Else
            '    CType(dv.Items(i).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = dtProducts.Rows(i).Item("ShortDescription").ToString
            'End If
            'If i = 0 Then
            '    CType(dv.Items(i).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item first")
            'ElseIf i = 1 Then
            '    CType(dv.Items(i).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item even")
            'ElseIf (i Mod 2 = 0) Then
            '    CType(dv.Items(i).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item even")
            'Else
            '    CType(dv.Items(i).FindControl("limy"), System.Web.UI.HtmlControls.HtmlGenericControl).Attributes.Add("class", "item odd")
            'End If
            CType(dv.Items(i).FindControl("imgF"), Image).ImageUrl = dtProducts.Rows(i).Item("ImagePath").ToString
            CType(dv.Items(i).FindControl("imgB"), Image).ImageUrl = dtProducts.Rows(i).Item("ImagePath").ToString
            CType(dv.Items(i).FindControl("hlnkImg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dtProducts.Rows(i).Item("ProductIdfr").ToString
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

#Region "ProductsListGridUClass"

Public Class ProductsListGridUClass
    Inherits ConnectionClass
    Public Function GetProducts(CategoryIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where (CategoryIdfr1=" & CategoryIdfr & " Or CategoryIdfr2=" & CategoryIdfr & " Or CategoryIdfr3=" & CategoryIdfr & " Or CategoryIdfr4=" & CategoryIdfr & ") and AStatus='ACTIVE' order by ProductIdfr", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region


