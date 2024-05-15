using Issue_Tracking_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Issue_Tracking_App.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
                
        }
            
        public DbSet<Issues>Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Assignee>Assignees{ get; set; }
        public DbSet<Severity> Severities { get; set; }

        public DbSet<Solved> Solveds { get; set; }

           
    }
}
