
Imports System.Data.SqlClient

Partial Class UserHome
    Inherits System.Web.UI.Page
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
            Dim dt As New Data.DataTable
            Dim obj As New UserHomeClass
            Try
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
        Dim dt As New Data.DataTable
        Dim obj As New UserHomeClass
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
    End Sub

    Sub FillLatest()
        Dim dt As New Data.DataTable
        Dim obj As New UserHomeClass
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
                CType(rptCustomers.Items(i).FindControl("imgF"), Image).ImageUrl = "Docs/" & dt.Rows(i).Item("ProductIdfr").ToString & "/Gallery/" & System.IO.Path.GetFileName(System.IO.Directory.GetFiles(Server.MapPath("Docs/") & dt.Rows(i).Item("ProductIdfr") & "/Gallery")(0))
                CType(rptCustomers.Items(i).FindControl("imgB"), Image).ImageUrl = "Docs/" & dt.Rows(i).Item("ProductIdfr").ToString & "/Gallery/" & System.IO.Path.GetFileName(System.IO.Directory.GetFiles(Server.MapPath("Docs/") & dt.Rows(i).Item("ProductIdfr") & "/Gallery")(0))
            Catch ex As Exception

            End Try

        Next

    End Sub

    Sub FillCategory1(CategoryIdfr As Integer)
        Dim dt As New Data.DataTable
        Dim obj As New UserHomeClass
        dt = obj.GetCategoryProducts(CategoryIdfr)

        rptCat1.DataSource = dt
        rptCat1.DataBind()

        For i As Integer = 0 To rptCat1.Items.Count - 1

            CType(rptCat1.Items(i).FindControl("lblProductName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
            CType(rptCat1.Items(i).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
            CType(rptCat1.Items(i).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
            CType(rptCat1.Items(i).FindControl("hlnkimg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            CType(rptCat1.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            Try
                CType(rptCat1.Items(i).FindControl("imgF"), Image).ImageUrl = "Docs/" & dt.Rows(i).Item("ProductIdfr").ToString & "/Gallery/" & System.IO.Path.GetFileName(System.IO.Directory.GetFiles(Server.MapPath("Docs/") & dt.Rows(i).Item("ProductIdfr") & "/Gallery")(0))
                CType(rptCat1.Items(i).FindControl("imgB"), Image).ImageUrl = "Docs/" & dt.Rows(i).Item("ProductIdfr").ToString & "/Gallery/" & System.IO.Path.GetFileName(System.IO.Directory.GetFiles(Server.MapPath("Docs/") & dt.Rows(i).Item("ProductIdfr") & "/Gallery")(0))
            Catch ex As Exception

            End Try

        Next

    End Sub

    Sub FillCategory2(CategoryIdfr As Integer)
        Dim dt As New Data.DataTable
        Dim obj As New UserHomeClass
        dt = obj.GetCategoryProducts(CategoryIdfr)

        rptCat2.DataSource = dt
        rptCat2.DataBind()

        For i As Integer = 0 To rptCat2.Items.Count - 1

            CType(rptCat2.Items(i).FindControl("lblProductName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
            CType(rptCat2.Items(i).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
            CType(rptCat2.Items(i).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
            CType(rptCat2.Items(i).FindControl("hlnkimg"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            CType(rptCat2.Items(i).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
            Try
                CType(rptCat2.Items(i).FindControl("imgF"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
                CType(rptCat2.Items(i).FindControl("imgB"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
            Catch ex As Exception
                ' Response.Write(ex.Message)
            End Try
        Next
    End Sub

    Protected Sub rptCustomers_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
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

#Region "UserHomeClass"

Public Class UserHomeClass
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
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 6 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetCategoryProducts(CategoryIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice,ImagePath from IMART_Products where CategoryIdfr1=" & CategoryIdfr & " and AStatus='ACTIVE' order by ProductIdfr desc", Con)
        'Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    'Public Function Insert(ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
    '    Try
    '        Con.Open()
    '        cmd.CommandText = "Insert into IMART_Category(CategoryName,ParentCategoryIdfr) values ('" & CategoryName & "'," & ParentCategoryIdfr & ")"
    '        cmd.ExecuteNonQuery()

    '        Return "OK"
    '    Catch ex As SqlException
    '        Return ex.Message
    '    Catch ex As Exception
    '        Return ex.Message
    '    Finally
    '        Con.Close()
    '    End Try
    'End Function

    'Public Function Delete(ByVal MainCategoryIdfr As Integer) As Boolean
    '    cmd.CommandText = "Delete from IMART_MainCategory where MainCategoryIdfr=" & MainCategoryIdfr & ""
    '    Try
    '        Con.Open()
    '    ' cmd.ExecuteNonQuery()
    '    Return True
    '    Catch SQL As SqlException
    '    Return False
    '    Catch ex As Exception
    '    Return False
    '    Finally
    '    Con.Close()
    '    End Try
    'End Function
    'Public Function Update(CategoryIdfr As Integer, ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
    '    Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
    '    Try
    '        Dim cmd As New Data.SqlClient.SqlCommand
    '        cmd.Connection = Con

    '        Con.Open()
    '        myTrans = Con.BeginTransaction
    '        cmd.Transaction = myTrans

    '        cmd.CommandText = "Update IMART_Category set ParentCategoryIdfr=" & ParentCategoryIdfr & ",CategoryName='" & CategoryName & "' where CategoryIdfr =" & CategoryIdfr & ""
    '        cmd.ExecuteNonQuery()

    '        myTrans.Commit()
    '        Return "OK"
    '    Catch ex As SqlException
    '        myTrans.Rollback()
    '        Return ex.Message
    '    Catch ex As Exception
    '        myTrans.Rollback()
    '        Return ex.Message
    '    Finally
    '        Con.Close()
    '    End Try
    'End Function

End Class

#End Region
