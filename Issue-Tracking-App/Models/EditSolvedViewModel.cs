using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class EditSolvedViewModel
    {
        [Key]
        public int IssueNumber { get; set; }

        public int IssuesID { get; set; }

        public int StatusID { get; set; }


        public int EstimateTime { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;


        public int AssigneeID { get; set; }


        public int SeverityID { get; set; }

        public String Comment { get; set; }


        public IEnumerable<Issues> Issues { get; set; }
        public IEnumerable<Assignee> Assignees { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Severity> Severities { get; set; }

    }
}
