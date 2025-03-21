<%
class ContactModel

    private pContactId
    private pName
    private pEmail
    private pPhone
    private pFavourite
    private pIsActive
    private pModified


    public sub LoadContact(rs)
        pContactId = rs("ContactId")
        pName = rs("Name")
        pEmail = rs("Email")
        pPhone = rs("Phone")
        pFavourite = rs("Favourite")
        pIsActive = rs("IsActive")
        pModified = rs("Modified")        
    end sub

    Public Property Let ContactId(value)
       pContactId = value
    End Property 
    Public Property Get ContactId()
       ContactId = pContactId
    End Property


    Public Property Let ContactName(value)
       pName = value
    End Property 
    Public Property Get ContactName()
       ContactName = pName
    End Property


    Public Property Let Email(value)
       pEmail = value
    End Property 
    Public Property Get Email()
       Email = pEmail
    End Property


    Public Property Let Phone(value)
       pPhone = value
    End Property 
    Public Property Get Phone()
       Phone = pPhone
    End Property


    Public Property Let Favourite(value)
       pFavourite = value
    End Property 
    Public Property Get Favourite()
       Favourite = pFavourite
    End Property


    Public Property Let IsActive(value)
       pIsActive = value
    End Property 
    Public Property Get IsActive()
       IsActive = pIsActive
    End Property


    Public Property Let Modified(value)
       pModified = value
    End Property 
    Public Property Get Modified()
       Modified = pModified
    End Property



end class
%>