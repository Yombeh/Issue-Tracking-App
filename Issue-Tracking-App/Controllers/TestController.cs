using Issue_Tracking_App.Data;
using Issue_Tracking_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Issue_Tracking_App.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TestController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> HomePage()
        {

           var issues = await dbContext.Issues.ToListAsync();

            var Status = new StatusViewModel
            {

                StatusID = issues.GroupBy(s => s.StatusID).Select(g => g.Key.ToString()).ToList(),
                StatusCount = issues.GroupBy(s => s.StatusID).Select(g => g.Count()).ToList()
            };

            var Assignee = new AssigneeViewModel
            {
                AssigneeID = issues.GroupBy(s => s.AssigneeID).Select(g => g.Key.ToString()).ToList(),
                AssigneeCount = issues.GroupBy(s => s.AssigneeID).Select(g => g.Count()).ToList()
            };

            var Severity = new SeverityViewModel
            {
                SeverityID = issues.GroupBy(s => s.SeverityID).Select(g => g.Key.ToString()).ToList(),
                SeverityCount = issues.GroupBy(s => s.SeverityID).Select(g => g.Count()).ToList()
            };

            var HomePage = new HomePage
            {

                status = Status,
                assignee = Assignee,
                severity = Severity
            };

            return View(HomePage);

        }


      }
            

            

  }
            
               
    
    

