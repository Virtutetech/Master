Imports JasService
Imports Newtonsoft.Json
Partial Class AddSubCategory
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                FillCategories()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try


        End If
    End Sub
    Sub FillCategories()
        Dim serviceclient As New JasService.DentalMart
        Dim Data = serviceclient.GetProductCategories()
        Dim json As String = Data
        Dim dt As New Data.DataTable
        dt = JsonConvert.DeserializeObject(Of Data.DataTable)(json)

        ddlCategory.DataSource = dt
        ddlCategory.DataTextField = "ProductCategory"
        ddlCategory.DataValueField = "ProductCategoryIdfr"
        ddlCategory.DataBind()

        ddlCategory.Items.Add(New ListItem("Select", 0))
        ddlCategory.SelectedIndex = ddlCategory.Items.Count - 1


        ddlParentCategory.Items.Add(New ListItem("Select", 0))
        ddlParentCategory.SelectedIndex = ddlCategory.Items.Count - 1
    End Sub
    Protected Sub ddlCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory.SelectedIndexChanged
        BindGrid()
        FillParentCategory()
    End Sub

    Sub BindGrid()
        Dim serviceclient As New JasService.DentalMart
        Dim Data = serviceclient.GetSubCategoriesNew(ddlCategory.SelectedValue)
        Dim json As String = Data
        Dim dt As New Data.DataTable
        dt = JsonConvert.DeserializeObject(Of Data.DataTable)(json)

        gv.Columns(1).Visible = True
        gv.Columns(3).Visible = True
        gv.DataSource = dt
        gv.DataBind()

        For i As Integer = 0 To gv.Rows.Count - 1
            If gv.Rows(i).Cells(1).Text = "0" Then
                gv.Rows(i).Visible = False
                Continue For
            End If
        Next

        gv.Columns(1).Visible = False
        gv.Columns(3).Visible = False
    End Sub

    Sub FillParentCategory()
        Dim serviceclient As New JasService.DentalMart
        Dim Data = serviceclient.GetSubCategoriesNew(ddlCategory.SelectedValue)
        Dim json As String = Data
        Dim dt As New Data.DataTable
        dt = JsonConvert.DeserializeObject(Of Data.DataTable)(json)

        ddlParentCategory.DataSource = dt
        ddlParentCategory.DataTextField = "ParentCategory"
        ddlParentCategory.DataValueField = "ParentCategoryIdfr"
        ddlParentCategory.DataBind()

        ddlParentCategory.Items.Add(New ListItem("Select", 0))
        ddlParentCategory.SelectedIndex = ddlParentCategory.Items.Count - 1
    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try

            Dim client As New JasService.DentalMart

            If btnSubmit.Text = "Save" Then
                lblmsg.Text = client.InsertSubCategoriesNew(ddlCategory.SelectedValue, txtSubCategory.Text.Trim.Replace("'", "`"), ddlParentCategory.SelectedValue)
                If lblmsg.Text = Chr(34) & "Y" & Chr(34) Then

                    lblmsg.Text = "Insertion success"
                    BindGrid()
                    txtSubCategory.Text = ""
                    ddlParentCategory.SelectedIndex = ddlParentCategory.Items.Count - 1

                End If
            ElseIf btnSubmit.Text = "Update" Then
                lblmsg.Text = client.UpdateSubCategoriesNew(hdnId.Value, txtSubCategory.Text.Trim.Replace("'", "`"), ddlParentCategory.SelectedValue)
                If lblmsg.Text = Chr(34) & "Y" & Chr(34) Then

                    lblmsg.Text = "Updation success"
                    BindGrid()
                    txtSubCategory.Text = ""
                    ddlParentCategory.SelectedIndex = ddlParentCategory.Items.Count - 1
                End If
            End If




        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkEdit_Click(sender As Object, e As EventArgs)
        btnSubmit.Text = "Update"
        Dim lnk As New LinkButton
        lnk = sender

        Dim tr As TableRow = lnk.Parent.Parent
        hdnId.Value = tr.Cells(1).Text
        txtSubCategory.Text = tr.Cells(2).Text
        For i As Integer = 0 To ddlParentCategory.Items.Count - 1
            If ddlParentCategory.Items(i).Value = tr.Cells(3).Text Then
                ddlParentCategory.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub

End Class
