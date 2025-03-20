<!--#include file="resources/globals.inc"-->
<!--#include file="resources/usrsettings.inc"-->
<!--#include file="resources/header.inc"-->


<h2>Sign In</h2>

<%set usr = new UserSettings%>
<%if usr.UserID <> "" then
        Response.Write("<p>You are already signed in as " & usr.UserID & "</p>")        
end if%>

<form action="signin.asp" method="post" class="form-horizontal">
    <div class="row">
        <div class="col-md-6">
            <label>Email</label>
            <input type="text" id="email" name="email" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <label>Password</label>
            <input type="password" id="password" name="password" class="form-control" />
        </div>
    </div>
        <div class="row">
        <div class="col-md-6">
            <input type="submit" value="Sign In" class="btn btn-success" />
        </div>
    </div>
</form>


<!--#include file="resources/footer.inc"-->