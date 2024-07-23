using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using UserManagement.Models;

namespace UserManagement.Web.Models.Logs;

public class LogViewModel{

    public long Id { get; set; }
    public long UserId {get; set; }
    public string Action {get; set; } = default!;
    public DateTime TimeStamp {get; set; } = default!;    
    public string Details {get; set; } = default!;
    
    public LogViewModel(){}

    public LogViewModel(Log log){
            Id = log.Id;
            UserId = log.UserId;
            Action = log.Action;
            TimeStamp = log.TimeStamp;
            Details = log.Details;
    }
}
