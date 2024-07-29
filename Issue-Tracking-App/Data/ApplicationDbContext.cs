using Issue_Tracking_App.Migrations;
using Issue_Tracking_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Issue_Tracking_App.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Issues> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Assignee> Assignees { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<Solved> Solveds { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<UserReports> UserReports { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Testers> Tester { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DifferentUserRoles> differentUserRoles { get; set; }
        public DbSet<CommentByDev> CommentByDevs { get; set; }
        public DbSet<CommentByTester> CommentByTesters { get; set; }

      





   }
}
