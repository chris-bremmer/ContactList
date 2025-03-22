<!--#include file="resources/header.inc"-->


<h2>Sign In</h2>

<%set usr = new UserSettings%>
<%set sess = new SharedSession %>

<%if usr.UserID <> "" then
    Response.Write("<p>You are already signed in as a user with ID '" & usr.UserID & "'</p>")
    Response.Write("<p>You can view the contacts list <a href=""contacts.asp"">here</a></p>")
else
    Response.Write("<p>You are not signed in. Please sign in through the CORE site.</p>")
end if
%>


<!--#include file="resources/footer.inc"-->