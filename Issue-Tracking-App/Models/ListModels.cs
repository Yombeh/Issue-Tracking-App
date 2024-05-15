
using Issue_Tracking_App.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Issue_Tracking_App.Models;

public class ListModels
{

    [Key]
    public int IssueNumber { get; set; }

    public string Summary { get; set; }


    public int StatusID { get; set; }


    public int EstimateTime { get; set; }

    public string DateTimePicker {  get; set; }


    public DateTime Created { get; set; } = DateTime.Now;


    public int AssigneeID { get; set; }


    public int SeverityID { get; set; }

    public IEnumerable<Assignee> Assignees { get; set; }
    public IEnumerable<Status> Statuses { get; set; }
    public IEnumerable<Severity> Severities { get; set; }

}
