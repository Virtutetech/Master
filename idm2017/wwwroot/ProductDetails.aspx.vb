
Partial Class ProductDetails
    Inherits System.Web.UI.Page
    Dim obj As New ProductDetailsClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Or String.IsNullOrEmpty(Session("UserIdfr").ToString) Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        'TabContainer1.Attributes.Add("style", "visibility:visible")
        If Not IsPostBack Then
            Try
                Dim Cat1 As String = "0"
                If Not Request.QueryString Is Nothing Then
                    Cat1 = Request.QueryString("p")
                    If IsNumeric(Cat1) = True Then
                        ' BindBreadCrumb(Cat1)
                        FillProductDetails(Cat1)
                    End If
                End If

            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub FillProductDetails(ProductIdfr As Integer)
        Try
            Dim dtProducts As New Data.DataTable
            dtProducts = obj.GetProductDetails(ProductIdfr)

            If dtProducts.Rows.Count > 0 Then
                hdnIdfr.Value = ProductIdfr
                lblProductName.Text = dtProducts.Rows(0).Item("ProductName").ToString
                lblDesc.Text = dtProducts.Rows(0).Item("ShortDescription").ToString
                lblSalePrice.Text = dtProducts.Rows(0).Item("SalePrice").ToString
                Try
                    lt1.Text = Server.HtmlDecode(System.IO.File.ReadAllText(Server.MapPath("Docs/") & dtProducts.Rows(0).Item("ProductIdfr").ToString & "/" & dtProducts.Rows(0).Item("ProductIdfr").ToString & ".txt"))
                    'CType(gv.Rows(0).Cells(0).FindControl("lblLongDesc"), Label).Text = Server.HtmlDecode(System.IO.File.ReadAllText(Server.MapPath("Docs/") & dtProducts.Rows(0).Item("ProductIdfr").ToString & "/" & dtProducts.Rows(0).Item("ProductIdfr").ToString & ".txt").ToString)
                    ' Label1.Text = System.IO.File.ReadAllText(Server.MapPath("Docs/") & dtProducts.Rows(0).Item("ProductIdfr").ToString & "/" & dtProducts.Rows(0).Item("ProductIdfr").ToString & ".txt").ToString
                Catch ex As Exception
                    ' Response.Write(ex.Message)
                End Try


                zoom1.NavigateUrl = dtProducts.Rows(0).Item("ImagePath").ToString
                zoom1.Attributes.Add("rel", "useWrapper: false, adjustY:0, adjustX:20")
                imgMain.ImageUrl = dtProducts.Rows(0).Item("ImagePath").ToString

                hlnk1.Attributes.Add("rel", "useZoom:'zoom1',smallImage:'" & dtProducts.Rows(0).Item("ImagePath").ToString & "'")
                img1.ImageUrl = dtProducts.Rows(0).Item("ImagePath").ToString


                If dtProducts.Rows(0).Item("IsVariant") = "YES" Then
                    Dim dtP As New Data.DataTable
                    dtP.Rows.Add(dtP.NewRow)
                    dtP.Rows.Add(dtP.NewRow)

                    gvAttributes.DataSource = dtP
                    gvAttributes.DataBind()
                End If

            Else
                Response.Write("Invalid Product")
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub BindBreadCrumb(CategoryIdfr As String)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul>")

        Dim dtCategoryDetails As New Data.DataTable
        dtCategoryDetails = obj.GetCategoryDetails(CategoryIdfr)

        Dim dr() As System.Data.DataRow = dtCategoryDetails.Select("CategoryIdfr=" & CategoryIdfr)
        If dr.Length > 0 Then
            ' lblCategory.Text = dr(0).Item("CategoryName")

            With dr(0)
                If .Item("CategoryIdfr1") = "0" And .Item("CategoryIdfr2") = "0" And .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                ElseIf .Item("CategoryIdfr2") = "0" And .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                ElseIf .Item("CategoryIdfr3") = "0" Then
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr2") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr2")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                Else
                    str.Append("<li Class='home'><a title='Go to Home Page' href='Default.aspx'>Home</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr1") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr1")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr2") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr2")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class=''><a href='ProductsList.aspx?Cat=" & .Item("CategoryIdfr3") & "'>" & dtCategoryDetails.Select("CategoryIdfr=" & .Item("CategoryIdfr3")).ElementAt(0).Item("CategoryName") & "</a><span>&mdash;&rsaquo;</span></li>")
                    str.Append("<li Class='category13'><strong>" & .Item("CategoryName") & "</strong></li>")
                End If
            End With
        End If

        str.Append("</ul>")
        'divbread.InnerHtml = str.ToString
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

        ' divManufacturer.InnerHtml = str.ToString
    End Sub

    Sub clear()
        'txtCustomerName.Text = ""
        'txtMobile.Text = ""
        'txtAddress.Text = ""
        'txtEmail.Text = ""
        'txtMobile2.Text = ""
        'hdnCustomer.Value = ""

    End Sub
    Protected Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        If txtqty.Text.Trim = "" Or txtqty.Text.Trim = "0" Then
            Exit Sub
        End If
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

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1("ProductIdfr") = hdnIdfr.Value
            dr1("ProductName") = lblProductName.Text
            dr1("MRP") = lblMRP.Text
            dr1("SalePrice") = lblSalePrice.Text
            dr1("Quantity") = txtqty.Text
            TotalPrice = TotalPrice + (CDec(lblSalePrice.Text) * Val(txtqty.Text))
            dr1("ImagePath") = img1.ImageUrl
            dt.Rows.Add(dr1)

            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then

                    Dim CartId As String = Guid.NewGuid.ToString() 'Generate a new CartId Unique

                    Dim strresponse As String = ""
                    strresponse = obj.InsertGuestTempCart(CartId, dt)

                    If strresponse = "OK" Then
                        Dim IDMCookie As New HttpCookie("IDMCart")
                        IDMCookie.Values("CartId") = CartId 'Set the Cookie value.
                        IDMCookie.Expires = DateTime.Now.AddDays(20) 'Set the Expiry date.
                        Response.Cookies.Add(IDMCookie) 'Add the Cookie to Browser.

                        gvCart.DataSource = dt
                        gvCart.DataBind()

                        TotalPrice = 0

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

                Else 'If Cookie already exists
                    'Fetch the Cookie using its Key.
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                    Dim strresponse As String = ""
                    strresponse = obj.InsertGuestTempCart(IDMCookie.Values("CartId"), dt)
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

            Else
                Dim strresponse As String = ""
                strresponse = obj.InsertUserTempCart(Session("UserIdfr"), dt)
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

    Protected Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        If txtqty.Text.Trim = "" Or txtqty.Text.Trim = "0" Then
            Response.Write("Quantity cannot be Zero")
            Exit Sub
        End If
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

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1("ProductIdfr") = hdnIdfr.Value
            dr1("ProductName") = lblProductName.Text
            dr1("MRP") = lblMRP.Text
            dr1("SalePrice") = lblSalePrice.Text
            dr1("Quantity") = txtqty.Text
            TotalPrice = TotalPrice + (CDec(lblSalePrice.Text) * Val(txtqty.Text))
            dr1("ImagePath") = img1.ImageUrl
            dt.Rows.Add(dr1)

            Dim gvCart As New GridView
            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

            If Session("UserIdfr") Is Nothing Or Session("UserIdfr").ToString = "" Then
                If Request.Cookies("IDMCart") Is Nothing Then

                    Dim CartId As String = Guid.NewGuid.ToString() 'Generate a new CartId Unique

                    Dim strresponse As String = ""
                    strresponse = obj.InsertGuestTempCart(CartId, dt)

                    If strresponse = "OK" Then
                        Dim IDMCookie As New HttpCookie("IDMCart")
                        IDMCookie.Values("CartId") = CartId 'Set the Cookie value.
                        IDMCookie.Expires = DateTime.Now.AddDays(20) 'Set the Expiry date.
                        Response.Cookies.Add(IDMCookie) 'Add the Cookie to Browser.

                        gvCart.DataSource = dt
                        gvCart.DataBind()

                        TotalPrice = 0

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

                Else 'If Cookie already exists
                    'Fetch the Cookie using its Key.
                    Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                    Dim strresponse As String = ""
                    strresponse = obj.InsertGuestTempCart(IDMCookie.Values("CartId"), dt)
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
                Response.Redirect("Cart.aspx")
            Else
                Dim strresponse As String = ""
                strresponse = obj.InsertUserTempCart(Session("UserIdfr"), dt)
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
                    Response.Redirect("Cart.aspx")
                Else
                    Response.Write(strresponse)
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub lnkbtnWish_Click(sender As Object, e As EventArgs) Handles lnkbtnWish.Click
        If Session("UserIdfr") Is Nothing Or String.IsNullOrEmpty(Session("UserIdfr")) Then
            Response.Redirect("Login.aspx")
        Else
            Dim str As String = obj.InsertWishlist(Session("UserIdfr"), hdnIdfr.Value)
            If str <> "OK" Then
                Response.Write(str)
            Else
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('Product added to Wishlist');", True)
            End If
        End If
    End Sub
End Class

#Region "ProductDetailsClass"

Public Class ProductDetailsClass
    Inherits ConnectionClass
    Public Function GetProducts(CategoryIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where (CategoryIdfr1=" & CategoryIdfr & " Or CategoryIdfr2=" & CategoryIdfr & " Or CategoryIdfr3=" & CategoryIdfr & " Or CategoryIdfr4=" & CategoryIdfr & ") and AStatus='ACTIVE' order by ProductIdfr", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetProductDetails(ProductIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath,isnull(IsVariant,'NO') IsVariant from IMART_Products where ProductIdfr=" & ProductIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region


