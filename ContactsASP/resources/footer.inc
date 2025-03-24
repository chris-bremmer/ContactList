
        <hr />
        <footer>
            <p>&copy; 2025 - <a href="https://bremmer.ca" taget="_blank">Chris Bremmer</a></p>
        </footer>
        <br>
        <%for each c in request.Cookies
            response.write(request.cookies(c))
        
        next%>
    </div>
</body>
</html>
