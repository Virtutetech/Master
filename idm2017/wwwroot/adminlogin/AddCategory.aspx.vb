Imports System.Data.SqlClient

Partial Class AddCategory
    Inherits System.Web.UI.Page
    Dim obj As New MainCategoryClass
    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'If Session("UserLevel") Is Nothing Then
        '    Response.Redirect("Default.aspx", True)
        'End If
        'If Session("UserLevel").ToString = "" Then
        '    Response.Redirect("Default.aspx", True)
        'End If
        'If Session("UserLevel") = "SUPERADMIN" Then
        '    Page.MasterPageFile = "MasterSuperAdmin.master"
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                FillParentCategories()
                BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try

        End If
    End Sub
    Sub FillParentCategories()
        Dim selected1 As Integer = 0
        Dim selected2 As Integer = 0
        Dim selected3 As Integer = 0
        If ddlCategory1.Items.Count > 0 Then
            selected1 = ddlCategory1.SelectedValue
        End If
        If ddlCategory2.Items.Count > 0 Then
            selected2 = ddlCategory2.SelectedValue
        End If
        If ddlCategory3.Items.Count > 0 Then
            selected3 = ddlCategory3.SelectedValue
        End If

        Dim dt As New Data.DataTable
        dt = obj.GetCategories(0, 0)
        ddlCategory1.DataSource = dt
        ddlCategory1.DataTextField = "CategoryName"
        ddlCategory1.DataValueField = "CategoryIdfr"
        ddlCategory1.DataBind()

        ddlCategory1.Items.Add(New ListItem("None", 0))
        ddlCategory1.SelectedIndex = ddlCategory1.Items.Count - 1

        For i As Integer = 0 To ddlCategory1.Items.Count - 1
            If ddlCategory1.Items(i).Value = selected1 Then
                ddlCategory1.SelectedIndex = i
                Exit For
            End If
        Next

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory1.SelectedValue, 1)
        ddlCategory2.DataSource = dt
        ddlCategory2.DataTextField = "CategoryName"
        ddlCategory2.DataValueField = "CategoryIdfr"
        ddlCategory2.DataBind()

        ddlCategory2.Items.Add(New ListItem("None", 0))
        ddlCategory2.SelectedIndex = ddlCategory2.Items.Count - 1

        For i As Integer = 0 To ddlCategory2.Items.Count - 1
            If ddlCategory2.Items(i).Value = selected2 Then
                ddlCategory2.SelectedIndex = i
                Exit For
            End If
        Next

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory2.SelectedValue, 2)
        ddlCategory3.DataSource = dt
        ddlCategory3.DataTextField = "CategoryName"
        ddlCategory3.DataValueField = "CategoryIdfr"
        ddlCategory3.DataBind()

        ddlCategory3.Items.Add(New ListItem("None", 0))
        ddlCategory3.SelectedIndex = ddlCategory3.Items.Count - 1
        For i As Integer = 0 To ddlCategory3.Items.Count - 1
            If ddlCategory3.Items(i).Value = selected3 Then
                ddlCategory3.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetAllCategoriesNew
        gv.Columns(1).Visible = True
        gv.Columns(3).Visible = True
        gv.Columns(5).Visible = True
        gv.Columns(7).Visible = True
        gv.DataSource = dt
        gv.DataBind()
        gv.Columns(1).Visible = False
        gv.Columns(3).Visible = False
        gv.Columns(5).Visible = False
        gv.Columns(7).Visible = False
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No records"
        End If
    End Sub
    Sub clear()
        txtCategory.Text = ""
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        If btnSubmit.Text = "Save" Then
            Try
                lblmsg.Text = obj.CheckExists(txtCategory.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue)
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = obj.Insert(txtCategory.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlStatus.SelectedItem.Text)
                    If lblmsg.Text = "OK" Then
                        lblmsg.Text = "Category Added Successfully"
                        clear()
                        BindGrid()
                        FillParentCategories()
                        ' ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblMsg.Text & "');", True)
                    End If
                Else
                    lblmsg.Text = "Category already exists"
                    ' ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblMsg.Text & "');", True)
                    Exit Sub
                End If
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        Else
            Try
                lblmsg.Text = obj.CheckExists(txtCategory.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, hdnIdfr.Value)
                If lblmsg.Text = "NO" Then
                    lblmsg.Text = "Category already exists"
                    Exit Sub
                End If

                lblmsg.Text = obj.Update(hdnIdfr.Value, txtCategory.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlStatus.SelectedItem.Text)
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = "Category Updated Successfully"
                    clear()
                    btnSubmit.Text = "Save"
                    BindGrid()
                    FillParentCategories()
                End If
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        End If
    End Sub
    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEdit As New LinkButton
        btnEdit = CType(sender, LinkButton)
        Dim tr As New TableRow
        tr = btnEdit.Parent.Parent

        hdnIdfr.Value = tr.Cells(1).Text
        txtCategory.Text = tr.Cells(2).Text
        For i As Integer = 0 To ddlCategory1.Items.Count - 1
            If ddlCategory1.Items(i).Value = tr.Cells(3).Text Then
                ddlCategory1.SelectedIndex = i
                Exit For
            End If
        Next
        FillSubCategory(1)
        For i As Integer = 0 To ddlCategory2.Items.Count - 1
            If ddlCategory2.Items(i).Value = tr.Cells(5).Text Then
                ddlCategory2.SelectedIndex = i
                Exit For
            End If
        Next
        FillSubCategory(2)
        For i As Integer = 0 To ddlCategory3.Items.Count - 1
            If ddlCategory3.Items(i).Value = tr.Cells(7).Text Then
                ddlCategory3.SelectedIndex = i
                Exit For
            End If
        Next
        btnSubmit.Text = "Update"
    End Sub

    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnSubmit.Text = "Update" Then
            lblmsg.Text = "Complete Update first..."
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblmsg.Text & "');", True)
        Else
            Dim btnDelete As New LinkButton
            btnDelete = CType(sender, LinkButton)
            Dim tr As New TableRow
            tr = btnDelete.Parent.Parent


            Dim Idfr As Integer = tr.Cells(1).Text

            'If obj.Delete(Idfr) = True Then
            '    lblMsg.Text = "Record Deleted Successfully"
            '    BindGrid()
            'Else
            '    lblMsg.Text = "Deletion failed"
            'End If
            'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblMsg.Text & "');", True)
        End If
    End Sub

    Protected Sub ddlCategory1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory1.SelectedIndexChanged
        FillSubCategory(1)
        'BindGrid()
    End Sub

    Protected Sub ddlCategory2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory2.SelectedIndexChanged
        FillSubCategory(2)
        ' BindGrid()
    End Sub

    Protected Sub ddlCategory3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory3.SelectedIndexChanged
        FillSubCategory(3)
        '  BindGrid()
    End Sub

    Sub FillSubCategory(ddl As Integer)
        Dim dt As New Data.DataTable
        If ddl = 1 Then
            dt = obj.GetCategories(ddlCategory1.SelectedValue, ddl)
            ddlCategory2.DataSource = dt
            ddlCategory2.DataTextField = "CategoryName"
            ddlCategory2.DataValueField = "CategoryIdfr"
            ddlCategory2.DataBind()

            ddlCategory2.Items.Add(New ListItem("None", 0))
            ddlCategory2.SelectedIndex = ddlCategory2.Items.Count - 1
        ElseIf ddl = 2 Then
            dt = obj.GetCategories(ddlCategory2.SelectedValue, ddl)
            ddlCategory3.DataSource = dt
            ddlCategory3.DataTextField = "CategoryName"
            ddlCategory3.DataValueField = "CategoryIdfr"
            ddlCategory3.DataBind()

            ddlCategory3.Items.Add(New ListItem("None", 0))
            ddlCategory3.SelectedIndex = ddlCategory3.Items.Count - 1

        End If
    End Sub

End Class

#Region "MainCategoryClass"
Public Class MainCategoryClass
    Inherits ConnectionClass
    Public Function GetCategories(CategoryIdfr As Integer, level As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        If level = 0 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1=0", Con)
        ElseIf level = 1 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr1)+'/'+CategoryName CategoryName from IMART_Category a where CategoryIdfr1=" & CategoryIdfr & " and CategoryIdfr1>0 and CategoryIdfr2=0", Con)
        Else
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1>0 and CategoryIdfr2>0 and CategoryIdfr2=" & CategoryIdfr & " and CategoryIdfr3=0", Con)
        End If
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    'Public Function GetParentCategories() As Data.DataTable
    '    Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,ParentCategoryIdfr from IMART_Category a order by CategoryIdfr desc", Con)
    '    Dim dt As New Data.DataTable
    '    da.Fill(dt)

    '    Dim dtNew As New Data.DataTable
    '    dtNew.Columns.Add("CategoryIdfr", GetType(Integer))
    '    dtNew.Columns.Add("CategoryName", GetType(String))

    '    Dim pcategoryname = ""
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        Dim pCategoryIdfr = dt.Rows(i).Item("ParentCategoryIdfr")
    '        pcategoryname = dt.Rows(i).Item("CategoryName")
    '        If pCategoryIdfr = 0 Then
    '            Dim dr As Data.DataRow = dtNew.NewRow
    '            dr(0) = dt.Rows(i).Item("CategoryIdfr")
    '            dr(1) = pcategoryname
    '            dtNew.Rows.Add(dr)
    '            Continue For
    '        End If
    '        Dim temp = 0
    '        While temp = 0
    '            Dim da2 As New Data.SqlClient.SqlDataAdapter("Select ParentCategoryIdfr,CategoryName from IMART_Category where CategoryIdfr=" & pCategoryIdfr & "", Con)
    '            Dim dt2 As New Data.DataTable
    '            da2.Fill(dt2)
    '            If dt2.Rows.Count > 0 Then
    '                pcategoryname = dt2.Rows(0).Item("CategoryName") & " --> " & pcategoryname
    '                pCategoryIdfr = dt2.Rows(0).Item("ParentCategoryIdfr")
    '                If dt2.Rows(0).Item("ParentCategoryIdfr") = 0 Then
    '                    temp = 1
    '                End If
    '            Else
    '                temp = 1
    '            End If
    '        End While
    '        Dim dr1 As Data.DataRow = dtNew.NewRow
    '        dr1(0) = dt.Rows(i).Item("CategoryIdfr")
    '        dr1(1) = pcategoryname
    '        dtNew.Rows.Add(dr1)
    '    Next

    '    Return dtNew
    'End Function

    Public Function GetAllCategories() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.ParentCategoryIdfr)+'/'+CategoryName ParentCategoryName,ParentCategoryIdfr,Status from IMART_Category a order by CategoryIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetAllCategoriesNew() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr1) MainCategory,CategoryIdfr1,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr2) SubCategory1,CategoryIdfr2,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr3) SubCategory2,CategoryIdfr3,AStatus from IMART_Category a order by CategoryIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function CheckExists(ByVal CategoryName As String, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, Optional ByVal Idfr As Integer = 0) As String
        cmd.CommandText = "Select CategoryName from IMART_Category where CategoryName='" & CategoryName & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " And CategoryIdfr <> " & Idfr & ""
        Try
            Con.Open()
            If cmd.ExecuteScalar Is Nothing Then
                Return "OK"
            Else
                Return "NO"
            End If
        Catch Sql As SqlException
            Return Sql.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function Insert(ByVal CategoryName As String, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, AStatus As String) As String
        Try
            Con.Open()

            cmd.CommandText = "Insert into IMART_Category(CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,AStatus) values ('" & CategoryName & "'," & CategoryIdfr1 & "," & CategoryIdfr2 & "," & CategoryIdfr3 & ",'" & AStatus & "')"
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
        Catch Sql As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Update(CategoryIdfr As Integer, ByVal CategoryName As String, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, AStatus As String) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Update IMART_Category set CategoryIdfr1=" & CategoryIdfr1 & ",CategoryIdfr2=" & CategoryIdfr2 & ",CategoryIdfr3=" & CategoryIdfr3 & ",CategoryName='" & CategoryName & "',AStatus='" & AStatus & "' where CategoryIdfr = " & CategoryIdfr & ""
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

