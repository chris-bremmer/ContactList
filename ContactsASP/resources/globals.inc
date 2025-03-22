<%
    function IsLen(str) 
        result = false
    
        if Len(str) then
            result = Len(str) > 0
        end if

        IsLen = result

    end function

    function GetUserID()    
        set usr = new UserSettings

        if usr.UserID <> "" then
            GetUserID = usr.UserID
        else
            GetUserID = 0
        end if

    end function

    sub LogOut
        set sess = new SharedSession
        sess.Clear
        set usr = new UserSettings
        usr.Clear
    end sub



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

   public sub Clear()
   dim int
    int = 0
        For Each cookie in Response.Cookies
            int = int + 1
            Response.write(int & ") " & cookie & "<br />")
            Response.Cookies(cookie) = ""
            Response.Cookies(cookie).Expires = DateAdd("d",-1,now())
        Next
   end sub


End Class
%>