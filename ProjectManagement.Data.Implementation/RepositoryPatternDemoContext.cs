using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectManagement.Entities;

namespace ProjectManagement.Data.Implementation
{
    public partial class RepositoryPatternDemoContext : DbContext
    {
        public RepositoryPatternDemoContext()
        {
        }

        public RepositoryPatternDemoContext(DbContextOptions<RepositoryPatternDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Tasks> Task { get; set; }

        public virtual DbSet<Project> Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
