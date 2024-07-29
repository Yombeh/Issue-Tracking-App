using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class AssignTester
    {
        [Key]
        public int AssignedTesterId { get; set; }

        public string TesterName { get; set; }

        public int SeverityID { get; set; }

        public string Comment { get; set; }
         
        public string UserReportID { get; set; }


    }
}
