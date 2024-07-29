using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class DetailsForDevViewModel
    {
        [Key]
        public int DevDetailsId { get; set; }
        public string UserName { get; set; }
        public string Application{ get; set; }

        public string  Description { get; set; }

        public string Date { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string severity { get; set; }

        public string comment { get; set; }

        public string devComment { get; set; }

        public Developer reportDetails { get; set; }
        public UserReports UserReports { get; set; }

     
    }
}
