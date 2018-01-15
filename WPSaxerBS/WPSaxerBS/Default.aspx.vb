Imports System.Drawing
Imports System.Globalization
Imports DevExpress.Web

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strGuid As String = ""
        Dim strMySorbaUser As String = ""
        Dim strColor As String = ""
        Dim dbC As New DbCon
        strGuid = Request.QueryString("gd")
        strMySorbaUser = Request.QueryString("mu")
        If strGuid <> "ba398417-4be0-4ab9-93e6-99b9f36668f3" Or strMySorbaUser.Length < 1 Then
        Response.Redirect("error.html")
        End If
        strColor = dbC.GetColorFilter(strMySorbaUser)
        If SqlDataSource1.SelectParameters("KWNR").DefaultValue = 0 then
        SqlDataSource1.SelectParameters("KWNR").DefaultValue = GetKW()
        SqlDataSource1.SelectParameters("JAHRNR").DefaultValue = Date.Today.Year
        Label1.Text = "KW " & SqlDataSource1.SelectParameters("KWNR").DefaultValue.ToString
        b_filter.Text = " Alle Aufgaben "
        AddFilter(strColor)
        End If
    End Sub

    Public Sub AddFilter(ByVal strFilter As String)

    If strFilter.Length > 0 Then

    Dim strFilterGesamt As String = ""
    strFilterGesamt =  "[grMo] =" & strFilter & " or [grDi] =" & strFilter & " or [grMi] =" & strFilter & " or [grDo] =" & strFilter & " or [grFr] =" & strFilter & " or [grSa] =" & strFilter & " or [grSo] =" & strFilter 
    BootstrapGridView1.FilterExpression = strFilterGesamt

    End If

    End Sub


    Public Function GetKW()
        Dim dateNow = DateTime.Now
        Dim dfi = DateTimeFormatInfo.CurrentInfo
        Dim calendar = dfi.Calendar

        ' using Thursday because I can.
        Dim weekOfyear = calendar.GetWeekOfYear(dateNow,dfi.CalendarWeekRule,DayOfWeek.Monday)
        Return weekOfyear
    End Function

    Protected Sub gv_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableDataCellEventArgs) Handles BootstrapGridView1.HtmlDataCellPrepared
        If e.DataColumn.FieldName = "Mo" Or e.DataColumn.FieldName = "Di" Or e.DataColumn.FieldName = "Mi" Or e.DataColumn.FieldName = "Don" Or e.DataColumn.FieldName = "Fr" Or e.DataColumn.FieldName = "Sa" Or e.DataColumn.FieldName = "So" Then

            Dim strFName As String = e.DataColumn.FieldName
            Dim strFnameGr As String = "gr" & strFName

            If strFName = "Don" Then
                strFnameGr = "grDo"
            End If

            Dim CurrentDataRow As DataRowView = CType(BootstrapGridView1.GetRow(e.VisibleIndex), DataRowView)

            If CurrentDataRow(strFnameGr).ToString <> "0" Then
                e.Cell.BackColor = Color.FromArgb(CurrentDataRow(strFnameGr))

            End If


        End If
    End Sub

    Protected Sub Button1_Click_Add(sender As Object, e As EventArgs) Handles Button1.Click
        Dim intVal As Integer =  SqlDataSource1.SelectParameters("KWNR").DefaultValue
        If intVal = 52 Then
             SqlDataSource1.SelectParameters("KWNR").DefaultValue =  1
             SqlDataSource1.SelectParameters("JAHRNR").DefaultValue =  SqlDataSource1.SelectParameters("JAHRNR").DefaultValue + 1
           Else
             SqlDataSource1.SelectParameters("KWNR").DefaultValue =  SqlDataSource1.SelectParameters("KWNR").DefaultValue + 1
        End If
             Label1.Text = "KW " & SqlDataSource1.SelectParameters("KWNR").DefaultValue.ToString
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim intVal As Integer =  SqlDataSource1.SelectParameters("KWNR").DefaultValue
        If intVal = 1 Then
             SqlDataSource1.SelectParameters("KWNR").DefaultValue =  52
             SqlDataSource1.SelectParameters("JAHRNR").DefaultValue =  SqlDataSource1.SelectParameters("JAHRNR").DefaultValue - 1
            Else
             SqlDataSource1.SelectParameters("KWNR").DefaultValue =  SqlDataSource1.SelectParameters("KWNR").DefaultValue -1 
        End If

     Label1.Text = "KW " & SqlDataSource1.SelectParameters("KWNR").DefaultValue.ToString

    End Sub

    Protected Sub b_filter_Click(sender As Object, e As EventArgs) Handles b_filter.Click

        If BootstrapGridView1.FilterExpression.Length > 0 Then
         BootstrapGridView1.FilterExpression = ""
         b_filter.Text = " Eigene Aufgaben"
        Else
         Dim dbC As New DbCon
         Dim strMySorbaUser = Request.QueryString("mu")
         Dim strColor = dbC.GetColorFilter(strMySorbaUser)
         AddFilter(strColor)
        b_filter.Text = " Alle Aufgaben "
        End If

    End Sub
End Class