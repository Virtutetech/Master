
Partial Class EventDetails
    Inherits System.Web.UI.Page
    Dim obj As New EventDetailsClass
    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("UserIdfr") Is Nothing Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
        If Session("UserIdfr").ToString = "" Then
            Page.MasterPageFile = "MasterGuest.master"
        Else
            Page.MasterPageFile = "MasterUser.master"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblMsg.Text = ""
        'TabContainer1.Attributes.Add("style", "visibility:visible")
        If Not IsPostBack Then
            Try
                Dim EventIdfr As Integer = 0
                If Not Request.QueryString("ev") Is Nothing Then
                    If IsNumeric(Request.QueryString("ev")) = True Then
                        FillEventDetails(Request.QueryString("ev"))
                    End If
                Else
                    Response.Redirect("Default.aspx")
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub FillEventDetails(EventIdfr As Integer)
        Try
            Dim dtEvents As New Data.DataTable
            dtEvents = obj.GetEventDetails(EventIdfr)

            If dtEvents.Rows.Count > 0 Then
                lblEvent.Text = dtEvents.Rows(0).Item("EventTitle").ToString 'breadcrumb

                'EventIdfr,EventTitle,ShortDesc,convert(varchar,EventDate,103) EventDate,ImagePath,AStatus
                lblTitle.Text = dtEvents.Rows(0).Item("EventTitle").ToString

                img1.ImageUrl = dtEvents.Rows(0).Item("ImagePath").ToString
                img1.Attributes.Add("style", "max-width:100%;vertical-align:top;height:auto;")
                lblEventDate.Text = "Event Date: " & dtEvents.Rows(0).Item("EventDate").ToString

                Try
                    divContent.InnerHtml = System.IO.File.ReadAllText(Server.MapPath("Docs/Events/") & dtEvents.Rows(0).Item("EventIdfr").ToString & "/" & dtEvents.Rows(0).Item("EventIdfr").ToString & ".txt")
                    'CType(gv.Rows(0).Cells(0).FindControl("lblLongDesc"), Label).Text = Server.HtmlDecode(System.IO.File.ReadAllText(Server.MapPath("Docs/") & dtProducts.Rows(0).Item("ProductIdfr").ToString & "/" & dtProducts.Rows(0).Item("ProductIdfr").ToString & ".txt").ToString)
                    ' Label1.Text = System.IO.File.ReadAllText(Server.MapPath("Docs/") & dtProducts.Rows(0).Item("ProductIdfr").ToString & "/" & dtProducts.Rows(0).Item("ProductIdfr").ToString & ".txt").ToString
                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub BindGallery(EventIdfr As Integer)

        ' divManufacturer.InnerHtml = str.ToString
    End Sub

End Class

#Region "EventDetailsClass"

Public Class EventDetailsClass
    Inherits ConnectionClass

    Public Function GetEventDetails(EventIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select EventIdfr,EventTitle,ShortDesc,convert(varchar,EventDate,103) EventDate,ImagePath,AStatus from IMART_Events where EventIdfr=" & EventIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region


