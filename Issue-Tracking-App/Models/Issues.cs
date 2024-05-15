using Issue_Tracking_App.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Issue_Tracking_App.Models
{
    public class Issues
    {

        [Key]
        public int IssueNumber { get; set; }
        
        public string Summary { get; set; }

        public int StatusID { get; set; }

        [DataType(DataType.Time)]
        public int EstimateTime { get; set; }

        public string DateTimePicker { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int AssigneeID { get; set; }
      
        public int SeverityID { get; set; }

    }
   
    }


