using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JoCoHome_Dollo.Models;

namespace JoCoHome_Dollo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JoCoHome_Dollo.Models.Product> Product { get; set; }
        public DbSet<JoCoHome_Dollo.Models.Contact> Contact { get; set; }
    }
}
