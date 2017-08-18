<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    'Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Code that runs on application startup
    '    RegisterRoutes(RouteTable.Routes)
    'End Sub
    'Private Shared Sub RegisterRoutes(routes As RouteCollection)
    '    routes.MapPageRoute("Products", "Products", "~/ProductsList.aspx")
    '    routes.MapPageRoute("ProductsCat1", "Products/{Cat1}", "~/ProductsList.aspx")
    '    routes.MapPageRoute("ProductsCat2", "Products/{Cat1}/{Cat2}", "~/ProductsList.aspx")
    '    routes.MapPageRoute("ProductsCat3", "Products/{Cat1}/{Cat2}/{Cat3}", "~/ProductsList.aspx")
    '    routes.MapPageRoute("ProductsCat4", "Products/{Cat1}/{Cat2}/{Cat3}/{Cat4}", "~/ProductsList.aspx")
    'End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Session("UserIdfr") = ""
        Session("UserLevel") = ""
        Session("CartTable") = ""
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        'Session("UserIdfr") = ""
        'Session("UserLevel") = ""
        'Session("CartTable") = ""
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub

</script>