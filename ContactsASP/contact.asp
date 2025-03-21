<!--#include file="resources/globals.inc"-->
<!--#include file="resources/header.inc"-->
<!--#include file="resources/contactmodel.inc"-->
<!--#include file="resources/data.inc"-->
<%
    dim db
    set db = new DatabaseHelper
    dim sql
    sql = "SELECT * FROM contacts where contactid = " & request.querystring("id")
    set rs = db.ExecuteQuery(sql)
    dim c 
    set c = new contactmodel
    c.LoadContact rs
%>


<h1>Contact Details</h1>
<div class="row">
    <div class="col-sm-6">Name</div>
</div>
<div class="row">
    <div class="col-sm-6"><strong><%=c.ContactName%></strong></div>
</div>

<div class="row">
    <div class="col-sm-6">Email</div>
</div>
<div class="row">
    <div class="col-sm-6"><strong><%=c.Email%></strong></div>
</div>

<div class="row">
    <div class="col-sm-6">Phone</div>
</div>
<div class="row">
    <div class="col-sm-6"><strong><%=c.Phone%></strong></div>
</div>

<div class="row">
    <div class="col-sm-6"><p><br />Modified: <%=c.Modified%></p></div>
</div>

<div class="row">
    <div class="col-sm-6"><p><br /><a href="contacts.asp" class="btn btn-primary">Back to List</a></p></div>
</div>



<!--#include file="resources/footer.inc"-->
