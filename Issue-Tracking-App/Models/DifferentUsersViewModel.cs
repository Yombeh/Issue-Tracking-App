
using Microsoft.AspNetCore.Authorization;

namespace Issue_Tracking_App.Models
{

    public class DifferentUsersViewModel //: IAuthorizationRequirement
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string role { get; set; }

        public string values { get; set; }


    }
}

