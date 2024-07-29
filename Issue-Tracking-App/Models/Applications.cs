using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class Applications
    {
        [Key]
        public int AppId{ get; set; }

        [Required(ErrorMessage= "Select Application.")]
        public string AppName { get; set; }

    }
}

