using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class CommentByTester
    {

        [Key]
        public int testerCommementId { get; set; }

        public int UserReportID { get; set; }

        public string testerComment { get; set; }

    }
}
