using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class EditviewModel
    {
        public int IssueId { get; set; }
        [Required]
        public string Summary { get; set; }
        public int StatusID { get; set; }

        public string DateTimePicker { get; set; }
        public int EstimatedTime { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public int AssigneeID { get; set; }
        public int SeverityID { get; set; }

        public IEnumerable<Assignee> Assignees { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Severity> Severities { get; set; }

    }
}
