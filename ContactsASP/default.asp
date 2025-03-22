
<!--#include file="resources/header.inc"-->

<div class="jumbotron">
    <h1>VCA Contacts</h1>
    <p class="lead">In classic ASP!</p>

    <p></p>
    <% If GetUserID() >0 then%>
    <p><a href="contacts.asp" class="btn btn-primary btn-lg">Contact List &raquo;</a></p>
        <%set uSess = new sharedsession %>
        <% if uSess("ContactID") > 0 then%>
    Continue viewing the <a href="contact.asp?id=<%=uSess("ContactID") %>">Contact</a> you were looking at on the CORE site.
            
            <% %>
        <%End if%>
    <%End If %>

</div>



<!--#include file="resources/footer.inc"-->