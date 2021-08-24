using BugTracking.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

namespace BugTracking.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Surname).IsRequired().HasMaxLength(30);            

            builder.Entity<User>().HasData
            (
                new User { Id = 1, Name = "User1", Surname = "Test1" },
                new User { Id = 2, Name = "User2", Surname = "Test2" },
                new User { Id = 3, Name = "User3", Surname = "Test3" }
            );

            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Project>().Property(p => p.Description);
            builder.Entity<Project>().HasMany(p => p.Bugs).WithOne(p => p.Project).HasForeignKey(p => p.Id);

            builder.Entity<Project>().HasData
            (
                new Project
                {
                    Id = 1,
                    Name = "Project1",
                    Description = "Project Description1"
                },
                new Project
                {
                    Id = 2,
                    Name = "Project2",
                    Description = "Project Description2",
                },
                new Project
                {
                    Id = 3,
                    Name = "Project3",
                    Description = "Project Description3",
                }
            );

            builder.Entity<Bug>().ToTable("Bugs");
            builder.Entity<Bug>().HasKey(p => p.Id);
            builder.Entity<Bug>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Bug>().Property(p => p.ProjectId).IsRequired();
            builder.Entity<Bug>().Property(p => p.Project).IsRequired();
            builder.Entity<Bug>().Property(p => p.Description);
            builder.Entity<Bug>().Property(p => p.Users);
        }

    }
}