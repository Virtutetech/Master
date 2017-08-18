
Partial Class DailyOrders
    Inherits System.Web.UI.Page
    Dim obj As New DailyOrdersClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        dt = obj.GetAllOrders
        gv.DataSource = dt
        gv.DataBind()
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No records"
        End If
    End Sub
End Class

#Region "DailyOrdersClass"

Public Class DailyOrdersClass
    Inherits ConnectionClass
    Public Function GetAllOrders() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select OrderIdfr as OrderNo,(Select ClientName from IMART_CustomerDetails where CustomerIdfr=IMART_CustomerOrders.UserIdfr) UserName,convert(varchar,SaleDate,103) SaleDate,PaidAmount from IMART_CustomerOrders order by SaleDate", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region

