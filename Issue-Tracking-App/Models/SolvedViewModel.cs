using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class SolvedViewModel
    {
        [Key]
        public int IssueNumber { get; set; }

        public string IssuesID { get; set; }

        public string StatusID { get; set; }

        public string DatePicker { get; set; }


        public int EstimateTime { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;


        public string AssigneeID { get; set; }


        public string SeverityID { get; set; }

        public String Comment { get; set; }
    }
}
