
Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Try
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
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                'Response.ClearHeaders()
                'Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate")
                'Response.AddHeader("Pragma", "no-cache")

                If Request.Browser.Cookies = False Then
                    Response.Write("Please Enable Cookies in your Browser")
                End If

                Dim dt As New Data.DataTable
                Dim obj As New DefaultPageClass
                dt = obj.GetAllCategories

                FillEvents()
                FillLatest()

                Dim cat1, cat2 As Integer
                Dim rnd As New Random()

                cat1 = dt.Select("CategoryIdfr1=0")(rnd.Next(0, dt.Select("CategoryIdfr1=0").Length - 2)).Item("CategoryIdfr")
                FillCategory1(cat1)
                lblCategory1.Text = dt.Select("CategoryIdfr=" & cat1)(0).Item("CategoryName").ToString

                cat2 = dt.Select("CategoryIdfr1=0")(rnd.Next(0, dt.Select("CategoryIdfr1=0").Length - 2)).Item("CategoryIdfr")

                If cat2 = cat1 Then
                    If cat2 = dt.Select("CategoryIdfr1=0").Length - 1 Then
                        cat2 = cat2 - 1
                    ElseIf cat2 = 0 Then
                        cat2 = 1
                    End If
                End If

                FillCategory2(cat2)
                lblCategory2.Text = dt.Select("CategoryIdfr=" & cat2)(0).Item("CategoryName").ToString

            Catch ex As Exception
                Response.Write("1 " & ex.Message)
            End Try
        End If
    End Sub

    Sub FillEvents()
        Try
            Dim dt As New Data.DataTable
            Dim obj As New DefaultPageClass
            dt = obj.GetEvents
            rptEvents.DataSource = dt
            rptEvents.DataBind()

            For i As Integer = 0 To rptEvents.Items.Count - 1
                CType(rptEvents.Items(i).FindControl("hlnkTitle"), HyperLink).Text = dt.Rows(i).Item("EventTitle").ToString
                CType(rptEvents.Items(i).FindControl("hlnkTitle"), HyperLink).NavigateUrl = "EventDetails.aspx?ev=" & dt.Rows(i).Item("EventIdfr").ToString

                CType(rptEvents.Items(i).FindControl("hlnkmore"), HyperLink).Text = "click here for details"
                CType(rptEvents.Items(i).FindControl("hlnkmore"), HyperLink).NavigateUrl = "EventDetails.aspx?ev=" & dt.Rows(i).Item("EventIdfr").ToString

                CType(rptEvents.Items(i).FindControl("lblDate"), Label).Text = CDate(dt.Rows(i).Item("EventDate").ToString).ToString("dd, MMM yyyy")
                CType(rptEvents.Items(i).FindControl("lblDesc"), Label).Text = dt.Rows(i).Item("ShortDesc").ToString
                Try
                    CType(rptEvents.Items(i).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            Response.Write("Events Error: " & ex.Message)
        End Try

    End Sub

    Sub FillLatest()
        Try
            Dim dt As New Data.DataTable
            Dim obj As New DefaultPageClass
            dt = obj.GetLatestProducts

            rptCustomers.DataSource = dt
            rptCustomers.DataBind()

            For i As Integer = 0 To rptCustomers.Items.Count - 1
                CType(rptCustomers.Items(i).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString
                CType(rptCustomers.Items(i).FindControl("lblProductName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                CType(rptCustomers.Items(i).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                CType(rptCustomers.Items(i).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                CType(rptCustomers.Items(i).FindControl("hlnkimg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                CType(rptCustomers.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                Try
                    CType(rptCustomers.Items(i).FindControl("imgF"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                    CType(rptCustomers.Items(i).FindControl("imgB"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                    CType(rptCustomers.Items(i).FindControl("imgB"), Image).Attributes.Add("width", "268")
                    CType(rptCustomers.Items(i).FindControl("imgB"), Image).Attributes.Add("height", "250")
                    CType(rptCustomers.Items(i).FindControl("imgF"), Image).Attributes.Add("width", "268")
                    CType(rptCustomers.Items(i).FindControl("imgF"), Image).Attributes.Add("height", "250")
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

            Next
        Catch ex As Exception
            Response.Write("Recent Error: " & ex.Message)
        End Try


    End Sub

    Sub FillCategory1(CategoryIdfr As Integer)
        Try
            Dim dt As New Data.DataTable
            Dim obj As New DefaultPageClass
            dt = obj.GetCategoryProducts(CategoryIdfr)

            rptCat1.DataSource = dt
            rptCat1.DataBind()

            For i As Integer = 0 To rptCat1.Items.Count - 1
                CType(rptCat1.Items(i).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString
                CType(rptCat1.Items(i).FindControl("lblProductName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                CType(rptCat1.Items(i).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                CType(rptCat1.Items(i).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                CType(rptCat1.Items(i).FindControl("hlnkimg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                CType(rptCat1.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                Try
                    CType(rptCat1.Items(i).FindControl("imgF"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                    CType(rptCat1.Items(i).FindControl("imgB"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                    CType(rptCat1.Items(i).FindControl("imgB"), Image).Attributes.Add("width", "268")
                    CType(rptCat1.Items(i).FindControl("imgB"), Image).Attributes.Add("height", "250")
                    CType(rptCat1.Items(i).FindControl("imgF"), Image).Attributes.Add("width", "268")
                    CType(rptCat1.Items(i).FindControl("imgF"), Image).Attributes.Add("height", "250")
                Catch ex As Exception

                End Try

            Next
        Catch ex As Exception
            Response.Write("Category1 Error: " & ex.Message)
        End Try


    End Sub

    Sub FillCategory2(CategoryIdfr As Integer)
        Dim dt As New Data.DataTable
        Dim obj As New DefaultPageClass
        dt = obj.GetCategoryProducts(CategoryIdfr)

        rptCat2.DataSource = dt
        rptCat2.DataBind()

        For i As Integer = 0 To rptCat2.Items.Count - 1
            CType(rptCat2.Items(i).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString
            CType(rptCat2.Items(i).FindControl("lblProductName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
            CType(rptCat2.Items(i).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
            CType(rptCat2.Items(i).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
            CType(rptCat2.Items(i).FindControl("hlnkimg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            CType(rptCat2.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            Try
                CType(rptCat2.Items(i).FindControl("imgF"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                CType(rptCat2.Items(i).FindControl("imgB"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                CType(rptCat2.Items(i).FindControl("imgB"), Image).Attributes.Add("width", "268")
                CType(rptCat2.Items(i).FindControl("imgB"), Image).Attributes.Add("height", "250")
                CType(rptCat2.Items(i).FindControl("imgF"), Image).Attributes.Add("width", "268")
                CType(rptCat2.Items(i).FindControl("imgF"), Image).Attributes.Add("height", "250")
            Catch ex As Exception
                ' Response.Write(ex.Message)
            End Try
        Next
    End Sub

    Protected Sub rptCustomers_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "btnCart" Then
            Try
                Dim obj As New DefaultPageClass
                Dim TotalPrice As Decimal = 0
                Dim dt As New Data.DataTable
                dt.Columns.Add("ProductIdfr", GetType(String))
                dt.Columns.Add("ProductName", GetType(String))
                dt.Columns.Add("MRP", GetType(String))
                dt.Columns.Add("SalePrice", GetType(String))
                dt.Columns.Add("Quantity", GetType(String))
                dt.Columns.Add("ImagePath", GetType(String))

                Dim dr11 As Data.DataRow = dt.NewRow
                dr11("ProductIdfr") = CType(e.Item.FindControl("hdnIdfr"), HiddenField).Value
                dr11("ProductName") = CType(e.Item.FindControl("lblProductName"), Label).Text
                dr11("MRP") = CType(e.Item.FindControl("lblMRP"), Label).Text
                dr11("SalePrice") = CType(e.Item.FindControl("lblSalePrice"), Label).Text
                dr11("Quantity") = "1"
                dr11("ImagePath") = CType(e.Item.FindControl("imgF"), Image).ImageUrl
                TotalPrice = TotalPrice + CDec(CType(e.Item.FindControl("lblSalePrice"), Label).Text)
                dt.Rows.Add(dr11)

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

                            Dim gvCart As New GridView
                            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
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

                            Dim gvCart As New GridView
                            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
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
                    strresponse = obj.InsertUserTempCart(Session("UserIdfr"), dt)
                    If strresponse = "OK" Then
                        TotalPrice = 0
                        dt.Rows.Clear()
                        dt.Columns.Clear()

                        dt = obj.GetUserTempCart(Session("UserIdfr"))

                        Dim gvCart As New GridView
                        gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
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
                Response.Write("Cookie error " & ex.Message)
            End Try

        ElseIf e.CommandName = "btnBuy" Then
            Try
                Dim obj As New DefaultPageClass
                Dim TotalPrice As Decimal = 0
                Dim dt As New Data.DataTable
                dt.Columns.Add("ProductIdfr", GetType(String))
                dt.Columns.Add("ProductName", GetType(String))
                dt.Columns.Add("MRP", GetType(String))
                dt.Columns.Add("SalePrice", GetType(String))
                dt.Columns.Add("Quantity", GetType(String))
                dt.Columns.Add("ImagePath", GetType(String))

                Dim dr11 As Data.DataRow = dt.NewRow
                dr11("ProductIdfr") = CType(e.Item.FindControl("hdnIdfr"), HiddenField).Value
                dr11("ProductName") = CType(e.Item.FindControl("lblProductName"), Label).Text
                dr11("MRP") = CType(e.Item.FindControl("lblMRP"), Label).Text
                dr11("SalePrice") = CType(e.Item.FindControl("lblSalePrice"), Label).Text
                dr11("Quantity") = "1"
                dr11("ImagePath") = CType(e.Item.FindControl("imgF"), Image).ImageUrl
                TotalPrice = TotalPrice + CDec(CType(e.Item.FindControl("lblSalePrice"), Label).Text)
                dt.Rows.Add(dr11)

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

                            Dim gvCart As New GridView
                            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)

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

                            Dim gvCart As New GridView
                            gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
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
                    Response.Redirect("Login.aspx", True)
                    '&&&&&&&&&&&&&&&&&&&&&&  If Existing User &&&&&&&&&&&&&&&&&&&&&&
                Else
                    Dim strresponse As String = ""
                    strresponse = obj.InsertUserTempCart(Session("UserIdfr"), dt)
                    If strresponse = "OK" Then
                        TotalPrice = 0
                        dt.Rows.Clear()
                        dt.Columns.Clear()

                        dt = obj.GetUserTempCart(Session("UserIdfr"))

                        Dim gvCart As New GridView
                        gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
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
                Response.Write("Buy error " & ex.Message)
            End Try
        ElseIf e.CommandName = "lnkbtnWish" Then
            If Session("UserIdfr") Is Nothing Or String.IsNullOrEmpty(Session("UserIdfr")) Then
                Response.Redirect("Login.aspx")
            Else
                Dim obj As New DefaultPageClass
                Dim str As String = obj.InsertWishlist(Session("UserIdfr"), CType(e.Item.FindControl("hdnIdfr"), HiddenField).Value)
                If str <> "OK" Then
                    Response.Write(str)
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('Product added to Wishlist');", True)
                End If
            End If
        End If
    End Sub

End Class

#Region "DefaultPageClass"

Public Class DefaultPageClass
    Inherits ConnectionClass

    Public Function GetEvents() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 3 EventIdfr,EventTitle,EventDate,ShortDesc,ImagePath from IMART_Events where AStatus='ACTIVE' order by EventDate Desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetAllCategories() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3 from IMART_Category where AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetLatestProducts() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 6 ProductIdfr,ProductName,MRP,SalePrice,ImagePath from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetCategoryProducts(CategoryIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice,ImagePath from IMART_Products where CategoryIdfr1=" & CategoryIdfr & " and AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function



End Class

#End Region


