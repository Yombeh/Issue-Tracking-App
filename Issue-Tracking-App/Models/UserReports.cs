using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{

    public class UserReports
    {

        [Key]
        public int UserReportId { get; set; }

        public string userName { get; set; }

        [Required (ErrorMessage ="Application is required.")]

        public int  ApplicationID { get; set; }
        
        [Required()]
        [StringLength(200,ErrorMessage ="The Summary can not be longer than 200 characters.")]

        public string Description { get; set; }

        [Required(ErrorMessage ="Date is required.")]

        public string DatePicker{ get; set; }   

        public string Status { get; set; }

        public string AdminStatus { get; set; } = "New";

        public string DevStatus {  get; set; }

        public string TesterStatus { get; set; }

   

        public DateTime CreatedDate { get; set;} = DateTime.Now;

        public virtual ICollection<CommentByDev> CommentByDev { get; set; } 

    }

}
