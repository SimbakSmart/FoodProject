﻿using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Data
{
    public class DbFoodContext : IdentityDbContext<User, Role, int>
    {
        public DbFoodContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Role>()
             .HasData(
                 new Role { Id = 1, Name = "Member", NormalizedName = "MEMBER" },
                 new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
             );

        }
    }
}
