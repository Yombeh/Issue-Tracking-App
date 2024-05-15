using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Issue_Tracking_App.Models
{

    public class Status
    {

        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }

    }

}
