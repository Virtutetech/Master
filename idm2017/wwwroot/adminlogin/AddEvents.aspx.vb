
Imports System.Data.SqlClient

Partial Class AddEvents
    Inherits System.Web.UI.Page
    Dim obj As New AddEventsClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                txtDate.Text = obj.ConvertDate(DateTime.Now.AddMinutes(752))
                BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        End If
    End Sub


    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetEvents()
        gv.Columns(1).Visible = True
        gv.DataSource = dt
        gv.DataBind()
        For i As Integer = 0 To gv.Rows.Count - 1
            CType(gv.Rows(i).Cells(5).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString
        Next
        gv.Columns(1).Visible = False
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No records"
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If btnSubmit.Text = "Save" Then
                If fileupload1.HasFile = False Then
                    lblmsg.Text = "Please select a Image to upload"
                    Exit Sub
                End If
                lblmsg.Text = obj.Insert(txtEventTitle.Text.Trim.Replace("'", "`"), obj.ConvertDate(txtDate.Text.Trim), txtShortDesc.Text.Trim.Replace("'", "`"), fileupload1.PostedFile.FileName, ddlStatus.SelectedItem.Text)
                If lblmsg.Text.StartsWith("OK") = True Then

                    Dim EventIdfr As String = lblmsg.Text.Split(":")(1)
                    If System.IO.Directory.Exists(Server.MapPath("../Docs/Events")) = False Then
                        System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/Events"))
                    End If
                    If System.IO.Directory.Exists(Server.MapPath("../Docs/Events/") & EventIdfr) = False Then
                        System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/Events/") & EventIdfr)
                    End If
                    System.IO.File.WriteAllText(Server.MapPath("../Docs/Events/") & EventIdfr & "/" & EventIdfr & ".txt", txtDesc.Text)

                    Dim fs As System.IO.Stream = fileupload1.PostedFile.InputStream
                    Dim br As New System.IO.BinaryReader(fs)
                    Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                    IO.File.WriteAllBytes(Server.MapPath("../Docs/Events/") & EventIdfr & "/1.png", bytes)

                    lblmsg.Text = "Insertion success"
                    BindGrid()
                    txtEventTitle.Text = ""
                    txtDesc.Text = ""
                    txtShortDesc.Text = ""
                    txtDate.Text = ""
                End If

            ElseIf btnSubmit.Text = "Update" Then
                Try

                    Dim Imagepath As String = "-"
                    If fileupload1.HasFile Then
                        Imagepath = fileupload1.PostedFile.FileName
                    End If
                    lblmsg.Text = obj.Update(hdnId.Value, txtEventTitle.Text.Trim.Replace("'", "`"), obj.ConvertDate(txtDate.Text.Trim), txtShortDesc.Text.Trim.Replace("'", "`"), fileupload1.PostedFile.FileName, ddlStatus.SelectedItem.Text)
                    If lblmsg.Text = "OK" Then
                        Dim EventIdfr As String = hdnId.Value
                        If System.IO.Directory.Exists(Server.MapPath("../Docs/Events")) = False Then
                            System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/Events"))
                        End If
                        If System.IO.Directory.Exists(Server.MapPath("../Docs/Events/") & EventIdfr) = False Then
                            System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/Events/") & EventIdfr)
                        End If
                        If txtDesc.Text.Trim <> "" Then
                            System.IO.File.WriteAllText(Server.MapPath("../Docs/Events/") & EventIdfr & "/" & EventIdfr & ".txt", txtDesc.Text)
                        End If
                        If fileupload1.HasFile Then
                            Dim fs As System.IO.Stream = fileupload1.PostedFile.InputStream
                            Dim br As New System.IO.BinaryReader(fs)
                            Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                            IO.File.WriteAllBytes(Server.MapPath("../Docs/Events/") & EventIdfr & "/1.png", bytes)
                        End If


                        lblmsg.Text = "Updation success"
                        BindGrid()
                        txtEventTitle.Text = ""
                        txtDesc.Text = ""
                        txtShortDesc.Text = ""
                        txtDate.Text = ""
                        img.ImageUrl = ""

                    End If
                Catch ex As Exception
                    lblmsg.Text = ex.Message
                End Try

            End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkEdit_Click(sender As Object, e As EventArgs)
        Try
            btnSubmit.Text = "Update"
            Dim lnk As New LinkButton
            lnk = sender

            Dim tr As TableRow = lnk.Parent.Parent
            hdnId.Value = tr.Cells(1).Text
            txtEventTitle.Text = tr.Cells(2).Text
            txtDate.Text = tr.Cells(3).Text
            txtShortDesc.Text = tr.Cells(4).Text
            Try
                If System.IO.File.Exists(Server.MapPath("../Docs/Events/") & hdnId.Value & "/" & hdnId.Value & ".txt") Then
                    txtDesc.Text = System.IO.File.ReadAllText(Server.MapPath("../Docs/Events/") & hdnId.Value & "/" & hdnId.Value & ".txt")
                End If
            Catch ex As Exception

            End Try


            Try
                img.ImageUrl = CType(tr.Cells(5).FindControl("img1"), Image).ImageUrl
            Catch ex As Exception
            End Try
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try


    End Sub

End Class

#Region "AddEventsClass"

Public Class AddEventsClass
    Inherits ConnectionClass

    Public Function GetEvents() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select EventIdfr,EventTitle,ShortDesc,convert(varchar,EventDate,103) EventDate,ImagePath,AStatus from IMART_Events", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function Insert(EventTitle As String, EventDate As Date, ShortDesc As String, ImagePath As String, AStatus As String) As String
        Try
            Con.Open()

            cmd.CommandText = "Insert into IMART_Events(EventTitle,EventDate,ShortDesc,ImagePath,AStatus) values ('" & EventTitle & "','" & EventDate & "','" & ShortDesc & "','" & ImagePath & "','" & AStatus & "');select max(EventIdfr) from IMART_Events"
            Dim Idfr As Integer = CType(cmd.ExecuteScalar, Integer)

            Dim NewImagepath As String = "http://www.IndianDentalMart.com/Docs/Events/" & Idfr & "/1.png"
            cmd.CommandText = "Update IMART_Events set ImagePath='" & NewImagepath & "' where EventIdfr=" & Idfr & ""
            cmd.ExecuteNonQuery()

            Return "OK:" & Idfr
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
    Public Function Update(EventIdfr As Integer, EventTitle As String, EventDate As Date, ShortDesc As String, ImagePath As String, AStatus As String) As String
        Try
            Con.Open()
            Dim NewImagepath As String
            If ImagePath = "-" Then
                cmd.CommandText = "Update IMART_Events set EventTitle='" & EventTitle & "',EventDate='" & EventDate & "',ShortDesc='" & ShortDesc & "',AStatus='" & AStatus & "' where EventIdfr=" & EventIdfr & ""
            Else
                NewImagepath = "http://www.IndianDentalMart.com/Docs/Events/" & EventIdfr & "/1.png"
                cmd.CommandText = "Update IMART_Events set EventTitle='" & EventTitle & "',EventDate='" & EventDate & "',ShortDesc='" & ShortDesc & "',ImagePath='" & NewImagepath & "',AStatus='" & AStatus & "' where EventIdfr=" & EventIdfr & ""
            End If
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

End Class

#End Region
