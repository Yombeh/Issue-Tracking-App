namespace Issue_Tracking_App.Models
{
    public class DashboardViewModel
    {
        public int StatusID { get; set; }
        public int IssueCount { get; set; }

    }

    public class StatusViewModel
    {
        public List<string> StatusID { get; set; }
        public List<int> StatusCount { get; set; }
    }

    public class AssigneeViewModel
    {
        public List<string> AssigneeID { get; set; }
        public List<int> AssigneeCount { get; set; }
    }
    public class SeverityViewModel
    {
        public List<String> SeverityID { get; set; }
        public List<int> SeverityCount { get; set; }
    }

    public class HomePage
    {

        public StatusViewModel status { get; set; }
        public AssigneeViewModel assignee { get; set; }
        public SeverityViewModel severity { get; set; }

    }
}
