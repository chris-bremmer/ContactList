<%
Class SharedSession

    private psessionID
    private puserID
    private pkey
    private pvalue

    Private Sub Class_Initialize()
        psessionID = 0
        puserID = GetUserID
        pkey = ""
        pvalue = ""
    End Sub 

   Public Property Let Item(Key, Value)
      SaveSessionValue key,value
   End Property 
   Public Default Property Get Item(Key)
      Item = GetSessionValue(Key)
   End Property

   public sub Clear()
        dim db, rs, sql

        Set db = New DatabaseHelper
        sql = "DELETE FROM Session WHERE UserID = " & pUserID 
        db.ExecuteNonQuery(sql)
        db.CloseConnection
        set db = nothing
   end sub

   private function GetSessionValue(Key)
    dim result
        dim db, rs, sql

        Set db = New DatabaseHelper
        sql = "SELECT * FROM Session WHERE UserID = " & pUserID & " AND [Key] = '" & Key & "'"
        Set rs = db.ExecuteQuery(sql)
        if rs.EOF then
            result = ""
        else
            result = rs("Value")
        end if
        db.CloseConnection
        GetSessionValue = result
   end function

   private sub SaveSessionValue(Key, value)
        dim db, rs, sql

        Set db = New DatabaseHelper
        sql = "SELECT * FROM UserSettings WHERE UserID = " & puserID & " AND [Key] = '" & Key & "'"
        Set rs = db.ExecuteQuery(sql)
        if rs.EOF then
            query = "INSERT INTO UserSettings (UserID, [Key], [Value]) VALUES (" & puserID & ", '" & Key & "', '" & value & "')"
        else
            query = "UPDATE UserSettings SET [Value] = '" & value & "' WHERE UserID = " & puserID & " AND [Key] = '" & Key & "'"
        end if
        db.ExecuteNonQuery(query)
        db.CloseConnection
   end sub

End Class
%>