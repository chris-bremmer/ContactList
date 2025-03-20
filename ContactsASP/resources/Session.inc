<%
Class Session

    dim _sessionID
    dim _userID
    dim _key
    dim _value

   Public Property Let SessionID(value)
      _sessionID = value
   End Property 
   Public Property Get SessionID()
      SessionID = _sessionID
   End Property

   Public Property Let UserID(value)
      _userID = value
   End Property 
   Public Property Get UserID()
      UserID = _userID
   End Property

   Public Property Let Key(value)
      _key = value
   End Property 
   Public Property Get Key()
      Key = _key
   End Property

   Public Property Let Value(val)
      _value = val
   End Property 
   Public Property Get Value()
      Value = _value
   End Property

   public SaveValue(userID, Key, value)
        dim conn
        dim db
        dim query
        dim rs
        dim sql
        dim result
        result = false
        Set db = New DatabaseHelper(Connection)
        db.OpenConnection
        sql = "SELECT * FROM UserSettings WHERE UserID = " & userID & " AND [Key] = '" & Key & "'"
        Set rs = db.ExecuteQuery(sql)
        if rs.EOF then
            query = "INSERT INTO UserSettings (UserID, [Key], [Value]) VALUES (" & userID & ", '" & Key & "', '" & value & "')"
        else
            query = "UPDATE UserSettings SET [Value] = '" & value & "' WHERE UserID = " & userID & " AND [Key] = '" & Key & "'"
        end if
        db.ExecuteNonQuery(query)
        db.CloseConnection
        result = true
        SaveValue = result
   end function)



End Class
%>