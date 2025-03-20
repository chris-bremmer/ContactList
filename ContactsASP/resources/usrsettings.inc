<%
Class UserSettings

    Public Property Let UserID(id)
      SetSetting "UserId", id
   End Property 
   Public Property Get UserID()
      UserID = GetSetting("UserId")
   End Property

    private function GetSetting(Key)
        dim result
        result = ""
        result = Request.Cookies(Key)

        GetSetting = result

    end function

    private sub SetSetting(Key, Value)
        Response.Cookies(Key) = Value
    end sub


End Class
%>