using Issue_Tracking_App.Data;
using Issue_Tracking_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace Issue_Tracking_App.Controllers
{
    public class TrackingController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public TrackingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            var assignees = await dbContext.Assignees.ToListAsync();
            var status = await dbContext.Statuses.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();

            var view = new ListModels
            {
                Assignees = assignees,
                Statuses = status,
                Severities = severity
            };

            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ListModels viewModel)
        {
            var view = new Issues
            {

                Summary = viewModel.Summary,
                StatusID = viewModel.StatusID,
                EstimateTime = viewModel.EstimateTime,
                DateTimePicker = viewModel.DateTimePicker,
                Created = viewModel.Created,
                AssigneeID = viewModel.AssigneeID,
                SeverityID = viewModel.SeverityID,

            };

            await dbContext.Issues.AddAsync(view);
            await dbContext.SaveChangesAsync();

            TempData["AddNewIssue"] = "Issue Successfully Added";

            return RedirectToAction("IssueList", "Tracking");
        }

        [HttpGet]
        public async Task<IActionResult> IssueList(string searchString)
        {
            var issue = await dbContext.Issues.ToListAsync();
          
            if (!String.IsNullOrEmpty(searchString))
            {
                issue = issue.Where(s => s.Summary.ToLower().Contains(searchString.ToLower())).ToList();
            }
           
            var issueModel = new List<IssueViewModel>();

            foreach (var issues in issue)
            {

                //retrieve related entity names base on foreign keg Id

                var StatusName = dbContext.Statuses.FirstOrDefault(s => s.Id == issues.StatusID)?.StatusName;
                var AssigneeName = dbContext.Assignees.FirstOrDefault(a => a.Id == issues.AssigneeID)?.AssigneeName;
                var SeverityName = dbContext.Severities.FirstOrDefault(s => s.Id == issues.SeverityID)?.SeverityName;

                var model = new IssueViewModel
                {

                    IssueId = issues.IssueNumber,
                    Summary = issues.Summary,
                    StatusName = StatusName,
                    EstimatedTime = issues.EstimateTime,
                    DateTimePicker = issues.DateTimePicker,
                    Created = issues.Created,
                    AssigneeName = AssigneeName,
                    SeverityName = SeverityName,

                };

                issueModel.Add(model);

            }

            string deleteMessage = TempData["DeleteMessage"] as string;
            ViewBag.DeleteMessage = deleteMessage;

            string addIssue = TempData["AddNewIssue"] as string;
            ViewBag.AddNewIssue = addIssue;

            string editMessage = TempData["EditMessage"] as string;
            ViewBag.EditMessage = editMessage;

            return View(issueModel);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var issue = await dbContext.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            var assignees = await dbContext.Assignees.ToListAsync();
            var status = await dbContext.Statuses.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();

            var issues = new EditviewModel
            {
                Summary = issue.Summary,
                StatusID = issue.StatusID,
                EstimatedTime = issue.EstimateTime,
                DateTimePicker = issue.DateTimePicker,
                Created = issue.Created,
                AssigneeID = issue.AssigneeID,
                SeverityID = issue.SeverityID,

                Assignees = assignees,
                Statuses = status,
                Severities = severity,

            };
            return View(issues);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditviewModel model)
        {


            var issue = await dbContext.Issues.FindAsync(id);
            if (issue is not null)
            {

                issue.Summary = model.Summary;
                issue.StatusID = model.StatusID;
                issue.EstimateTime = model.EstimatedTime;
                issue.DateTimePicker = model.DateTimePicker;
                issue.Created = model.Created;
                issue.AssigneeID = model.AssigneeID;
                issue.SeverityID = model.SeverityID;
                

                await dbContext.SaveChangesAsync();
            }
            TempData["EditMessage"] = "Successfully Edited";

            return RedirectToAction("IssueList", "Tracking");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {


            var issue = await dbContext.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }
            dbContext.Issues.Remove(issue);
            await dbContext.SaveChangesAsync();

            TempData["DeleteMessage"] = "Issue Deleted Successfully";

            return RedirectToAction("IssueList", "Tracking");



        }
        [HttpGet]
        public async Task<ActionResult> Solved()
        {

            var assignees = await dbContext.Assignees.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();
            var issues = await dbContext.Issues.ToListAsync();

            var view = new Solved
            {
                Assignees = assignees,
                Severities = severity,
                Issues = issues
            };

            return View(view);
        }

        [HttpPost]
        public async Task<ActionResult> solved(Solved viewModel)
        {

            var view = new Solved
            {
                IssueNumber = viewModel.IssueNumber,
                IssuesID = viewModel.IssuesID,
                EstimateTime = viewModel.EstimateTime,
                DatePicker = viewModel.DatePicker,
                Created = viewModel.Created,
                AssigneeID = viewModel.AssigneeID,
                SeverityID = viewModel.SeverityID,
                Comment = viewModel.Comment
            };

            await dbContext.Solveds.AddAsync(view);
            await dbContext.SaveChangesAsync();

            TempData["AddSolved"] = "Solved Issue Succesfully Added";

            return RedirectToAction("SolvedList", "Tracking");
        }

        [HttpGet]
        public async Task<IActionResult> SolvedList(string searchString)
        {

            if(dbContext.Solveds == null)
            {
                return (ActionResult)NotFound();    
            }

            var solvedIssue = await dbContext.Solveds.ToListAsync();
            var results = await dbContext.Issues.ToListAsync();     

            if (!String.IsNullOrEmpty(searchString))
            {
                                                                             
                var find = results.Where(x => x.Summary.Contains(searchString)).ToList();

                solvedIssue =  solvedIssue.Where(s => find.Any(f => f.IssueNumber == s.IssueNumber)).ToList();

            }

            var issueList= new List<SolvedViewModel>();

            foreach (var issue in solvedIssue)
            {

                var assignee = dbContext.Assignees.FirstOrDefault(a => a.Id == issue.AssigneeID)?.AssigneeName;
                var severity = dbContext.Severities.FirstOrDefault(s => s.Id == issue.SeverityID)?.SeverityName;
                var summary = dbContext.Issues.FirstOrDefault(a => a.IssueNumber == issue.IssuesID)?.Summary;


                var model = new SolvedViewModel
                {

                    IssueNumber = issue.IssueNumber,
                    IssuesID = summary,
                    AssigneeID = assignee,
                    SeverityID = severity,
                    EstimateTime = issue.EstimateTime,
                    DatePicker = issue.DatePicker,
                    Comment = issue.Comment

                };

                issueList.Add(model);
            }

            string addSolved = TempData["AddSolved"] as string;
            ViewBag.AddSolved = addSolved;

            string editSolved = TempData["EditSolved"] as string;
            ViewBag.EditSolved = editSolved;

            string deleteSolved = TempData["DeleteSolved"] as string;
            ViewBag.DeleteSolved = deleteSolved;

            return View(issueList);


        }


        [HttpGet]
        public async Task<IActionResult> DeleteSolved(int id)
        {


            var issue = await dbContext.Solveds.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            dbContext.Solveds.Remove(issue);
            await dbContext.SaveChangesAsync();

            TempData["DeleteSolved"] = "Solved Issue Successfully Deleted";

            return RedirectToAction("SolvedList", "Tracking");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditSolved(int id)
        {

            var issue = await dbContext.Solveds.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            var assignees = await dbContext.Assignees.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();
            var summary = await dbContext.Issues.ToListAsync();

            var issues = new EditSolvedViewModel
            {
               IssuesID = issue.IssuesID,
                StatusID = issue.StatusID,
                EstimateTime = issue.EstimateTime,
                Created = issue.Created,
                AssigneeID = issue.AssigneeID,
                SeverityID = issue.SeverityID,
                Comment = issue.Comment,

                Assignees = assignees,
                Severities = severity,
                Issues = summary

            };
            return View(issues);
        }
        

        [HttpPost]
        public async Task<IActionResult> EditSolved(int id, EditSolvedViewModel model)
        {

            var issue = await dbContext.Solveds.FindAsync(id);
            if (issue is not null)
            {

                issue.IssuesID = model.IssuesID;
                issue.StatusID = model.StatusID;
                issue.EstimateTime = model.EstimateTime;
                issue.Created = model.Created;
                issue.AssigneeID = model.AssigneeID;
                issue.SeverityID = model.SeverityID;
                issue.Comment = model.Comment;

                await dbContext.SaveChangesAsync();
            }
            TempData["EditSolved"] = "Solved Issue Successfully deleted";

            return RedirectToAction("SolvedList","Tracking");

        }

        [HttpGet]
        public ActionResult Dashboard()
        {

            var issues = dbContext.Issues.ToList();

            // Group data by status and count the number of issues for each status
            var status = issues.GroupBy(i => i.StatusID)
                                    .Select(g => new DashboardViewModel { StatusID = g.Key, IssueCount = g.Count() });

            return View(status);
        }


    }
}
            
        



      
       


    

