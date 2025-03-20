<%
    function IsLen(str) 
        result = false
    
        if (str) then
            IsLen = (str.length > 0)
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

%>