using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

namespace EfCoreWebApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
