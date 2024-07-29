using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class EditReportViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application is required.")]
        public int ApplicationID { get; set; }
        [Required()]
        [StringLength(200, ErrorMessage = "The Summary can not be longer than 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string DatePicker { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public IEnumerable<Applications> Applications { get; set; }

    }
}
