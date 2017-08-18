
Imports System.Data.SqlClient

Partial Class Dashboard
    Inherits System.Web.UI.Page
    Dim obj As New DashboardClass
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
            Try
                lblName.Text = obj.GetUsername(Session("UserIdfr"))
                BindGrid()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If

    End Sub

    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetAllOrders(Session("UserIdfr"))
        gvOrders.DataSource = dt
        gvOrders.DataBind()
        'For i As Integer = 0 To gvOrders.Rows.Count - 1
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lnkbtnOrderNo"), LinkButton).Text = dt.Rows(i).Item("OrderIdfr").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblDate"), Label).Text = dt.Rows(i).Item("SaleDate").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblShip"), Label).Text = dt.Rows(i).Item("PersonName").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblTotalAmount"), Label).Text = dt.Rows(i).Item("TotalAmount").ToString
        '    CType(gvOrders.Rows(i).Cells(0).FindControl("lblStatus"), Label).Text = "Pending"



        'Next
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No Orders found"
        End If
    End Sub

    Protected Sub gvOrders_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.TableSection = TableRowSection.TableHeader
        End If

    End Sub
    Protected Sub gvOrders_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Protected Sub lnkbtnView_Click(sender As Object, e As EventArgs)
        Dim btn As New LinkButton
        btn = sender
        Dim tr As TableRow = btn.Parent.Parent

        gvIn.DataSource = obj.GetAllOrderGoodss(tr.Cells(0).Text)
        gvIn.DataBind()
        popup.Show()
    End Sub
End Class

#Region "DashboardClass"

Public Class DashboardClass
    Inherits ConnectionClass
    Public Function GetAllOrders(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select OrderIdfr as OrderNo,convert(varchar,SaleDate,103) SaleDate,(Select PersonName from IMART_ShippingAddress where AddressIdfr=IMART_CustomerOrders.AddressIdfr) PersonName,(Select sum(SalePrice*Quantity) from IMART_CustomerOrderGoods where OrderIdfr=IMART_CustomerOrders.OrderIdfr) TotalAmount,'Pending' as Status from IMART_CustomerOrders where UserIdfr=" & UserIdfr & " order by SaleDate desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetAllOrderGoodss(OrderIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductName,ImagePath,[MRP],[SalePrice],[Quantity] from [IMART_CustomerOrderGoods] where OrderIdfr=" & OrderIdfr & " order by Idfr", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetUsername(UserIdfr As Integer) As String
        Try
            Con.Open()

            cmd.CommandText = "Select ClientName from IMART_CustomerDetails where CustomerIdfr=" & UserIdfr & ""
            Return CType(cmd.ExecuteScalar, String)
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

