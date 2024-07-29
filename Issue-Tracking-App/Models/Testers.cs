
using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class Testers
    {
        [Key]
        public int TesterId { get; set; }
         public string testerName{ get; set; }
    }
}
