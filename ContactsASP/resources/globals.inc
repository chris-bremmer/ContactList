<%
function IsLen(str) 
    result = false
    
    if Len(str) then
        result = Len(str) > 0
    end if

    IsLen = result

end function

function GetUserID()
    
    On Error Resume Next
    set usr = new UserSettings

    if usr.UserID <> "" then
        GetUserID = usr.UserID
    else
        GetUserID = 0
    end if
    
If Err.Number <> 0 Then
    Response.write("<br />GetUserID Error: " & Err.Description)
    err.Clear
End If
end function

public sub LogOut
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

    On Error Resume Next
    result = Request.Cookies(Key)

    GetSetting = result
If Err.Number <> 0 Then
    Response.write("<br />GetSetting Error: " & Err.Description)
    err.Clear
End If
    
end function

private sub SetSetting(Key, Value)

    On Error Resume Next
    Response.Cookies(Key) = Value
    Response.Cookies(Key).Path = "/"
    Response.Cookies(Key).Domain = ".bremmer.ca"

    If Err.Number <> 0 Then
        Response.write("<br />SetSetting Error: " & Err.Description)
        err.Clear
    End If

end sub

public sub Clear()

    On Error Resume Next
    UserID = ""
    If Err.Number <> 0 Then
        Response.write("<br />Clear Error: " & Err.Description)
        err.Clear
    End If

end sub


End Class
%>