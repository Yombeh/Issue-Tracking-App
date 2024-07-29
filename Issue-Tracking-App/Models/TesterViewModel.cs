using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class TesterViewModel
    {
        [Key]
        public int Id { get; set; }

        public  string userName { get; set; }
    

        public string appName { get; set; }

        public string description { get; set; }

        public DateTime created {  get; set; }

        public string date {  get; set; }

        public string status { get; set; }
        [Required (ErrorMessage ="Select the Tester.")]
        public string Tester { get; set; }
        [Required (ErrorMessage = "Add a Comment")]
        public string Comment { get; set; }

        public string testersComment { get; set; }

        public string devComment { get; set; }  


       
        public UserReports IssueCreated { get; set; }
        

    }
}
