using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerPilotLanding.Models;
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
            modelBuilder.Entity<LaunchSubscribtion>().ToTable("LaunchSubscribtions");
            modelBuilder.Entity<PanelRequest>().ToTable("PanelRequests");

        }

        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<LaunchSubscribtion> LaunchSubscribtions { get; set; }
        public DbSet<PanelRequest> PanelRequests { get; set; }

    }
}
