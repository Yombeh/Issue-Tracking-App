using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class Test
    {

        [Key]
        public int Id { get; set; }

        public int  UserReportID { get; set; }
        [Required]
        public string Tester { get; set; }
        [Required]
        public string Comment { get; set; }

        public IEnumerable<UserReports> UserReports { get; set; }

    }
}
