# Entity Framework Core Web App
This is a Web app for learning the entityFrameworkCore

## Install the package
Istall Microsoft.EntityFrameworkCore.SqlServer. We will use MS SQL Serve for the database.

Here We connected to the database via the database string that is placed in the `appsettings.json` as the `DefaultConnection`.
```sh
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EfCoreWebApp;Trusted_Connection=True;MultipleActiveResultSets=True"
  },

  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  }
}
```

## What is a Database Context
DB context is simply a class that helps to reach your database throught that class.
It is inherited from the DbContext class of EntityFrameworkCore.