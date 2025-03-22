<!--#include file="resources/globals.inc"-->
<!--#include file="resources/session.inc"-->
<!--#include file="resources/data.inc"-->
<%
    LogOut
    Session.Abandon
    Response.Redirect("default.asp")
%>