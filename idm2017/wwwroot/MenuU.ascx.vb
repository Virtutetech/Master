
Imports System.Data.SqlClient

Partial Class MenuU
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Try
                Dim dt As New Data.DataTable
                Dim obj As New MenuUClass
                dt = obj.GetAllCategories


                FillMobileMenu(dt)
                FillWebMenu(dt)
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub
    Public WriteOnly Property BindCart() As Data.DataTable
        Set(ByVal value As Data.DataTable)
            If value.Rows.Count > 0 Then
                Dim dt As New Data.DataTable
                dt.Columns.Add("Idfr", GetType(String))
                dt.Columns.Add("Name", GetType(String))
                dt.Columns.Add("SalePrice", GetType(String))
                dt.Columns.Add("ImageUrl", GetType(String))

                For i As Integer = 0 To gvCart.Rows.Count - 1
                    Dim dr As Data.DataRow = dt.NewRow
                    dr("ImageUrl") = CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl
                    dr("Idfr") = CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value
                    dr("Name") = CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text
                    dr("SalePrice") = CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text
                    dt.Rows.Add(dr)
                Next

                Dim dr1 As Data.DataRow = dt.NewRow
                dr1(0) = value.Rows(0).Item("Idfr").ToString
                dr1(1) = value.Rows(0).Item("Idfr").ToString
                dr1(2) = value.Rows(0).Item("Idfr").ToString
                dr1(3) = value.Rows(0).Item("Idfr").ToString
                dt.Rows.Add(dr1)

                gvCart.DataSource = dt
                gvCart.DataBind()
                For i As Integer = 0 To gvCart.Rows.Count - 1
                    CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImageUrl").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("Idfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("Name").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblPrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                Next
            End If

        End Set
    End Property
    Sub FillMobileMenu(dt As Data.DataTable)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul style = 'display:none;' class='submenu'>")
        str.Append("<li>")
        str.Append("<ul Class='topnav'>")


        Dim drCat1() As System.Data.DataRow = dt.Select("CategoryIdfr1=0 and CategoryIdfr2=0 and CategoryIdfr3=0")
        For Each dr1 As Data.DataRow In drCat1
            str.Append("<li Class='level0 nav-6 level-top first parent'><a class='level-top' href='grid.html'><span>" & dr1("CategoryName").ToString & "</span></a>")
            Dim drCat2() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=0 and CategoryIdfr3=0")
            If drCat2.Length > 0 Then
                str.Append("<ul Class='level0'>")
                For Each dr2 As Data.DataRow In drCat2
                    str.Append("<li Class='level1 nav-6-1 first'><a href='grid.html'><span>" & dr2("CategoryName") & "</span></a>")
                    Dim drCat3() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=0")
                    If drCat3.Length > 0 Then
                        str.Append("<ul Class='level1' style='display: none;'>")
                        For Each dr3 As Data.DataRow In drCat3
                            str.Append("<li Class='level2 nav-6-1-1 first'><a href='grid.html'><span>" & dr3("CategoryName") & "</span></a>")
                            Dim drCat4() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=" & dr3("CategoryIdfr"))
                            If drCat4.Length > 0 Then
                                str.Append("<ul Class='level1' style='display: none;'>")
                                For Each dr4 As Data.DataRow In drCat4
                                    str.Append("<li Class='level2 nav-6-1-1 first'><a href='grid.html'><span>" & dr4("CategoryName") & "</span></a></li>")
                                Next
                                str.Append("</ul>")
                            End If
                            str.Append("</li>")
                        Next
                        str.Append("</ul>")
                    End If
                    str.Append("</li>")
                Next
                str.Append("</ul>")
            End If
            str.Append("</li>")
        Next
        str.Append("</ul>")
        str.Append("</li>")
        str.Append("</ul>")
        divmobilemenu.InnerHtml = str.ToString
    End Sub

    Sub FillWebMenu(dt As Data.DataTable)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul id='nav' class='hidden-xs'>")
        'single menu
        str.Append("<li class='level0 nav-8 level-top'><a href='Default.aspx' class='level-top'><span>Home</span></a></li>")
        Dim drCat1() As System.Data.DataRow = dt.Select("CategoryIdfr1=0 and CategoryIdfr2=0 and CategoryIdfr3=0")
        For Each dr1 As Data.DataRow In drCat1
            str.Append("<li Class='level0 parent drop-menu'><a href='ProductsList.aspx?Cat=" & dr1("CategoryIdfr") & "'><span>" & dr1("CategoryName") & "</span></a>")
            'STart main category (disposables)
            Dim drCat2() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=0 and CategoryIdfr3=0")
            If drCat2.Length > 0 Then
                str.Append("<ul Class='level1'>")
                For Each dr2 As Data.DataRow In drCat2
                    str.Append("<li Class='level1 first parent'><a href='ProductsList.aspx?Cat=" & dr2("CategoryIdfr") & "'><span>" & dr2("CategoryName") & "</span></a>")
                    Dim drCat3() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=0")
                    If drCat3.Length > 0 Then
                        str.Append("<ul Class='level1'>")
                        For Each dr3 As Data.DataRow In drCat3
                            str.Append("<li Class='level1 first'><a href='ProductsList.aspx?Cat=" & dr3("CategoryIdfr") & "'><span>" & dr3("CategoryName") & "</span></a>")
                            Dim drCat4() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=" & dr3("CategoryIdfr"))
                            If drCat4.Length > 0 Then
                                str.Append("<ul Class='level2 right-sub'>")
                                For Each dr4 As Data.DataRow In drCat4
                                    str.Append("<li Class='level2 nav-2-1-1 first'><a href='ProductsList.aspx?Cat=" & dr4("CategoryIdfr") & "'><span>" & dr4("CategoryName") & "</span></a></li>")
                                Next
                                str.Append("</ul>")
                            End If
                            str.Append("</li>")
                        Next
                        str.Append("</ul>")
                    End If


                    str.Append("</li>")
                Next
                str.Append("</ul>")
            End If
            str.Append("</li>") 'end main category (disposables)
        Next
        divmainmenu.InnerHtml = str.ToString
    End Sub

End Class

#Region "MenuUClass"

Public Class MenuUClass
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
