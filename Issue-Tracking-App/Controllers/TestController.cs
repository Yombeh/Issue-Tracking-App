using Issue_Tracking_App.Data;
using Issue_Tracking_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Issue_Tracking_App.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TestController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
    }
}
            

  
            
               
    
    

