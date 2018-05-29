using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilotLanding.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;

namespace GamerPilotLanding.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<User>().ToTable("Subscriptions");
            modelBuilder.Entity<User>().ToTable("PanelRequests");

        }

        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<User> Subscriptions { get; set; }
        public DbSet<User> PanelRequests { get; set; }

    }
}
