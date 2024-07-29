using Issue_Tracking_App.Data;
using Issue_Tracking_App.Migrations;
using Issue_Tracking_App.Models;
using Issue_Tracking_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;


namespace Issue_Tracking_App.Controllers
{
    public class TrackingController : Controller
    {
    

        private readonly ApplicationDbContext dbContext;
        private readonly MailService mailService;

 

        public TrackingController(ApplicationDbContext dbContext, MailService mailService)
        {

            this.dbContext = dbContext;
            this.mailService = mailService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            var apps = await dbContext.Applications.ToListAsync();
            var newIssue = new ApplicationsViewModel
            {
                Applications = apps,
            };

            return View(newIssue);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserPage(ApplicationsViewModel viewModel)
        {

            var issue = new UserReports
            {

                Status = "Sent",
                AdminStatus = "New",
                DevStatus = "New",
                TesterStatus = "New",
                userName = User.Identity.Name.Split("\\")[1],
                ApplicationID = viewModel.ApplicationID,
                Description = viewModel.Description,
                DatePicker = viewModel.DatePicker,
                CreatedDate = viewModel.CreatedDate,
           

            };

            await dbContext.UserReports.AddAsync(issue);
            await dbContext.SaveChangesAsync();
            TempData["IssueSent"] = "Issue Successfullly Sent.";

            var userName = User.Identity.Name.Split("\\")[1];
            var email = $"{userName}@mrc.gm";
            var subject = " Issue was sucessfully sent.Please keep track of your application Status.";
            mailService.SendMail( userName, email, subject);
            var appName = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID)?.AppName;

            var Adminemail = "hcham@mrc.gm";
            var Adminsubject = $" {userName} has an Issue with The  {appName} ";
            mailService.SendFirstMailToAdmin(Adminemail, Adminsubject);

            return RedirectToAction("UserInputlist", "Tracking");

        }

        // List of reports for a specific User

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserInputList()
        {
            
            var user = User.Identity.Name.Split("\\")[1];
            var issue = await dbContext.UserReports
                         .Where(s => s.userName == user).ToListAsync();
            var IssueList = new List<IssueListViewModel>();

            foreach (var item in issue)
            {
                var app = dbContext.Applications.FirstOrDefault(s => s.AppId == item.ApplicationID)?.AppName;
                var data = new IssueListViewModel
                {
                    Id = item.UserReportId,
                    ApplicationName = app,
                    userName = User.Identity.Name.Split("\\")[1],
                    CreatedDate = item.CreatedDate,
                    Description = item.Description,
                    DatePicker = item.DatePicker,
                    Status = item.Status,
                };

                IssueList.Add(data);

            }

            string issueSent = TempData["IssueSent"] as string;
            ViewBag.IssueSent = issueSent;
            return View(IssueList);

        }

        // Add claims for to Users
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DifferentUsers()
        {
            await dbContext.differentUserRoles.ToListAsync();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DifferentUsers(DifferentUsersViewModel roles)
        {
        
            var model = new DifferentUserRoles
            {
                UserName = roles.UserName,
                values = roles.values,
                role = roles.role,

            };
            await dbContext.differentUserRoles.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("UserPage", "Tracking");
          
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllClaims()
        {
            var claims = await dbContext.differentUserRoles.ToListAsync();
            var allClaims = new List<DifferentUsersViewModel>();

            foreach (var user in claims)
            {
                var person = new DifferentUsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    values = user.values,
                    role = user.role,
                };

                allClaims.Add(person);

            }
            return View(allClaims);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditClaims(int id)
        {

            var claim = await dbContext.differentUserRoles.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }
            var Claims = new DifferentUsersViewModel
            {
                Id = claim.Id,
                UserName = claim.UserName,
                role = claim.role,
                values = claim.values,
            };

            return View(Claims);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditClaims(int id, DifferentUsersViewModel viewModel)
        {
            var claim = await dbContext.differentUserRoles.FindAsync(id);
            if (claim != null)
            {
                claim.Id = viewModel.Id;
                claim.UserName = viewModel.UserName;
                claim.role = viewModel.role;
                claim.values = viewModel.values;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("AllClaims", "Tracking");
        }

        [Authorize (Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var claim = dbContext.differentUserRoles.Find(id);

            if(claim != null) {

                dbContext.differentUserRoles.Remove(claim);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("AllClaims", "Tracking");

        }

        [Authorize (Policy = "Admin")]
        [HttpGet]
        public async  Task<IActionResult> Details(int id)
        {

            //name, application, description, datepicker,date
            var issue = await dbContext.UserReports.FindAsync(id);

          
            
            await dbContext.SaveChangesAsync(); 
            
            if (issue == null)
            {
               return NotFound();
            }
            var application =  dbContext.Applications.FirstOrDefault( s => s.AppId == issue.ApplicationID)?.AppName;
            var devComment =  await dbContext.CommentByDevs.Where( s => s.UserReportID == issue.UserReportId).ToListAsync();
            var testercomment = await dbContext.CommentByTesters.Where( s=> s.UserReportID == issue.UserReportId).ToListAsync();
            var model = new IssueListViewModel
            {
                devComments = devComment,
                testerComments = testercomment,
                Id = issue.UserReportId,
                userName = issue.userName,
                ApplicationName =application,
                Description = issue.Description,
                CreatedDate = issue.CreatedDate,
                DatePicker = issue.DatePicker,

            };
           
            return View(model);
        }

        // Make a List of all  reports that where submitted 
        [Authorize(Policy = "Admin")]
        [HttpGet]

        public async Task<IActionResult> AllReports()
        {

            var reports = await dbContext.UserReports.ToListAsync();

            var reportList = new List<IssueListViewModel>();
        
            foreach (var issue in reports)
            {
                var app = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID);

                var data = new IssueListViewModel
                {

                    Id = issue.UserReportId,
                    userName = issue.userName,
                    ApplicationName = app?.AppName,
                    Description = issue.Description,
                    CreatedDate = issue.CreatedDate,
                    DatePicker = issue.DatePicker,
                    AdminStatus = issue.AdminStatus,
                };

                reportList.Add(data);

            }

            return View(reportList);

        }
       
        [Authorize]
        [HttpGet]
        public async  Task<IActionResult> Test(int id)
        {
            var issue = await dbContext.UserReports.FindAsync(id);
            var app = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID)?.AppName;
            var tester = await dbContext.Tester.ToListAsync();

            
            var model = new TesterViewModel
            { 
                Id = issue.UserReportId,
                userName = issue.userName,
                IssueCreated = issue,
                appName = app,   
            };
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Test(int id,TesterViewModel model)
        {
            var issue = await dbContext.UserReports.FindAsync(id);
            var app = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID)?.AppName;

            issue.AdminStatus = "Tester Assigned";
            issue.TesterStatus = "New";

            dbContext.Update(issue);
            await dbContext.SaveChangesAsync();

            if(issue == null)
            {
                NotFound();
            }

           var report = new Test
           {
               UserReportID = id,
               Tester = model.Tester,
               Comment = model.Comment,
           };

            var tester = report.Tester;
            var testersEmail = $"{tester}@mrc.gm";
            var subject = $"You have been assigned to Test an Issue created by {issue.userName} on The {app}";
            mailService.SendMailToTester(tester, testersEmail, subject);

            await dbContext.Tests.AddAsync(report);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("AllReports","Tracking");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TestersList()
        {
            var UserName = User.Identity.Name.Split("\\")[1];
            ViewBag.TestersName = UserName;
            var allReports = await dbContext.Tests
                .Where(s => s.Tester == UserName).ToListAsync();

            var TesterList =  new List<TesterViewModel>();
            foreach(var report in allReports)
            {
                var issue = dbContext.UserReports.FirstOrDefault(S => S.UserReportId == report.UserReportID);

                var severity = dbContext.Severities.FirstOrDefault(s => s.Id == report.Id)?.Id;
               
                if (issue != null)
                {

                    var app = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID)?.AppName;
                    if(app != null) {
                    var values = new TesterViewModel
                    {
                        Id = report.Id,
                        userName = issue?.userName,
                        appName = app,
                        description = issue.Description,
                        date = issue?.DatePicker,
                        created = issue?.CreatedDate ?? DateTime.MinValue,
                        status = issue?.TesterStatus,
                        Comment = report.Comment,

                    };  
                        
                        if(values.status == "Not Solved")
                        {
                            var notSolvedDev = dbContext.Tests.FirstOrDefault(s => s.Id == values.Id);

                            if(notSolvedDev != null)
                            {
                                dbContext.Tests.Remove(notSolvedDev);
                                await dbContext.SaveChangesAsync();
                            }
                        }

                        TesterList.Add(values);
                    
                    }
           
                }
            }
                 return View(TesterList);
        }


       [HttpGet]
        public async Task<IActionResult> TestersAction(int id)
        {

            var report =  await dbContext.Tests.FindAsync(id);
            if (report == null)
            {
                return NotFound(id);
            }
            var issue = dbContext.UserReports.FirstOrDefault(s => s.UserReportId == report.UserReportID);
            var app = dbContext.Applications.FirstOrDefault(s => s.AppId == issue.ApplicationID)?.AppName;

            var details = new TesterViewModel
            {
                Id = report.Id,
                IssueCreated = issue,
                Comment = report.Comment,
                appName = app,
            };
               return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> TheIssueNotSolved(int id)
        {
            var issue = await dbContext.Tests.FindAsync(id);
           if(issue == null)
            {
                return NotFound();
            }

            var issueCreated = dbContext.UserReports.FirstOrDefault( s => s.UserReportId == issue.UserReportID);
            var appName = dbContext.Applications.FirstOrDefault( s => s.AppId == issueCreated.ApplicationID)?.AppName;

        
            var details = new TesterViewModel
            {

                Id = issue.Id,
                IssueCreated = issueCreated,
                Comment = issue.Comment,
                appName = appName,

            };
            var userName = dbContext.Developers.FirstOrDefault(s => s.UserReportID == issue.UserReportID)?.DeveloperName;
            var email = $"{userName}@mrc.gm";
            var subject = $" Your assigned Issue Created by {issueCreated.userName} on The {details.appName} was not Solved, You may be reassign to work on it again.";
            mailService.SendMailToDev(userName, email, subject);
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> TheIssueNotSolved(int id,TesterViewModel details)
        { 

            var issue = await dbContext.Tests.FindAsync(id);
            var theissue = dbContext.UserReports.FirstOrDefault(s => s.UserReportId == issue.UserReportID);
            var appName =  dbContext.Applications.FirstOrDefault( s => s.AppId == theissue.ApplicationID)?.AppName;
            var devName = dbContext.Developers.FirstOrDefault(s => s.UserReportID == theissue.UserReportId)?.DeveloperName;

            theissue.TesterStatus = "Seen";
            theissue.Status = "Not Solved";
            theissue.DevStatus = "Not Solved";
            theissue.TesterStatus = "Not Solved";
            theissue.AdminStatus = "Not Solved";
            dbContext.Update(theissue);
            await dbContext.SaveChangesAsync();

            var Adminemail = "hcham@mrc.gm";
            var Adminsubject = $"The Issue created by {theissue.userName} on The {appName} was not solved by {devName}, Reassign the Issue either to the same developer or a new one.";
            mailService.SendFirstMailToAdmin(Adminemail, Adminsubject);

            var values = new CommentByTester
            {
                UserReportID = issue.UserReportID,
                testerComment = details.testersComment,

            };

            await dbContext.AddAsync(values);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("TestersList", "Tracking");


        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> IssueSolved(int id)
        {

            var issue = await dbContext.Tests.FindAsync(id);
            var report = dbContext.UserReports.FirstOrDefault(s => s.UserReportId == issue.UserReportID);
            report.AdminStatus = "Solved";
            report.DevStatus = "Solved";
            report.TesterStatus = "Done";
            report.Status = "Solved";
            dbContext.Update(report);
            await dbContext.SaveChangesAsync();

            var userName = report?.userName;

            var appName = dbContext.Applications.FirstOrDefault(s => s.AppId == report.ApplicationID)?.AppName;
            var email = $"{userName}@mrc.gm";
            var subject = $"Your Issue has been solved.You can proceed with your request on The {appName}";
            mailService.SendFinalMail(userName, email, subject);

        
            var Adminemail = "hcham@mrc.gm";
            var AdminSubject = $"The Issue Created by {userName} on The {appName} Is Solved";
            mailService.SendFinalMailToAdmin( Adminemail, AdminSubject);

            return RedirectToAction("TestersList","Tracking");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Assign(int id)
        {
           var report = await dbContext.UserReports.FindAsync(id);
           
           if( report == null)
            {
                return NotFound();
            }
            var assignee = await dbContext.Assignees.ToListAsync();
            var status = await dbContext.Statuses.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();

            var model = new GetAssignedViewModels
            {
                UserReportID = id,       
                Status = status,
                Severity = severity

            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Assign(int id,GetAssignedViewModels viewModel)
        {
                var report = await dbContext.UserReports.FindAsync(id);
                 var appName =   dbContext.Applications.FirstOrDefault( s => s.AppId == report.ApplicationID)?.AppName;

                report.Status = "To be Solved";
                report.AdminStatus = "Assigned";
                report.DevStatus = "New";
                dbContext.Update(report);
                await dbContext.SaveChangesAsync();
           

            var issue = new Developer
                {

                    UserReportID = id,
                    DeveloperName = viewModel.DeveloperName,
                    SeverityID = viewModel.SeverityID,
                    Comment = viewModel.Comment,

                };

                await dbContext.Developers.AddAsync(issue);
                await dbContext.SaveChangesAsync();
                var userName =  issue.DeveloperName;
                var email = $"{userName}@mrc.gm";
                var subject = $"You have been assigned to work on an Issue Reported by {report.userName} on The {appName}";
                mailService.SendMailToDev(userName, email, subject);
                return RedirectToAction("AllReports", "Tracking");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeveloperList()
        {
            
            var userName = User.Identity.Name.Split("\\")[1];
            ViewBag.DeveloperName = userName;

            var developer = await dbContext.Developers
           .Where(d => d.DeveloperName == userName).ToListAsync();

            

            var developersList = new List<DeveloperListViewModel>();
            var AppName = await dbContext.Applications.ToListAsync();

            

            foreach (var report in developer)
            {
          

                var userReport = dbContext.UserReports.FirstOrDefault(x => x.UserReportId == report.UserReportID);
               
                
                var severity = dbContext.Severities.FirstOrDefault(x => x.Id == report.SeverityID)?.SeverityName;

                if (userReport != null)
                {

                    var user = dbContext.UserReports.FirstOrDefault(x => x.UserReportId == report.UserReportID)?.userName;
                    var app = dbContext.Applications.FirstOrDefault(x => x.AppId == userReport.ApplicationID)?.AppName;

                    if (app != null)
                    {
                        var aDeveloper = new DeveloperListViewModel
                        {
                            Id = report.Id,
                            User = user,
                            App = app,
                            SeverityLevel = severity,
                            Date = userReport?.DatePicker,
                            DevStatus = userReport?.DevStatus,
                           
                        };

                        
                        if(aDeveloper.DevStatus == "Not Solved")
                        {
                            var notSolvedDev = dbContext.Developers.FirstOrDefault( s => s.Id == aDeveloper.Id);
                            if(notSolvedDev != null)
                            {
                                dbContext.Developers.Remove(notSolvedDev);
                                await dbContext.SaveChangesAsync();
                            }
                        }
                        developersList.Add(aDeveloper);
                        
                    }
                }

            }
            

            return View(developersList);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DetailsForDev(int id)
        {

            var reports = await dbContext.Developers.FindAsync(id);
            var UserReports = await dbContext.UserReports.FirstOrDefaultAsync(s => s.UserReportId == reports.UserReportID);
            var severityName =  dbContext.Severities.FirstOrDefault(s => s.Id == reports.SeverityID)?.SeverityName;
            var appName = dbContext.Applications.FirstOrDefault(s => s.AppId == UserReports.ApplicationID)?.AppName;

            UserReports.Status = "Solving";
            UserReports.DevStatus = "Seen";
            dbContext.Update(UserReports);
            await dbContext.SaveChangesAsync();


            var values = new DetailsForDevViewModel
            {

                 reportDetails = reports,
                 UserReports = UserReports,
                 severity = severityName,
                 Application = appName
                 
            };

            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> DetailsForDev(int id, DetailsForDevViewModel details)
        {
            var reports = await dbContext.Developers.FindAsync(id);
            var UserReports = await dbContext.UserReports.FirstOrDefaultAsync(s => s.UserReportId == reports.UserReportID);
            var appName = dbContext.Applications?.FirstOrDefault(s => s.AppId == UserReports.ApplicationID)?.AppName;

            // update status 
            UserReports.Status = "To be Tested";
            UserReports.AdminStatus = "Awaiting Test";
            UserReports.DevStatus = "Awaiting Test";
            dbContext.Update(UserReports);
            await dbContext.SaveChangesAsync();

            var Adminemail = "hcham@mrc.gm";
            var Adminsubject = $"{reports.DeveloperName} has worked on The {appName}.The Issue Created by {UserReports.userName} is awaiting Test.";

            mailService.SendTestMailToAdmin(Adminemail, Adminsubject);

            if (reports is null)
            {
                return NotFound();
            }
            var values = new CommentByDev
            {
                UserReportID = reports.UserReportID,
                devComment = details.devComment,
            };
               await dbContext.AddAsync(values);
                await dbContext.SaveChangesAsync();

            return RedirectToAction("DeveloperList","Tracking");   
        }



        [HttpGet]
        public IActionResult EditReport(int id)
        {
            var model = dbContext.UserReports.Find(id);


            if (model == null)
            {
                return NotFound();

            }
            var app = dbContext.Applications.ToList();
            ViewBag.Applications = new SelectList(app, "Id", "AppName", model.ApplicationID);

            return View(model);  
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult> Solved()
        {
           

            var assignees = await dbContext.Assignees.ToListAsync();
            var severity = await dbContext.Severities.ToListAsync();
            var app = await dbContext.Applications.ToListAsync();

            var view = new Solved
            {
                Assignees = assignees,
                Severities = severity,
                Applications = app
            };

            return View(view);
        }
        
        [HttpPost]
        public async Task<ActionResult> solved(int id,Solved viewModel)
        {
            var issue = await dbContext.UserReports.FindAsync(id);

            var report = dbContext.UserReports.FirstOrDefault(s => s.UserReportId == issue.UserReportId);

            issue.AdminStatus = "Done";
            dbContext.Update(issue);
            await dbContext.SaveChangesAsync();

            var view = new Solved
            {
               
                IssueNumber = viewModel.IssueNumber,
                IssuesID = viewModel.IssuesID,
                DatePicker = viewModel.DatePicker,
                AssigneeID = viewModel.AssigneeID,
                SeverityID = viewModel.SeverityID,

            };

            await dbContext.Solveds.AddAsync(view);
            await dbContext.SaveChangesAsync();

            TempData["AddSolved"] = "Solved Issue Succesfully Added";

            return RedirectToAction("SolvedList", "Tracking");
        }

        [HttpGet]
        [Authorize]
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
                var app = dbContext.Applications.FirstOrDefault(a => a.AppId == issue.IssuesID)?.AppName;


                var model = new SolvedViewModel
                {

                    IssueNumber = issue.IssueNumber,
                    IssuesID = app,
                    AssigneeID = assignee,
                    SeverityID = severity,
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public ActionResult Dashboard()
        {

            var issues = dbContext.Issues.ToList();

            // Group data by status and count the number of issues for each status
            var status = issues.GroupBy(i => i.StatusID)
                                    .Select(g => new DashboardViewModel { StatusID = g.Key, IssueCount = g.Count() });

            string issueSent = TempData["IssueSent"] as string;
            ViewBag.IssueSent = issueSent;

            return View(status);
        }

    }
}
            
        



      
       


    

