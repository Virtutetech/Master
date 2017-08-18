
Partial Class Events
    Inherits System.Web.UI.Page
    Dim obj As New GetEventsClass
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
        If Not IsPostBack Then
            Try
                FillEvents
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub

    Sub FillEvents()
        Try
            Dim dtEvents As New Data.DataTable
            dtEvents = obj.GetEvents

            Dim str As New System.Text.StringBuilder
            For i As Integer = 0 To dtEvents.Rows.Count - 1
                str.Append("<article class='blog_entry clearfix wow bounceInLeft animated'>")
                str.Append("<header class='blog_entry-header clearfix'>")
                str.Append("<div class='blog_entry-header-inner'>")
                str.Append("<h2 class='blog_entry-title'><a rel='bookmark' href='EventDetails.aspx?ev=" & dtEvents.Rows(i).Item("EventIdfr").ToString & "'>" & dtEvents.Rows(i).Item("EventTitle").ToString & "</a> </h2>")
                str.Append("<p>" & dtEvents.Rows(i).Item("EventDate").ToString & "</p>")
                str.Append("</div>")

                '<!--blog_entry-header-inner--> 
                str.Append("</header>")
                str.Append("<div class='entry-content'>")
                str.Append("<div class='featured-thumb'><a href='EventDetails.aspx?ev=" & dtEvents.Rows(i).Item("EventIdfr").ToString & "'><img style='max-width:100%;height:auto;vertical-align:top;border:1px solid gray;' src='" & dtEvents.Rows(i).Item("ImagePath").ToString & "' alt='Event'></a></div>")
                str.Append("<div class='entry-content'>")
                str.Append("<p style='padding-top:25px!important;'>" & dtEvents.Rows(i).Item("ShortDesc").ToString & "</p>")
                str.Append("</div>")
                str.Append("<p> <a class='btn' href='EventDetails.aspx?ev=" & dtEvents.Rows(i).Item("EventIdfr").ToString & "'>Read More</a> </p>")
                str.Append("</div>")
                str.Append("</article>")
            Next


            divEve.InnerHtml = str.ToString
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub BindGallery(EventIdfr As Integer)

        ' divManufacturer.InnerHtml = str.ToString
    End Sub

End Class

#Region "GetEventsClass"

Public Class GetEventsClass
    Inherits ConnectionClass
    Public Function GetEvents() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select EventIdfr,EventTitle,ShortDesc,convert(varchar,EventDate,103) EventDate,ImagePath,AStatus from IMART_Events order by EventIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

End Class

#End Region


