<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>VCA Contact List ASP</title>    
    <link rel="stylesheet" type="text/css" href="css/site.css">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
    <script src="resources/jquery.min.js" type="text/javascript"></script>
    <script src="resources/bootstrap.min.js" type="text/javascript"></script>
    <!--#include file="globals.inc"-->
    <!--#include file="session.inc"-->
    <!--#include file="data.inc"-->
    <%set uSess = new SharedSession%>
</head>
<body>

    <div class="container">
        <div class="row">
            <div class=col-sm-4><a href="default.asp">Home</a></div>
            <% if GetUserID()> 0 then %>
            <div class=col-sm-6><a href="signout.asp">Sign Out</a> <%=uSess("UserEmail")%></div>
            <% else %>
            <div class=col-sm-6>Sign In through the CORE site!</div>
            <% end if %>
            <div class=col-sm-2></div>
        </div>
    </div>
    <% set uSess = nothing %>
    <br />
    <div class="container body-content">
    