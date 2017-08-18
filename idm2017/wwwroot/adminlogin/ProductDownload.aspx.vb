Imports ClosedXML.Excel
Partial Class ProductDownload
    Inherits System.Web.UI.Page
    ' Dim obj As New ExportToExcelClass
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
                ' BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try

        End If
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("IConn").ConnectionString
            Using con As New Data.SqlClient.SqlConnection(constr)
                Using cmd As New Data.SqlClient.SqlCommand("SELECT isnull((Select CategoryName from IMART_Category where CategoryIdfr=IMART_Products.CategoryIdfr1),'None') MainCategory,isnull((Select CategoryName from IMART_Category where CategoryIdfr=IMART_Products.CategoryIdfr2),'None') SubCategory1,isnull((Select CategoryName from IMART_Category where CategoryIdfr=IMART_Products.CategoryIdfr3),'None') SubCategory2,isnull((Select CategoryName from IMART_Category where CategoryIdfr=IMART_Products.CategoryIdfr4),'None') SubCategory3,[ProductName],[ShortDescription],isnull((Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr),'MISCELLENEOUS') Brand,[MRP],[SalePrice],isnull(ImagePath,'-') ImagePath,case when (Keywords is null or Keywords='') then ProductName else Keywords end Keywords,AStatus as Status FROM IMART_Products where isVariant='NO' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4")
                    Using sda As New Data.SqlClient.SqlDataAdapter()
                        cmd.Connection = con
                        sda.SelectCommand = cmd
                        Using dt As New Data.DataTable()
                            sda.Fill(dt)
                            Using wb As New XLWorkbook()
                                wb.Worksheets.Add(dt, "Products")

                                Response.Clear()
                                Response.Buffer = True
                                Response.Charset = ""
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx")
                                Using MyMemoryStream As New IO.MemoryStream()
                                    wb.SaveAs(MyMemoryStream)
                                    MyMemoryStream.WriteTo(Response.OutputStream)
                                    Response.Flush()
                                    Response.End()
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub
End Class

Public Class ExportToExcelClass
    Inherits ConnectionClass

End Class
