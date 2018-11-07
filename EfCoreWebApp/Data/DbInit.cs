using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

namespace EfCoreWebApp.Data
{
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
}
