﻿using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class Solved
    {
        [Key]
        public int IssueNumber { get; set; }

        public int IssuesID { get; set; }

        public int StatusID { get; set; }

        public  string DatePicker { get; set; }

        
        public int EstimateTime { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int AssigneeID { get; set; }


        public int SeverityID { get; set; }

       public String Comment { get; set; }


        public IEnumerable<Applications> Applications { get; set; }
        public IEnumerable<Assignee> Assignees { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Severity> Severities { get; set; }

    }
}
