# ContactList


## Functional Requirements

1. **User Account Creation**: Users should be able to create an account using a username and password.
2. **User Login/Logout**: Users should be able to log in and out of the application. Bonus points for the ability to reset the login or password.
3. **View Contact List**: After logging in, users should be able to view a list of their contacts.
4. **CRUD Operations**: Users should be able to create, read, update, and delete contacts in their list.
5. **Contact Search**: Users should be able to search for contacts in their list using the contact's name or other relevant information.


#### Notes

While it does seem possible to share real sessions between .Net core and classic asp, the time and research needed to set that up seemed beyond the scope, given the timeframe.

I decided in this case to use a shared cookie and a database session, just for demonstration purposes.

There are quite a number of improvements I would love to make, but I feel this shows I know my way around both .Net Core and classic asp well enough for now.