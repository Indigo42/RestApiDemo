RestApiDemo
===========

Description
-----------

This is a REST API that controls creating, retrieving, updating, and deleting users via JSON.  It is written in C#, and it uses ASP.NET MVC and Entity Framework Code First.

Specification
-------------

### Endpoints

*   `GET /api/users`: Returns all users.

*   `GET /api/users/{id}`: Returns the user with the specified ID.

*   `POST /api/users`: Adds a new user and returns the new record.

*   `PUT /api/users/{id}`: Updates the user and returns the updated record.

*   `DELETE /api/users/{id}`: Deletes the user.

### Database fields

*   `Id`: Cannot be updated by the client.

*   `UserName`: Cannot be updated by the client.

*   `Password`: Stored as a hash of the user's plain-text password; not serialized to the client; can be set by the client when the user is created.

*   `FullName`: Can be updated by the client; required.

*   `Location`: Can be updated by the client; optional.

*   `DateCreated`: Cannot be updated by the client.

*   `DateModified`: Cannot be updated by the client.

To-do list
----------

*   Prevent the `Password` field from being serialized to the client.  (`Newtonsoft.Json.JsonIgnoreAttribute` does this, but it also prevents the field from being serialized to the _server_.)
 
*   Store passwords as hashes of users' plain-text passwords.

*   Make sure that the client-updatability of the fields is consistent with the specification.

*   Make a front end.
