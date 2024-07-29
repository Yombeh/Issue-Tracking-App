using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class IssueListViewModel
    {

        [Key]
        public int Id { get; set; }

        public string userName { get; set; }

        [Required(ErrorMessage = "Application is required.")]
        public string ApplicationName { get; set; }
        [Required()]
        [StringLength(200, ErrorMessage = "The Summary can not be longer than 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string DatePicker { get; set; }

        public string Status { get; set; }

        public string AdminStatus { get; set; }

        public string devComment { get; set; }

        public string testerComment {  get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public  IEnumerable <CommentByDev> devComments { get; set; }
        public IEnumerable <CommentByTester> testerComments { get; set; }

    }
}
