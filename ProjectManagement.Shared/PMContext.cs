using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Entities;
using ProjectManagement.Entities.Enums;
using System;
using System.Linq;

namespace ProjectManagement.Shared
{
    public class PMContext : DbContext
    {

        public PMContext(DbContextOptions<PMContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PMContext(serviceProvider.GetRequiredService<DbContextOptions<PMContext>>()))
            {
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                        new Project { ID = 1, Name = "Project1", Detail = "test project 1", CreatedOn = DateTime.Today },
                        new Project { ID = 2, Name = "Project2", Detail = "test project 2", CreatedOn = DateTime.Today },
                        new Project { ID = 3, Name = "Project3", Detail = "test project 3", CreatedOn = DateTime.Today },
                        new Project { ID = 4, Name = "Project4", Detail = "test project 4", CreatedOn = DateTime.Today },
                        new Project { ID = 5, Name = "Project5", Detail = "test project 5", CreatedOn = DateTime.Today },
                        new Project { ID = 6, Name = "Project6", Detail = "test project 6", CreatedOn = DateTime.Today });
                    context.SaveChanges();
                }

                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(new Tasks { ID = 1, ProjectID = 1, Status = TaskStatus.InProgress, AssignedToUserID = 1, Detail = "test task assigned to user 1 and project 1", CreatedOn = DateTime.Today },
                        new Tasks { ID = 2, ProjectID = 2, Status = TaskStatus.QA, AssignedToUserID = 2, Detail = "test task assigned to user 2 and project 2", CreatedOn = DateTime.Today },
                        new Tasks { ID = 3, ProjectID = 2, Status = TaskStatus.Completed, AssignedToUserID = 2, Detail = "test task assigned to user 2 and project 2", CreatedOn = DateTime.Today });
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(new User { ID = 1, FirstName = "kiran", LastName = "kumar", Email = "kiran.kumar@test.com", Password = "Password1" },
                        new User { ID = 2, FirstName = "Naveen", LastName = "Kumar", Email = "Naveen.Kumar@test.com", Password = "Password1" },
                        new User { ID = 3, FirstName = "Arun", LastName = "Kumar", Email = "Arun.Kumar@test.com", Password = "Password1" },
                        new User { ID = 4, FirstName = "Ravi", LastName = "Kumar", Email = "Ravi.Kumar@test.com", Password = "Password1" },
                        new User { ID = 5, FirstName = "Sunil", LastName = "Kumar", Email = "Sunil.Kumar@test.com", Password = "Password1" },
                        new User { ID = 6, FirstName = "Vijay", LastName = "Kumar", Email = "Vijay.Kumar@test.com", Password = "Password1" });
                    context.SaveChanges();
                }
            }
        }
    }
}
