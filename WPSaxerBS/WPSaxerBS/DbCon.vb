Imports System.Data.SqlClient

Public Class DbCon

    Public Function GetColorFilter(byval strMySorbaBenutzer As String) As String
    
    Dim strRet As String = ""
    dim myConn As SqlConnection
    dim myCmd As SqlCommand
    dim myReader As SqlDataReader
    dim results As String

    myConn = New SqlConnection("Data Source=sqlserver;Initial Catalog=WocheplanSaxer;User ID=Wochenplan;Password=1234@Echo;Initial Catalog=WocheplanSaxer;Persist Security Info=true")
    myCmd = myConn.CreateCommand
    myCmd.CommandText = "SELECT tblGroup.Farbe FROM tblUser INNER JOIN tblGroup ON tblUser.Username = tblGroup.Gruppe WHERE tblUser.mySorbaBenutzer ='" & strMySorbaBenutzer & "'"
    'Open the connection.
    myConn.Open()
    myReader = myCmd.ExecuteReader()
    Dim dTable As New DataTable
    dTable.Load(myReader)
    myReader.Close()
    myConn.Close()

    If dTable.Rows.Count > 0 Then
       Dim rw As DataRow = dTable.Rows(0)
       strRet = rw("Farbe").ToString
    End If

    Return strRet
    End Function

End Class
