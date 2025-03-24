<%
Class DatabaseHelper
    Private conn
    Private connString

    ' Constructor
    Private Sub Class_Initialize()
        Set conn = CreateObject("ADODB.Connection")
        connString = ConnectionString
    End Sub 

    ' Destructor
    Private Sub Class_Terminate()
        If Not conn Is Nothing Then
            If conn.State = 1 Then 
                conn.Close
            End If
            Set conn = Nothing
        End If
    End Sub

    private function ConnectionString()
        on error Resume Next
        dim filePath
        filePath = Server.MapPath("connection.txt")
        filepath = Replace(filepath,"ContactList\ContactsASP","connection")
        Set fso = CreateObject("Scripting.FileSystemObject")
        Set objFileToRead = fso.OpenTextFile(filePath,1)
        sqlConnect = objFileToRead.ReadAll()
        objFileToRead.Close
        Set objFileToRead = Nothing
        ConnectionString = sqlConnect
        If Err.Number <> 0 Then
            Response.write("<br />ConnectionString Error: " & Err.Description)
        end if
    end function

    ' Open connection
    Public Sub OpenConnection()
        If conn.State = 0 Then 
            conn.Open ConnectionString
        End If
    End Sub

    ' Close connection
    Public Sub CloseConnection()
        If conn.State = 1 Then ' 1 = adStateOpen
            conn.Close
        End If
    End Sub

    ' Execute a query
    Public Function ExecuteQuery(query)
        OpenConnection
        Dim rs
        Set rs = CreateObject("ADODB.Recordset")
        rs.Open query, conn
        Set ExecuteQuery = rs
    End Function

    ' Execute a non-query (INSERT, UPDATE, DELETE)
    Public Sub ExecuteNonQuery(query)
        OpenConnection
        conn.Execute query
    End Sub
End Class
%>