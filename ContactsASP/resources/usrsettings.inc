<%
Class UserSettings

    Public Property Let UserID(id)
      SetSetting "UserID", id
   End Property 
   Public Property Get UserID()
      UserID = GetSetting("UserID")
   End Property

    private function GetSetting(Key)
        dim result
        result = ""
        on error resume next
        result = Request.Cookies(Key)

        GetSetting = result

    end function

    private sub SetSetting(Key, Value)
        Response.Cookies(Key) = Value
    end sub


End Class
%>