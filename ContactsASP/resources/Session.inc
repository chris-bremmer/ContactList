<%
Class Session

    private psessionID
    private puserID
    private pkey
    private pvalue

    ' Constructor
    Private Sub Class_Initialize(Userid, Key, Value)
        psessionID = 0
        puserID = Userid
        pkey = Key
        pvalue = Value
        SaveValue
    End Sub 

   Public Property Let SessionID(value)
      psessionID = value
   End Property 
   Public Property Get SessionID()
      SessionID = psessionID
   End Property

   Public Property Let UserID(value)
      puserID = value
   End Property 
   Public Property Get UserID()
      UserID = puserID
   End Property

   Public Property Let Key(value)
      pkey = value
   End Property 
   Public Property Get Key()
      Key = pkey
   End Property

   Public Property Let Value(val)
      pvalue = val
   End Property 
   Public Property Get Value()
      Value = pvalue
   End Property


   public function GetValue(UserID, Key)
    dim result
        dim conn
        dim db
        dim query
        dim rs
        dim sql
        Set db = New DatabaseHelper()
        sql = "SELECT * FROM UserSettings WHERE UserID = " & UserID & " AND [Key] = '" & Key & "'"
        Set rs = db.ExecuteQuery(sql)
        if rs.EOF then
            result = ""
        else
            result = rs("Value")
        end if
        db.CloseConnection
        GetValue = result
   end function

   public sub SaveValue(userID, Key, value)
        dim conn
        dim db
        dim query
        dim rs
        dim sql
        Set db = New DatabaseHelper()
        sql = "SELECT * FROM UserSettings WHERE UserID = " & userID & " AND [Key] = '" & Key & "'"
        Set rs = db.ExecuteQuery(sql)
        if rs.EOF then
            query = "INSERT INTO UserSettings (UserID, [Key], [Value]) VALUES (" & userID & ", '" & Key & "', '" & value & "')"
        else
            query = "UPDATE UserSettings SET [Value] = '" & value & "' WHERE UserID = " & userID & " AND [Key] = '" & Key & "'"
        end if
        db.ExecuteNonQuery(query)
        db.CloseConnection
   end function)

End Class
%>