using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models
{
    public class CommentByDev
    {
        [Key]
        public int devCommentId { get; set; }

        public int UserReportID { get; set; }

        public string devComment {  get; set; }

    

    }
}
