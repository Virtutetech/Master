Imports System.Linq
Imports System.Data
Imports System.Data.SqlClient

Partial Class AddExProduct
    Inherits System.Web.UI.Page
    Dim obj As New AddExProductClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                FillParentCategories()
                BindAttributes()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        End If
    End Sub
    Sub FillParentCategories()
        Dim dt As New Data.DataTable
        dt = obj.GetCategories(0, 0)
        ddlCategory1.DataSource = dt
        ddlCategory1.DataTextField = "CategoryName"
        ddlCategory1.DataValueField = "CategoryIdfr"
        ddlCategory1.DataBind()

        ddlCategory1.Items.Add(New ListItem("None", 0))
        ddlCategory1.SelectedIndex = ddlCategory1.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory1.SelectedValue, 1)
        ddlCategory2.DataSource = dt
        ddlCategory2.DataTextField = "CategoryName"
        ddlCategory2.DataValueField = "CategoryIdfr"
        ddlCategory2.DataBind()

        ddlCategory2.Items.Add(New ListItem("None", 0))
        ddlCategory2.SelectedIndex = ddlCategory2.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory2.SelectedValue, 2)
        ddlCategory3.DataSource = dt
        ddlCategory3.DataTextField = "CategoryName"
        ddlCategory3.DataValueField = "CategoryIdfr"
        ddlCategory3.DataBind()

        ddlCategory3.Items.Add(New ListItem("None", 0))
        ddlCategory3.SelectedIndex = ddlCategory3.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory3.SelectedValue, 3)
        ddlCategory4.DataSource = dt
        ddlCategory4.DataTextField = "CategoryName"
        ddlCategory4.DataValueField = "CategoryIdfr"
        ddlCategory4.DataBind()

        ddlCategory4.Items.Add(New ListItem("None", 0))
        ddlCategory4.SelectedIndex = ddlCategory4.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetBrands
        ddlBrand.DataSource = dt
        ddlBrand.DataTextField = "BrandName"
        ddlBrand.DataValueField = "BrandIdfr"
        ddlBrand.DataBind()

        ddlBrand.Items.Add(New ListItem("Select", 0))
        ddlBrand.SelectedIndex = ddlBrand.Items.Count - 1
    End Sub
    Protected Sub ddlCategory1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory1.SelectedIndexChanged
        FillSubCategory(1)
    End Sub

    Protected Sub ddlCategory2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory2.SelectedIndexChanged
        FillSubCategory(2)
    End Sub

    Protected Sub ddlCategory3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory3.SelectedIndexChanged
        FillSubCategory(3)
    End Sub

    Sub BindAttributes()
        Dim dt As New Data.DataTable
        dt = obj.GetAttributes
        gvAttributes.Columns(0).Visible = True
        gvAttributes.DataSource = dt
        gvAttributes.DataBind()

        For i As Integer = 0 To gvAttributes.Rows.Count - 1
            Dim gv As New GridView
            gv = CType(gvAttributes.Rows(i).Cells(0).FindControl("gvIn"), GridView)

            Dim dt1 As New Data.DataTable
            dt1.Rows.Add(dt1.NewRow)
            dt1.Rows.Add(dt1.NewRow)

            gv.DataSource = dt1
            gv.DataBind()
        Next

        gvAttributes.Columns(0).Visible = False

    End Sub

    Sub BindGrid()

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
        Else
            dt = obj.GetCategories(ddlCategory3.SelectedValue, ddl)
            ddlCategory4.DataSource = dt
            ddlCategory4.DataTextField = "CategoryName"
            ddlCategory4.DataValueField = "CategoryIdfr"
            ddlCategory4.DataBind()

            ddlCategory4.Items.Add(New ListItem("None", 0))
            ddlCategory4.SelectedIndex = ddlCategory4.Items.Count - 1
        End If
    End Sub

    Protected Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Try


            lblmsg.Text = obj.CheckExists(txtProduct.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue)
            If lblmsg.Text = "OK" Then
                Dim dtAtt As New Data.DataTable
                dtAtt.Columns.Add("AttributeIdfr", GetType(Integer))
                dtAtt.Columns.Add("Value", GetType(String))
                dtAtt.Columns.Add("Desc", GetType(String))

                For i As Integer = 0 To gvAttributes.Rows.Count - 1
                    Dim gv As New GridView
                    gv = CType(gvAttributes.Rows(i).Cells(0).FindControl("gvIn"), GridView)

                    For j As Integer = 0 To gv.Rows.Count - 1
                        If CType(gv.Rows(j).Cells(0).FindControl("txtValue"), TextBox).Text.Trim <> "" And CType(gv.Rows(j).Cells(1).FindControl("txtDesc"), TextBox).Text.Trim <> "" Then
                            Dim dr As Data.DataRow = dtAtt.NewRow
                            dr(0) = gvAttributes.Rows(i).Cells(0).Text
                            dr(1) = CType(gv.Rows(j).Cells(0).FindControl("txtValue"), TextBox).Text.Trim.Replace("'", "`")
                            dr(2) = CType(gv.Rows(j).Cells(1).FindControl("txtDesc"), TextBox).Text.Trim.Replace("'", "`")
                            dtAtt.Rows.Add(dr)
                        End If
                    Next
                Next

                Dim dtFinal As New Data.DataTable
                dtFinal = obj.Insert(ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, txtProduct.Text.Trim.Replace("'", "`"), txtShortDesc.Text.Trim.Replace("'", "`"), ddlBrand.SelectedValue, dtAtt)
                If dtFinal.Rows.Count > 0 Then
                    'lblmsg.Text = "Success"
                    hdnId.Value = dtFinal.Rows(0).Item(0).ToString
                    lblmsg2.Text = lblmsg.Text
                    If dtFinal.Rows(0).Item(0).ToString.StartsWith("Error") = False Then

                        Dim dtprice As New Data.DataTable
                        dtprice = obj.InsertExProductValues(dtFinal.Rows(0).Item(0).ToString, dtFinal)

                        gvAttPrices.Columns(0).Visible = True
                        gvAttPrices.Columns(1).Visible = True
                        gvAttPrices.DataSource = dtprice
                        gvAttPrices.DataBind()
                        gvAttPrices.Columns(0).Visible = False
                        gvAttPrices.Columns(1).Visible = False
                        MultiView1.ActiveViewIndex = 1
                    End If
                End If


                'If lblmsg.Text.StartsWith("OK") = True Then

                '    Dim TransIdfr As String = lblmsg.Text.Split(":")(1)
                '    MultiView1.ActiveViewIndex = 1
                'End If
            End If

            'ElseIf btnSubmit.Text = "Update" Then
            '    lblmsg.Text = obj.CheckExists(txtProduct.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, hdnId.Value)
            '    If lblmsg.Text = "OK" Then
            '        Dim filename As String
            '        If fileupload1.HasFile Then
            '            filename = System.IO.Path.GetFileName(fileupload1.FileName)
            '        Else
            '            filename = "-"
            '        End If
            '        lblmsg.Text = obj.Update(hdnId.Value, ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, txtProduct.Text.Trim.Replace("'", "`"), txtShortDesc.Text.Trim.Replace("'", "`"), ddlBrand.SelectedValue, txtMRP.Text.Trim.Replace("'", "`"), txtSalePrice.Text.Trim.Replace("'", "`"), filename)
            '        If lblmsg.Text = "OK" Then
            '            If filename <> "-" Then
            '                Dim ProductIdfr As String = hdnId.Value
            '                If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr) = False Then
            '                    System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr)
            '                End If
            '                System.IO.File.WriteAllText(Server.MapPath("../Docs/") & ProductIdfr & "/" & ProductIdfr & ".txt", txtDesc.Text)

            '                If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery") = False Then
            '                    System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery")
            '                End If

            '                fileupload1.SaveAs(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery/" & filename)
            '            End If
            '            lblmsg.Text = "Updation success"
            '            BindGrid()
            '            txtProduct.Text = ""
            '            txtDesc.Text = ""
            '            txtShortDesc.Text = ""
            '            txtMRP.Text = ""
            '            txtSalePrice.Text = ""
            '            btnSubmit.Text = "Save"
            '        End If
            '    End If

            'End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim dtAtt As New Data.DataTable
            dtAtt.Columns.Add("Idfr", GetType(Integer))
            dtAtt.Columns.Add("TransIdfr", GetType(String))
            dtAtt.Columns.Add("MRP", GetType(Decimal))
            dtAtt.Columns.Add("SalePrice", GetType(Decimal))
            dtAtt.Columns.Add("ImagePath", GetType(String))
            'CType(tr.Cells(5).FindControl("lblupmsg"), Label).Text
            For i As Integer = 0 To gvAttPrices.Rows.Count - 1
                If CType(gvAttPrices.Rows(i).Cells(3).FindControl("txtMRP"), TextBox).Text.Trim <> "" And CType(gvAttPrices.Rows(i).Cells(4).FindControl("txtSalePrice"), TextBox).Text.Trim <> "" Then
                    Dim dr As Data.DataRow = dtAtt.NewRow
                    dr("Idfr") = gvAttPrices.Rows(i).Cells(0).Text
                    dr("TransIdfr") = gvAttPrices.Rows(i).Cells(1).Text
                    dr("MRP") = CType(gvAttPrices.Rows(i).Cells(3).FindControl("txtMRP"), TextBox).Text.Trim.Replace("'", "`")
                    dr("SalePrice") = CType(gvAttPrices.Rows(i).Cells(4).FindControl("txtSalePrice"), TextBox).Text.Trim.Replace("'", "`")
                    dr("ImagePath") = CType(gvAttPrices.Rows(i).Cells(5).FindControl("lblupmsg"), Label).Text
                    dtAtt.Rows.Add(dr)
                End If
            Next

            lblmsg2.Text = obj.Insert2(hdnId.Value, dtAtt)
            If lblmsg2.Text = "OK" Then
                lblmsg.Text = "Success"
                FillParentCategories()
                BindAttributes()
                MultiView1.ActiveViewIndex = 0
            End If
        Catch ex As Exception
            lblmsg2.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnMore_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As New Button
            btn = sender

            Dim tr As TableRow = btn.Parent.Parent
            Dim gv As New GridView
            gv = CType(tr.Cells(0).FindControl("gvIn"), GridView)

            Dim dt As New Data.DataTable
            dt.Columns.Add("Value", GetType(String))
            dt.Columns.Add("Desc", GetType(String))

            For i As Integer = 0 To gv.Rows.Count - 1
                If CType(gv.Rows(i).Cells(0).FindControl("txtValue"), TextBox).Text.Trim <> "" And CType(gv.Rows(i).Cells(1).FindControl("txtDesc"), TextBox).Text.Trim <> "" Then
                    Dim dr As Data.DataRow = dt.NewRow
                    dr(0) = CType(gv.Rows(i).Cells(0).FindControl("txtValue"), TextBox).Text.Trim
                    dr(1) = CType(gv.Rows(i).Cells(1).FindControl("txtDesc"), TextBox).Text.Trim
                    dt.Rows.Add(dr)
                End If
            Next
            dt.Rows.Add(dt.NewRow)
            gv.DataSource = dt
            gv.DataBind()

            For i As Integer = 0 To gv.Rows.Count - 1
                CType(gv.Rows(i).Cells(0).FindControl("txtValue"), TextBox).Text = dt.Rows(i).Item("Value").ToString
                CType(gv.Rows(i).Cells(1).FindControl("txtDesc"), TextBox).Text = dt.Rows(i).Item("Desc").ToString
            Next

        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnGo_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As New Button
            btn = sender

            Dim tr As TableRow = btn.Parent.Parent
            Dim fp As New FileUpload
            fp = CType(tr.Cells(5).FindControl("fp1"), FileUpload)

            If fp.HasFile Then
                If System.IO.Directory.Exists(Server.MapPath("../Docs/ExProducts")) = False Then
                    System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/ExProducts"))
                End If

                If System.IO.Directory.Exists(Server.MapPath("../Docs/ExProducts/") & hdnId.Value) = False Then
                    System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/ExProducts/") & hdnId.Value)
                End If

                If System.IO.Directory.Exists(Server.MapPath("../Docs/ExProducts/") & hdnId.Value & "/" & tr.Cells(0).Text) = False Then
                    System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/ExProducts/") & hdnId.Value & "/" & tr.Cells(0).Text)
                End If

                Dim fs As System.IO.Stream = fp.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))

                Dim filenamepath As String = ""
                filenamepath = DateTime.Now.AddMinutes(800).ToString.Replace("/", "").Replace(" ", "").Replace(":", "") & ".png"

                IO.File.WriteAllBytes(Server.MapPath("../Docs/ExProducts/") & hdnId.Value & "/" & tr.Cells(0).Text & "/" & filenamepath, bytes)

                CType(tr.Cells(5).FindControl("lblupmsg"), Label).Text = filenamepath
            End If
        Catch ex As Exception
            lblmsg2.Text = ex.Message
        End Try

    End Sub
End Class

#Region "AddExProductClass"

Public Class AddExProductClass
    Inherits ConnectionClass
    Public Function GetCategories(CategoryIdfr As Integer, level As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        If level = 0 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1=0", Con)
        ElseIf level = 1 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr1)+'/'+CategoryName CategoryName from IMART_Category a where CategoryIdfr1=" & CategoryIdfr & " and CategoryIdfr1>0 and CategoryIdfr2=0 and CategoryIdfr3=0", Con)
        ElseIf level = 2 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1>0 and CategoryIdfr2>0 and CategoryIdfr2=" & CategoryIdfr & " and CategoryIdfr3=0", Con)
        Else
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1>0 and CategoryIdfr2>0 and CategoryIdfr3>0 and CategoryIdfr3=" & CategoryIdfr & "", Con)
        End If
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetAttributes() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select AttributeIdfr,AttributeName from IMART_Attributes order by AttributeName", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function GetAllProducts(CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,ProductName,ShortDescription,BrandIdfr,MRP,SalePrice,ImagePath,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName from IMART_Products where CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " and CategoryIdfr4=" & CategoryIdfr4 & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetBrands() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select BrandIdfr,BrandName from IMART_Brands order by BrandName", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function CheckExists(ByVal ProductName As String, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, Optional ByVal Idfr As Integer = 0) As String
        cmd.CommandText = "Select ProductName from IMART_Products where ProductName='" & ProductName & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " and CategoryIdfr4=" & CategoryIdfr4 & " And ProductIdfr <> " & Idfr & ""
        Try
            Con.Open()
            If cmd.ExecuteScalar Is Nothing Then
                Return "OK"
            Else
                Return "Product already exists"
            End If
        Catch Sql As SqlException
            Return Sql.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function Insert(CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, ProductName As String, ShortDesc As String, BrandIdfr As Integer, dtAtt As Data.DataTable) As Data.DataTable
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing

        Dim dtNew As New Data.DataTable

        Dim dtFinal As New Data.DataTable
        dtFinal.Columns.Add("ProductIdfr", GetType(String))
        dtFinal.Columns.Add("TransIdfr", GetType(String))
        dtFinal.Columns.Add("TransName", GetType(String))

        Dim Idfr As Integer = 0
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Insert into IMART_Products(CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductName,ShortDescription,BrandIdfr,MRP,SalePrice,ImagePath,AStatus,IsVariant) values (" & CategoryIdfr1 & "," & CategoryIdfr2 & "," & CategoryIdfr3 & "," & CategoryIdfr4 & ",'" & ProductName & "','" & ShortDesc & "'," & BrandIdfr & ",0,0,'-','INACTIVE','YES');select max(ProductIdfr) from IMART_Products"
            Idfr = CType(cmd.ExecuteScalar, Integer)
            Dim TransIdfr As Integer = 0
            For i As Integer = 0 To dtAtt.Rows.Count - 1
                cmd.CommandText = "Select TransIdfr from IMART_ExProductAttributes where ProductIdfr=" & Idfr & " and AttributeIdfr=" & dtAtt.Rows(i).Item(0) & ""
                If cmd.ExecuteScalar Is Nothing Then
                    cmd.CommandText = "Insert into IMART_ExProductAttributes(ProductIdfr,AttributeIdfr) values (" & Idfr & "," & dtAtt.Rows(i).Item(0) & ");select max(TransIdfr) from IMART_ExProductAttributes"
                    TransIdfr = CType(cmd.ExecuteScalar, Integer)

                    cmd.CommandText = "Insert into IMART_ExProductAttributeValues(TransIdfr,Value,[Desc]) values (" & TransIdfr & ",'" & dtAtt.Rows(i).Item(1) & "','" & dtAtt.Rows(i).Item(2) & "')"
                    cmd.ExecuteNonQuery()

                Else
                    TransIdfr = CType(cmd.ExecuteScalar, Integer)
                    cmd.CommandText = "Insert into IMART_ExProductAttributeValues(TransIdfr,Value,[Desc]) values (" & TransIdfr & ",'" & dtAtt.Rows(i).Item(1) & "','" & dtAtt.Rows(i).Item(2) & "')"
                    cmd.ExecuteNonQuery()

                End If
            Next

            myTrans.Commit()
        Catch ex As Exception
            myTrans.Rollback()
            Dim dr As Data.DataRow = dtFinal.NewRow
            dr(0) = "Error " & ex.Message
            dtFinal.Rows.Add(dr)
            Return dtFinal
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try


        Dim daNew As New Data.SqlClient.SqlDataAdapter("Select Idfr,TransIdfr,Value,[Desc] from IMART_ExProductAttributeValues where TransIdfr in (Select TransIdfr from IMART_ExProductAttributes where ProductIdfr=" & Idfr & ") order by TransIdfr,Idfr", Con)
        daNew.Fill(dtNew)
        Dim dv As New DataView(dtNew)
        Dim dttempxxx As New Data.DataTable
        dttempxxx = dv.ToTable(True, "TransIdfr")
        Dim checkTrans As String = ""
        Dim count As Integer = dttempxxx.Rows.Count
        If count > 0 Then
            checkTrans = dttempxxx.Rows(0).Item("TransIdfr").ToString
        End If
        For i As Integer = 0 To dtNew.Rows.Count - 1
            If dtNew.Rows(i).Item("Transidfr") = checkTrans Then
                GetCartesianProduct(Idfr, dtFinal, dtNew, dtNew.Rows(i).Item("TransIdfr"), dtNew.Rows(i).Item("Value"), dtNew.Rows(i).Item("Idfr"))
            End If
        Next
        Return dtFinal
    End Function

    Public Function GetCartesianProduct(ProductIdfr As Integer, ByRef dtFinal As Data.DataTable, dtNew As Data.DataTable, TransIdfr As String, allTrans As String, allTransIdfr As String) As String

        Dim dttemp As New Data.DataTable
        If dtNew.Select("TransIdfr>" & TransIdfr & "").Length > 0 Then
            dttemp = dtNew.Select("TransIdfr>" & TransIdfr & "").CopyToDataTable
        Else
            Return "OK"
        End If
        Dim dv As New DataView(dttemp)
        Dim dttempxxx As New Data.DataTable
        dttempxxx = dv.ToTable(True, "TransIdfr")
        Dim count As Integer = dttempxxx.Rows.Count
        For i As Integer = 0 To dttemp.Rows.Count - 1
            If count <= 1 Then
                Dim dr As Data.DataRow = dtFinal.NewRow
                dr(0) = ProductIdfr
                dr(1) = allTransIdfr & "," & dttemp.Rows(i).Item("Idfr").ToString
                dr(2) = allTrans & "," & dttemp.Rows(i).Item("Value").ToString
                dtFinal.Rows.Add(dr)
            Else
                GetCartesianProduct(ProductIdfr, dtFinal, dttemp, dttemp.Rows(i).Item("TransIdfr").ToString, allTrans & "," & dttemp.Rows(i).Item("Value").ToString, allTransIdfr & "," & dttemp.Rows(i).Item("Idfr").ToString)
            End If
        Next

        Return "OK"

    End Function

    Public Function InsertExProductValues(ProductIdfr As Integer, dtFinal As Data.DataTable) As Data.DataTable
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Dim dt As New Data.DataTable
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            For i As Integer = 0 To dtFinal.Rows.Count - 1
                cmd.CommandText = "Insert into IMART_ExProductAttributeValuePrices(ProductIdfr,TransIdfr,TransName,MRP,SalePrice,ImagePath) values (" & ProductIdfr & ",'" & dtFinal.Rows(i).Item("TransIdfr").ToString & "','" & dtFinal.Rows(i).Item("TransName").ToString & "',0,0,'-')"
                cmd.ExecuteNonQuery()
            Next

            myTrans.Commit()

        Catch ex As Exception
            myTrans.Rollback()
            Return dt
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try


        Dim da As New Data.SqlClient.SqlDataAdapter("Select Idfr,TransIdfr,TransName,MRP,SalePrice,ImagePath from IMART_ExProductAttributeValuePrices where ProductIdfr=" & ProductIdfr & "", Con)
        da.Fill(dt)
        Return dt

    End Function

    Public Function Insert2(ProductIdfr As Integer, dtAtt As Data.DataTable) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            For i As Integer = 0 To dtAtt.Rows.Count - 1
                cmd.CommandText = "Update IMART_ExProductAttributeValuePrices set MRP=" & dtAtt.Rows(i).Item("MRP").ToString & ",SalePrice=" & dtAtt.Rows(i).Item("SalePrice").ToString & ",ImagePath='" & dtAtt.Rows(i).Item("ImagePath").ToString & "' where Idfr=" & dtAtt.Rows(i).Item("Idfr").ToString & " and ProductIdfr=" & ProductIdfr & ""
                cmd.ExecuteNonQuery()
            Next

            If dtAtt.Rows.Count > 0 Then
                cmd.CommandText = "Update IMART_Products set MRP=" & dtAtt.Rows(0).Item("MRP") & ",SalePrice=" & dtAtt.Rows(0).Item("SalePrice") & ",AStatus='ACTIVE',ImagePath='" & dtAtt.Rows(0).Item("ImagePath").ToString & "' where ProductIdfr=" & ProductIdfr & ""
                cmd.ExecuteNonQuery()
            End If

            Return "OK"
            myTrans.Commit()
        Catch ex As Exception
            myTrans.Rollback()
            Return ex.Message
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Function


    Sub testing2(Idfr As Integer, ByRef dtFinal As Data.DataTable)
        Dim dtNew As New Data.DataTable


        Dim daNew As New Data.SqlClient.SqlDataAdapter("Select Idfr,TransIdfr,Value,[Desc] from IMART_ExProductAttributeValues where TransIdfr In (Select TransIdfr from IMART_ExProductAttributes where ProductIdfr=" & Idfr & ") order by TransIdfr,Idfr", Con)
        daNew.Fill(dtNew)
        Dim dv As New DataView(dtNew)
        Dim dttempxxx As New Data.DataTable
        dttempxxx = dv.ToTable(True, "TransIdfr")
        Dim count As Integer = dttempxxx.Rows.Count

        For tc As Integer = 0 To dttempxxx.Rows.Count - 1
            If tc = dttempxxx.Rows.Count - 2 Then
            Else
                Continue For
            End If
            For i As Integer = 0 To dtNew.Rows.Count - 1
                Dim tempTrans As Integer = dtNew.Rows(i).Item("TransIdfr")
                Dim alltrans As String = dtNew.Rows(i).Item("Value")
                Dim alltransIdfr As String = dtNew.Rows(i).Item("Idfr")
                Dim tempcount As Integer = count



                For j As Integer = i To dtNew.Rows.Count - 1
                    If dtNew.Rows(j).Item("TransIdfr") = tempTrans Then
                        Continue For
                    ElseIf (tempcount - 2 > 0) Then
                        tempTrans = dtNew.Rows(j).Item("TransIdfr")
                    End If

                    tempcount = tempcount - 1
                    If tempcount <= 1 Then
                        Dim dr As Data.DataRow = dtFinal.NewRow
                        dr(0) = Idfr
                        dr("TransIdfr") = alltransIdfr & "," & dtNew.Rows(j).Item("Idfr")
                        dr("TransName") = alltrans & "," & dtNew.Rows(j).Item("Value")
                        dtFinal.Rows.Add(dr)

                        'alltrans = dtNew.Rows(i).Item("Idfr")
                    Else
                        If alltrans = "" Then
                            alltrans = dtNew.Rows(j).Item("Value")
                            alltransIdfr = dtNew.Rows(j).Item("Idfr")
                        Else
                            alltrans = alltrans & "," & dtNew.Rows(j).Item("Value")
                            alltransIdfr = alltransIdfr & "," & dtNew.Rows(j).Item("Idfr")
                        End If
                    End If
                Next
            Next

        Next

    End Sub

    Public Function Cartesian2(i As Integer, Idfr As Integer, dtNew As Data.DataTable, ByRef dtFinal As Data.DataTable, count As Integer) As String
        Dim tempTrans As Integer = dtNew.Rows(i).Item("TransIdfr")
        Dim alltrans As String = dtNew.Rows(i).Item("Value")
        Dim alltransIdfr As String = dtNew.Rows(i).Item("Idfr")
        Dim tempcount As Integer = count

        For j As Integer = i To dtNew.Rows.Count - 1
            If dtNew.Rows(j).Item("TransIdfr") = tempTrans Then
                Continue For
            ElseIf dtNew.Rows(j).Item("TransIdfr") <> tempTrans Then
                Cartesian2(j, Idfr, dtNew, dtFinal, tempcount)
            ElseIf (tempcount - 2 > 0) Then
                tempTrans = dtNew.Rows(j).Item("TransIdfr")
            End If

            tempcount = tempcount - 1
            If tempcount <= 1 Then
                Dim dr As Data.DataRow = dtFinal.NewRow
                dr(0) = Idfr
                dr("TransIdfr") = alltransIdfr & "," & dtNew.Rows(j).Item("Idfr")
                dr("TransName") = alltrans & "," & dtNew.Rows(j).Item("Value")
                dtFinal.Rows.Add(dr)

                'alltrans = dtNew.Rows(i).Item("Idfr")
            Else
                If alltrans = "" Then
                    alltrans = dtNew.Rows(j).Item("Value")
                    alltransIdfr = dtNew.Rows(j).Item("Idfr")
                Else
                    alltrans = alltrans & "," & dtNew.Rows(j).Item("Value")
                    alltransIdfr = alltransIdfr & "," & dtNew.Rows(j).Item("Idfr")
                End If
            End If
        Next
        Return "OK"
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
    Public Function Update(ProductIdfr As Integer, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, ProductName As String, ShortDesc As String, BrandIdfr As Integer, MRP As Decimal, SalePrice As Decimal, filename As String) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            Dim NewImagepath As String = ""
            If filename <> "-" Then
                NewImagepath = "http://www.IndianDentalMart.com/Docs/" & ProductIdfr & "/Gallery/" & filename
                cmd.CommandText = "Update IMART_Products set ImagePath='" & NewImagepath & "' where ProductIdfr=" & ProductIdfr & ""
                cmd.ExecuteNonQuery()
            End If

            cmd.CommandText = "Update IMART_Products set CategoryIdfr1=" & CategoryIdfr1 & ",CategoryIdfr2=" & CategoryIdfr2 & ",CategoryIdfr3=" & CategoryIdfr3 & ",ProductName='" & ProductName & "',ShortDescription='" & ShortDesc & "',BrandIdfr=" & BrandIdfr & ",MRP=" & MRP & ",SalePrice=" & SalePrice & " where ProductIdfr=" & ProductIdfr & ""
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
