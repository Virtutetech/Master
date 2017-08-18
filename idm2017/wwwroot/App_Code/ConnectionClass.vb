﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO

Public Class ConnectionClass
    Protected Con As System.Data.SqlClient.SqlConnection
    Protected cmd As New SqlCommand
    Public Sub New()

        Dim Connection As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("IConn").ConnectionString
        Con = New System.Data.SqlClient.SqlConnection(Connection)
        cmd.Connection = Con
    End Sub

    Public Function ConvertDate(ByVal tempdate As String) As String
        Try
            If tempdate = "" Then
                Return "01/01/2000"
            End If
            If tempdate = "&nbsp;" Then
                Return "01/01/2000"
            End If
            If tempdate.Contains(" ") Then
                tempdate = Split(tempdate, " ")(0)
            End If
            Return Split(tempdate, "/")(1) & "/" & Split(tempdate, "/")(0) & "/" & Split(tempdate, "/")(2)
        Catch ex As Exception
            Return "12/12/2015"
        End Try


    End Function
    Public Function InsertGuestTempCart(CartId As String, dt As Data.DataTable) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            Dim Idfr As Integer = 0
            If dt.Rows.Count > 0 Then

                cmd.CommandText = "Insert into IMART_TempGuestCart(CartId,ProductIdfr,CartDate,Quantity) values('" & CartId & "'," & dt.Rows(0).Item("ProductIdfr") & ",'" & DateTime.Now.AddMinutes(800) & "'," & dt.Rows(0).Item("Quantity") & ")"
                cmd.ExecuteNonQuery()
            End If
            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function DeleteGuestTempCart(CartId As String) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()

            cmd.CommandText = "Delete from IMART_TempGuestCart where CartId='" & CartId & "'"
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function DeleteGuestTempCartProduct(CartId As String, ProductIdfr As Integer) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()

            cmd.CommandText = "Delete from IMART_TempGuestCart where CartId='" & CartId & "' and ProductIdfr=" & ProductIdfr & ""
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function UpdateGuestTempCart(CartId As String, dt As Data.DataTable) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            Dim Idfr As Integer = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                cmd.CommandText = "Update IMART_TempGuestCart set Quantity=" & dt.Rows(i).Item("Quantity") & " where CartId='" & CartId & "' and ProductIdfr=" & dt.Rows(i).Item("ProductIdfr") & ""
                cmd.ExecuteNonQuery()
            Next
            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function InsertGuestTempCartwithCartId(CartIdfr As Integer, dt As Data.DataTable) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            Dim Idfr As Integer = 0
            If dt.Rows.Count > 0 Then
                cmd.CommandText = "Insert into IMART_TempGuestCart(ProductIdfr,CartDate,Quantity) values(" & dt.Rows(0).Item("ProductIdfr") & ",'" & DateTime.Now.AddMinutes(800) & "'," & dt.Rows(0).Item("Quantity") & ");Select max(CartIdfr) from IMART_TempGuestCart"
                Idfr = CType(cmd.ExecuteScalar, Integer)
            End If
            Return Idfr
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function


    Public Function InsertUserTempCart(UserIdfr As Integer, dt As Data.DataTable) As String
        Dim str As String = ""
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            If dt.Rows.Count > 0 Then
                cmd.CommandText = "Insert into IMART_TempUserCart(UserIdfr,ProductIdfr,CartDate,Quantity) values(" & UserIdfr & "," & dt.Rows(0).Item("ProductIdfr") & ",'" & DateTime.Now.AddMinutes(800) & "'," & dt.Rows(0).Item("Quantity") & ")"
                str = cmd.CommandText
                cmd.ExecuteNonQuery()
            End If
            Return "OK"
        Catch ex As Exception
            Return "Error: " & str & "---" & ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function DeleteUserTempCart(UserIdfr As Integer) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()

            cmd.CommandText = "Delete from IMART_TempUserCart where UserIdfr=" & UserIdfr & ""
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function DeleteUserTempCartProduct(UserIdfr As Integer, ProductIdfr As Integer) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()

            cmd.CommandText = "Delete from IMART_TempUserCart where UserIdfr=" & UserIdfr & " and ProductIdfr=" & ProductIdfr & ""
            cmd.ExecuteNonQuery()

            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function UpdateUserTempCart(UserIdfr As Integer, dt As Data.DataTable) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            Dim Idfr As Integer = 0
            For i As Integer = 0 To dt.Rows.Count - 1
                cmd.CommandText = "Update IMART_TempUserCart set Quantity=" & dt.Rows(i).Item("Quantity") & " where UserIdfr=" & UserIdfr & " and ProductIdfr=" & dt.Rows(i).Item("ProductIdfr") & ""
                cmd.ExecuteNonQuery()
            Next
            Return "OK"
        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            Con.Close()
        End Try
    End Function



    Public Function GetGuestTempCart(CartId As String) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,(Select ProductName from IMART_Products where ProductIdfr=IMART_TempGuestCart.ProductIdfr) ProductName,(Select MRP from IMART_Products where ProductIdfr=IMART_TempGuestCart.ProductIdfr) MRP,(Select SalePrice from IMART_Products where ProductIdfr=IMART_TempGuestCart.ProductIdfr) SalePrice,Quantity,(Select ImagePath from IMART_Products where ProductIdfr=IMART_TempGuestCart.ProductIdfr) ImagePath from IMART_TempGuestCart where CartId='" & CartId & "'", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function GetUserTempCart(UserIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,(Select ProductName from IMART_Products where ProductIdfr=IMART_TempUserCart.ProductIdfr) ProductName,(Select MRP from IMART_Products where ProductIdfr=IMART_TempUserCart.ProductIdfr) MRP,(Select SalePrice from IMART_Products where ProductIdfr=IMART_TempUserCart.ProductIdfr) SalePrice,Quantity,(Select ImagePath from IMART_Products where ProductIdfr=IMART_TempUserCart.ProductIdfr) ImagePath from IMART_TempUserCart where UserIdfr=" & UserIdfr & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function
    Public Function InsertWishlist(UserIdfr As Integer, ProductIdfr As Integer) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand("Insert into IMART_Wishlist(UserIdfr,ProductIdfr) values (" & UserIdfr & "," & ProductIdfr & ")", Con)
            Con.Open()
            cmd.ExecuteNonQuery()
            Return "OK"
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function ConvertAmountFormat(amount As Decimal, Optional decimalcount As Integer = 2) As String

        amount = Math.Round(amount, decimalcount)
        Dim temp As String = ""

        If amount.ToString.Contains(".") = False Then
            temp = amount.ToString & "."
            For i As Integer = 0 To decimalcount - 1
                temp &= "0"
            Next
        Else
            temp = amount
        End If

        Dim teststr As String() = temp.ToString.Split(".")

        Dim finalstr As String = ""
        Dim testval As String = teststr(0)
        Dim length As Integer = testval.ToString.Length - 1
        Dim chars As Integer = 0
        Dim flag As Integer = 0

        While length >= 0

            If flag = 0 And chars = 3 Then
                finalstr = finalstr & ","
                flag = 1
            End If
            If flag = 1 And (chars Mod 2 = 1) And chars > 3 Then
                finalstr = finalstr & ","
            End If

            finalstr = finalstr & testval(length)
            chars = chars + 1
            length = length - 1
        End While

        Dim returnstr As String = ""
        length = finalstr.Length - 1
        While length >= 0
            returnstr = returnstr & finalstr(length)
            length = length - 1
        End While


        ' Dim cultureInfo As New System.Globalization.CultureInfo("en-IN")
        ' price = String.Format(cultureInfo, "{0:C}", myRate)
        'Return String.Format(cultureInfo, "{0:#,###}", amount) '& s

        ' Return String.Format("{0:n" + decimalcount.ToString() + "}", amount)
        Return returnstr & "." & teststr(1)
    End Function
    Public Function rupeestowords(rupees As Int64) As String
        If rupees < 0 Then
            Return ""
        End If
        Dim result As String = ""
        If (rupees >= 1) AndAlso (rupees <= 10) Then
            If (rupees Mod 10) = 1 Then
                result = "One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Nine"
            End If
            If (rupees Mod 10) = 0 Then
                result = "Ten"
            End If
        End If
        If rupees > 9 AndAlso rupees < 20 Then
            If rupees = 11 Then
                result = "Eleven"
            End If
            If rupees = 12 Then
                result = "Twelve"
            End If
            If rupees = 13 Then
                result = "Thirteen"
            End If
            If rupees = 14 Then
                result = "Forteen"
            End If
            If rupees = 15 Then
                result = "Fifteen"
            End If
            If rupees = 16 Then
                result = "Sixteen"
            End If
            If rupees = 17 Then
                result = "Seventeen"
            End If
            If rupees = 18 Then
                result = "Eighteen"
            End If
            If rupees = 19 Then
                result = "Nineteen"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 2 AndAlso (rupees Mod 10) = 0 Then
            result = "Twenty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 3 AndAlso (rupees Mod 10) = 0 Then
            result = "Thirty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 4 AndAlso (rupees Mod 10) = 0 Then
            result = "Forty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 5 AndAlso (rupees Mod 10) = 0 Then
            result = "Fifty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 6 AndAlso (rupees Mod 10) = 0 Then
            result = "Sixty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 7 AndAlso (rupees Mod 10) = 0 Then
            result = "Seventy"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 8 AndAlso (rupees Mod 10) = 0 Then
            result = "Eighty"
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 9 AndAlso (rupees Mod 10) = 0 Then
            result = "Ninty"
        End If

        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 2 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Twenty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Twenty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Twenty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Twenty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Twenty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Twenty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Twenty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Twenty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Twenty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 3 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Thirty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Thirty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Thirty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Thirty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Thirty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Thirty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Thirty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Thirty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Thirty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 4 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Forty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Forty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Forty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Forty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Forty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Forty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Forty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Forty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Forty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 5 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Fifty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Fifty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Fifty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Fifty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Fifty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Fifty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Fifty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Fifty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Fifty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 6 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Sixty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Sixty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Sixty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Sixty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Sixty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Sixty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Sixty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Sixty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Sixty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 7 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Seventy One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Seventy Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Seventy Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Seventy Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Seventy Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Seventy Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Seventy Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Seventy Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Seventy Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 8 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Eighty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Eighty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Eighty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Eighty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Eighty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Eighty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Eighty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Eighty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Eighty Nine"
            End If
        End If
        If rupees > 20 AndAlso Math.Floor(rupees / 10) = 9 AndAlso (rupees Mod 10) <> 0 Then
            If (rupees Mod 10) = 1 Then
                result = "Ninty One"
            End If
            If (rupees Mod 10) = 2 Then
                result = "Ninty Two"
            End If
            If (rupees Mod 10) = 3 Then
                result = "Ninty Three"
            End If
            If (rupees Mod 10) = 4 Then
                result = "Ninty Four"
            End If
            If (rupees Mod 10) = 5 Then
                result = "Ninty Five"
            End If
            If (rupees Mod 10) = 6 Then
                result = "Ninty Six"
            End If
            If (rupees Mod 10) = 7 Then
                result = "Ninty Seven"
            End If
            If (rupees Mod 10) = 8 Then
                result = "Ninty Eight"
            End If
            If (rupees Mod 10) = 9 Then
                result = "Ninty Nine"
            End If
        End If
        Return result
    End Function

    Public Function rupees1(rupees As Int64) As String
        Dim result As String = ""
        Dim res As Int64
        If (rupees / 10000000) > 0 Then
            res = Math.Floor(rupees / 10000000)
            rupees = rupees Mod 10000000
            If res >= 1 Then
                result = (result & Convert.ToString(" "c)) + rupeestowords(res) + " Crore"
            End If
        End If
        If (rupees / 100000) > 0 Then
            res = Math.Floor(rupees / 100000)
            rupees = rupees Mod 100000
            If res >= 1 Then
                result = (result & Convert.ToString(" "c)) + rupeestowords(res) + " Lakh"
            End If
        End If

        If (rupees / 1000) > 0 Then
            res = Math.Floor(rupees / 1000)
            rupees = rupees Mod 1000
            If res >= 1 Then
                result = (result & Convert.ToString(" "c)) + rupeestowords(res) + " Thousand"
            End If
        End If

        If (rupees / 100) > 0 Then
            res = Math.Floor(rupees / 100)
            rupees = rupees Mod 100
            If res >= 1 Then
                result = (result & Convert.ToString(" "c)) + rupeestowords(res) + " Hundred"
            End If
        End If
        If (rupees / 10) > 0 Then
            res = rupees Mod 100
            If res >= 1 Then
                result = (result & Convert.ToString(" ")) + rupeestowords(res)
            End If
        End If
        result = (result & Convert.ToString(" "c)) + " Rupees only"
        Return result
    End Function

    Public Function GetCategoryIdfr(CategoryName As String) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            If CategoryName.Contains("and") Then
                cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName & "' or CategoryName='" & CategoryName.Replace("and", "&") & "'"
            Else
                cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName & "'"
            End If


            Return CType(cmd.ExecuteScalar, String)
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function
    Public Function GetCategoryDetails(CategoryIdfr As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3 from IMART_Category order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetCategoryName(CategoryIdfr As String) As String
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con
            Con.Open()
            cmd.CommandText = "Select CategoryName from IMART_Category where CategoryIdfr=" & CategoryIdfr & ""


            Return CType(cmd.ExecuteScalar, String)
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class
