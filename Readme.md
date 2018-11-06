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

## Create the models/tables
Contact class
```csharp
public class Contact: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

```
ToDo class
```csharp
public class ToDo:BaseEntity
{
    public string Text { get; set; }
    public bool Completed { get; set; }
}

```
BaseEntity Class
```csharp
public class BaseEntity
{
    public int Id { get; set; }
}
```
in the AppDbContext class the two lines with Dbset will tell entity framework to generate two tables
```csharp
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
            
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
}
```