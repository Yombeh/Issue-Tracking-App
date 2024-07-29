using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class Developer
    {

        public int Id { get; set; }

        public int  UserReportID { get; set; }
        [Required (ErrorMessage = "Please select a Developer.")]
        public string DeveloperName { get; set; }

        
        public int StatusID { get; set; }

        [Required(ErrorMessage = "Please select the severity level")]
        public int SeverityID { get; set; }

        [Required(ErrorMessage = "Please select the severity level")]
        public string Comment { get; set; }


    } 
}
