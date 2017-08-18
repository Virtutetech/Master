Imports Microsoft.VisualBasic

Public Class URLRewriter
    Implements IHttpModule

    Public Sub Dispose() Implements IHttpModule.Dispose
        'Throw New NotImplementedException()
    End Sub

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf context_BeginRequest
        'Throw New NotImplementedException()
    End Sub

    Private Sub context_BeginRequest(sender As Object, e As EventArgs)
        'Create an instance of the application that has raised the event
        Dim HttpApplication As HttpApplication = sender
        'Safety check for the variable httpApplication if it Is Not null
        If Not HttpApplication Is Nothing Then
            'get the request path - request path Is    something you get in
            '             //the url
            Dim requestPath As String = HttpApplication.Context.Request.Path
            Dim translationpath As String = requestPath

            If requestPath.Contains("Products") Then
                Try
                    Dim strpath() As String
                    Dim Cat1 As String = "0"
                    Dim Cat2 As String = "0"
                    Dim Cat3 As String = "0"
                    Dim Cat4 As String = "0"
                    If requestPath.Contains("/") Then
                        strpath = requestPath.ToLower.Split("/")
                        Dim obj As New ConnectionClass
                        For i As Integer = 1 To strpath.Length - 1
                            If i = 1 Then
                                Cat1 = obj.GetCategoryIdfr(strpath(i))
                            ElseIf i = 2 Then
                                Cat2 = obj.GetCategoryIdfr(strpath(i))
                            ElseIf i = 3 Then
                                Cat3 = obj.GetCategoryIdfr(strpath(i))
                            ElseIf i = 4 Then
                                Cat4 = obj.GetCategoryIdfr(strpath(i))
                            End If
                        Next
                        translationpath = "/ProductsList.aspx?Cat1=" & Cat1 & "&Cat2=" & Cat2 & "&Cat3=" & Cat3 & "&Cat4=" & Cat4
                        HttpApplication.Context.Server.Transfer(translationpath)
                    End If
                Catch ex As Exception

                End Try
            End If

            '//if the request path Is /urlrewritetestingapp/laptops/dell/
            '//it means the site Is for DLL
            '//else if "/urlrewritetestingapp/laptops/hp/"
            '//it means the site Is for HP
            '//else it Is the default path


            '            Switch(requestPath.ToLower())
            '            {
            '                Case "/urlrewritetestingapp/laptops/dell/"
            '            translationPath = "/urlrewritetestingapp/showitem.aspx?itemid=7"
            '            break
            '            Case "/urlrewritetestingapp/laptops/hp/"
            '            translationPath = "/urlrewritetestingapp/showitem.aspx?itemid=8"
            '            break
            '            Default
            'translationPath = "/urlrewritetestingapp/default.aspx"
            '            break

        End If
    End Sub
End Class
