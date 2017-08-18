﻿
Imports System.Data.SqlClient

Partial Class AddAttributes
    Inherits System.Web.UI.Page
    Dim obj As New AttributeMasterClass
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
                BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try

        End If
    End Sub
    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetAttributes
        gv.Columns(1).Visible = True
        gv.DataSource = dt
        gv.DataBind()
        gv.Columns(1).Visible = False
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No records"
        End If
    End Sub
    Sub clear()
        txtAttribute.Text = ""
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        If btnSubmit.Text = "Save" Then
            Try
                lblmsg.Text = obj.CheckExists(txtAttribute.Text.Trim.Replace("'", "`"))
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = obj.Insert(txtAttribute.Text.Trim.Replace("'", "`"))
                    If lblmsg.Text = "OK" Then
                        lblmsg.Text = "Attribute Added Successfully"
                        clear()
                        BindGrid()
                    End If
                Else
                    lblmsg.Text = "Attribute already exists"
                    ' ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblMsg.Text & "');", True)
                    Exit Sub
                End If
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        Else
            Try
                lblmsg.Text = obj.CheckExists(txtAttribute.Text.Trim.Replace("'", "`"), hdnIdfr.Value)
                If lblmsg.Text = "NO" Then
                    lblmsg.Text = "Attribute already exists"
                    'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "", "alert('" & lblMsg.Text & "');", True)
                    Exit Sub
                End If

                lblmsg.Text = obj.Update(hdnIdfr.Value, txtAttribute.Text.Trim.Replace("'", "`"))
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = "Attribute Updated Successfully"
                    clear()
                    btnSubmit.Text = "Save"
                    BindGrid()
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
        txtAttribute.Text = tr.Cells(2).Text

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

End Class

#Region "MainCategoryClass"

Public Class AttributeMasterClass
    Inherits ConnectionClass
    Public Function GetAttributes() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select AttributeIdfr,AttributeName from IMART_Attributes order by AttributeIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function CheckExists(ByVal AttributeName As String, Optional ByVal Idfr As Integer = 0) As String
        cmd.CommandText = "Select AttributeName from IMART_Attributes where AttributeName='" & AttributeName & "' And AttributeIdfr <> " & Idfr & ""
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

    Public Function Insert(ByVal AttributeName As String) As String
        Try
            Con.Open()

            cmd.CommandText = "Insert into IMART_Attributes(AttributeName) values ('" & AttributeName & "')"
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

    Public Function Delete(ByVal AttributeIdfr As Integer) As Boolean
        cmd.CommandText = "Delete from IMART_Attributes where MainCategoryIdfr=" & AttributeIdfr & ""
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
    Public Function Update(AttributeIdfr As Integer, ByVal AttributeName As String) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Update IMART_Attributes set AttributeName='" & AttributeName & "' where AttributeIdfr = " & AttributeIdfr & ""
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



