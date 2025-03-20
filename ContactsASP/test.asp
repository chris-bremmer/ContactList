<!--#include file="resources/globals.inc"-->
<html>
    <head>
        <title>Classic ASP Page</title>
        <link rel="stylesheet" type="text/css" href="resources/site.css">
    </head>
    <body>
        <h1>Welcome to Classic ASP</h1>
        <p>This is a classic ASP page.</p>
        <p>Here is the current date and time: <%=Now%></p>      
        <p>It has been a long, long time since I have woked with Classic ASP!</p>
        <p><strong>
            <%if IsLen(Session("UserId")) Then%>
                Your user id is: " & <%=Session("UserId")%>
                
            <%Else%>
                There is no user id in the session.        
            <%End If%>
        </strong></p>

        <%Session("username")="Donald Duck"
            dim i
            For Each i in Session.Contents
            Response.Write(i & "<br>")
            Next
        %>
    </body>
</html>