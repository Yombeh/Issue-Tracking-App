using Issue_Tracking_App.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class IssueViewModel
    {
        
        public int IssueId { get; set; }

        [Required]
        public string Summary { get; set; }
        public string StatusName{ get; set; }
        public int EstimatedTime { get; set; }
        public string DateTimePicker { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public string AssigneeName { get; set; }  
        public string SeverityName { get; set; }

        public string Comment { get; set; }
        
        public IEnumerable<Assignee> Assignees { get; set; }

    }
}
