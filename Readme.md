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

## Creating the database
In startup.cs we need to add the following using namespaces
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

 //And the Register our DbContext
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    services.AddMvc();
}
```
Now we will create a static class `DbInit` to seed some fake data to the database. Firstly we will check if the database is created or not. If the database
is not created it will do the seedings.
at the end we need to save the changes to the database synchronously or unsynchronusly. 
```csharp
public static class DbInit
{
    public static void InitializeWithFakeData(AppDbContext context)
    {
        // Makes sure that database is created
        // If it is created it does nothing (If it is not created it is going to create a database)
        context.Database.EnsureCreated();

        // Check if the context table contain any data If does not add the fake data
        if (!context.Contacts.Any())
        {
            context.Contacts.Add(new Contact() {FirstName = "Ahmed", LastName = "Smith", Email = "abc@abc.com"});
            context.Contacts.Add(new Contact() {FirstName = "John", LastName = "Smith", Email = "dbc@abc.com"});
        }

        if (!context.ToDos.Any())
        {
            context.ToDos.Add(new ToDo() {Text = "Wash the car", Completed = true});
        }

        context.SaveChanges();
    }
}
```
Now we  need to call this class. We will remove the `BuildWebHost(args).Run();` method and call the host. 
```csharp
public static void Main(string[] args)
{
    var host = BuildWebHost(args);
    using (var newScope=host.Services.CreateScope())
    {
        // Register the context class
        var context = newScope.ServiceProvider.GetRequiredService<AppDbContext>();
        // Call DbInit 
        DbInit.InitializeWithFakeData(context);
    }

    //* NotFORGET
    host.Run();

}
```
the using rapper ensures that the service will be disposed when this part of code. 

Now you can run the project to see if this work.

> Notice: Incase of error make sure to check your DatabaseContext class constructor to be `public`. If it is not public dependency injection cannot initialize it.
