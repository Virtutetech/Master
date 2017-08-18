
Partial Class ProductsList
    Inherits System.Web.UI.Page
    Dim obj As New ProductsListClass
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        If Not IsPostBack Then
            Try
                Dim CatIdfr As String = Request.QueryString("Cat")
                Dim Brand As String = Request.QueryString("mn")

                If Not CatIdfr Is Nothing Then
                    If IsNumeric(CatIdfr) = True Then
                        BindBreadCrumb(CatIdfr)
                        hlnkGrid.NavigateUrl = "GridG.aspx?Cat=" & CatIdfr
                    Else
                        CatIdfr = "1"
                    End If
                Else
                    CatIdfr = "1"
                End If

                If Not Brand Is Nothing Then
                Else
                    Brand = "0"
                End If

                Dim dtProducts As New Data.DataTable
                dtProducts = obj.GetProducts(CatIdfr, Brand)
                BindManufacturers(dtProducts, Brand, CatIdfr)
                BindGrid(dtProducts, Brand)

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
            lblCategory.Text = dr(0).Item("CategoryName")

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
        divbread.InnerHtml = str.ToString
    End Sub

    Sub BindManufacturers(dtProducts As Data.DataTable, BrandIdfr As Integer, CatIdfr As Integer)
        Dim dtnew As New Data.DataTable
        dtnew = dtProducts.DefaultView.ToTable(True, "BrandIdfr", "BrandName")

        Dim str As New System.Text.StringBuilder
        str.Append("<ol>")
        For i As Integer = 0 To dtnew.Rows.Count - 1
            If dtnew.Rows(i).Item("BrandIdfr").ToString = BrandIdfr Then
                str.Append("<li style='color:#ED5666;'><b><a style='color:#ED5666;pointer-events:none;cursor:default;' href='#'>" & dtnew.Rows(i).Item("BrandName") & "</a></b>(" & dtProducts.Select("BrandIdfr=" & dtnew.Rows(i).Item("BrandIdfr")).Length & ")</li>")
            Else
                str.Append("<li><a href='ProductsList.aspx?Cat=" & CatIdfr & "&mn=" & dtnew.Rows(i).Item("BrandIdfr") & "'>" & dtnew.Rows(i).Item("BrandName") & "</a>(" & dtProducts.Select("BrandIdfr=" & dtnew.Rows(i).Item("BrandIdfr")).Length & ")</li>")
            End If
        Next
        str.Append("</ol>")

        divManufacturer.InnerHtml = str.ToString
    End Sub

    Sub BindGrid(dtProducts As Data.DataTable, BrandIdfr As Integer)
        Dim dr() As Data.DataRow
        If BrandIdfr = 0 Then
            dr = dtProducts.Select("1=1")
        Else
            dr = dtProducts.Select("BrandIdfr=" & BrandIdfr)
        End If


        gvProducts.DataSource = dr
        gvProducts.DataBind()
        For i As Integer = 0 To gvProducts.Rows.Count - 1
            CType(gvProducts.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dr(i).Item("ProductIdfr").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dr(i).Item("ProductIdfr").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblProductName"), Label).Text = dr(i).Item("ProductName").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dr(i).Item("MRP").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dr(i).Item("SalePrice").ToString


            If dtProducts.Rows(i).Item("ShortDescription").ToString = "" Then
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).Attributes.Add("style", "color:white;")
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = "Sed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blanditSed volutpat ac massa eget lacinia.  Aenean volutpat lacus at dolor blandit  Aenean volutpat lacus at dolor blandit"
            Else
                CType(gvProducts.Rows(i).Cells(0).FindControl("Pdesc"), HtmlGenericControl).InnerHtml = dr(i).Item("ShortDescription").ToString
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
            CType(gvProducts.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dr(i).Item("ImagePath").ToString
            CType(gvProducts.Rows(i).Cells(0).FindControl("hlnkImg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dr(i).Item("ProductIdfr").ToString
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

            Dim dt As New Data.DataTable
            dt.Columns.Add("ProductIdfr", GetType(String))
            dt.Columns.Add("ProductName", GetType(String))
            dt.Columns.Add("MRP", GetType(String))
            dt.Columns.Add("SalePrice", GetType(String))
            dt.Columns.Add("Quantity", GetType(String))
            dt.Columns.Add("ImagePath", GetType(String))

            Dim btn As New Button
            btn = sender
            Dim tr As TableRow = btn.Parent.Parent.Parent

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1("ProductIdfr") = CType(tr.Cells(0).FindControl("hdnIdfr"), HiddenField).Value
            dr1("ProductName") = CType(tr.Cells(0).FindControl("lblProductName"), Label).Text
            dr1("MRP") = CType(tr.Cells(0).FindControl("lblMRP"), Label).Text
            dr1("SalePrice") = CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text
            dr1("Quantity") = "1"
            dr1("ImagePath") = CType(tr.Cells(0).FindControl("img1"), Image).ImageUrl
            TotalPrice = TotalPrice + CDec(CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text)
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

    Protected Sub btnBuy_Click(sender As Object, e As EventArgs)
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

            Dim btn As New Button
            btn = sender
            Dim tr As TableRow = btn.Parent.Parent.Parent

            Dim dr1 As Data.DataRow = dt.NewRow
            dr1("ProductIdfr") = CType(tr.Cells(0).FindControl("hdnIdfr"), HiddenField).Value
            dr1("ProductName") = CType(tr.Cells(0).FindControl("lblProductName"), Label).Text
            dr1("MRP") = CType(tr.Cells(0).FindControl("lblMRP"), Label).Text
            dr1("SalePrice") = CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text
            dr1("Quantity") = "1"
            dr1("ImagePath") = CType(tr.Cells(0).FindControl("img1"), Image).ImageUrl
            TotalPrice = TotalPrice + CDec(CType(tr.Cells(0).FindControl("lblSalePrice"), Label).Text)
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
                    Response.Redirect("Login.aspx")
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

                    Response.Redirect("Cart.aspx")
                Else
                    Response.Write(strresponse)
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub lnkbtnWish_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As New LinkButton
            btn = sender
            Dim tr As TableRow = btn.Parent.Parent.Parent

            If Session("UserIdfr") Is Nothing Or String.IsNullOrEmpty(Session("UserIdfr")) Then
                Response.Redirect("Login.aspx")
            Else
                Dim str As String = obj.InsertWishlist(Session("UserIdfr"), CType(tr.Cells(0).FindControl("hdnIdfr"), HiddenField).Value)
                If str <> "OK" Then
                    Response.Write(str)
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('Product added to Wishlist');", True)
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class

#Region "ProductsListClass"

Public Class ProductsListClass
    Inherits ConnectionClass

    Public Function GetProducts(CategoryIdfr As Integer, BrandIdfr As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        ' If BrandIdfr = 0 Then
        da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where (CategoryIdfr1=" & CategoryIdfr & " Or CategoryIdfr2=" & CategoryIdfr & " Or CategoryIdfr3=" & CategoryIdfr & " Or CategoryIdfr4=" & CategoryIdfr & ") and AStatus='ACTIVE' order by ProductName", Con)
            '  Else
            '    da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductIdfr,ProductName,ShortDescription,BrandIdfr,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,MRP,SalePrice,ImagePath from IMART_Products where (CategoryIdfr1=" & CategoryIdfr & " Or CategoryIdfr2=" & CategoryIdfr & " Or CategoryIdfr3=" & CategoryIdfr & " Or CategoryIdfr4=" & CategoryIdfr & ") and BrandIdfr=" & BrandIdfr & " and AStatus='ACTIVE' order by ProductName", Con)
            ' End If

            Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region

