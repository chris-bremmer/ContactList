<!--#include file="resources/header.inc"-->
<%
    dim userID
    userID = GetUserID()
    if userID = 0 then
        Response.Redirect("signin.asp")
    end if
    dim db
    set db = new DatabaseHelper
    dim sql
    sql = "select * from contacts where userid=" & getuserid & " order by name"
    sql = replace(sql,"@userid", userID)
    db.OpenConnection
    set rs = db.ExecuteQuery(sql)
%>


        <div class="jumbotron">
            <h1>VCA Contacts</h1>
            <p class="lead">In classic ASP!</p>

            <div class="row">
                <div class="col-sm-12">
                    <table class="table table-responsive">
                        <tr>
                            <th><label>Name</label></th>
                            <th><label>Email</label></th>
                            <th><label>Phone</label></th>
                            <th><label>Favourite</label></th>
                        </tr>
                        <%do while not rs.eof %>
                        <tr>
                            <td><a href="contact.asp?id=<%=rs("ContactId")%>"><%=rs("name")%></a></td>
                            <td><a href="mailto:<%=rs("Email")%><"><%=rs("Email")%></a></td>
                            <td><a href="tel:<%=rs("Phone")%></a>"><%=rs("Phone")%></a></td>
                            <td><input type="checkbox" onclick="return false" <%if rs("favourite") then%> checked="checked"<%end if%> />&nbsp</td>
                        </tr>
                        <%rs.movenext%>
                        <%loop %>
                    </table>
                </div>
            </div>
        </div>



<!--#include file="resources/footer.inc"-->