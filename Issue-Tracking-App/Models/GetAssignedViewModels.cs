using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class GetAssignedViewModels
    {

        public int Id { get; set; }

        public int UserReportID {get; set;}
        [Required (ErrorMessage ="Please Select developer")]
        public string DeveloperName { get; set; }

        public int StatusID { get; set; }
        [Required (ErrorMessage ="Please select the severity")]
        public int SeverityID { get; set; }

        [Required(ErrorMessage = "Please select the severity level")]
        public string Comment { get; set; }

        public IEnumerable<UserReports> userReports { get; set; }
       
        public IEnumerable<Status> Status{ get; set; }
        public IEnumerable<Severity> Severity { get; set; }


    }
}

