# AspNetCore.WebApi
Basic api operations for asp.net core webapi.

Example:
    Jwt Authentication Handler: 
        A JWT bearer scheme deserializing and validating a JWT bearer token to construct the user's identity.

    Jwt Authentication Challenge:
        A JWT bearer scheme returning a 401 result with a www-authenticate: bearer header

    Jwt Authentication Forbid:
        A JWT bearer scheme returning a 403 result.

Scaffold:
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet aspnet-codegenerator identity -dc WebApp1.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"

To gain full control of the database schema, inherit from one of the available Identity DbContext classes and configure the context to include the Identity schema by calling builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value) on the OnModelCreating method.
