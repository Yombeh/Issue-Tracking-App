using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Issue_Tracking_App.Models
{
    public class Assignee
    {

        [Key]
        public int Id { get; set; }
        public string AssigneeName { get; set; }

    }
}



