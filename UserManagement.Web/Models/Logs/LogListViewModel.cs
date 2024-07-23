using System;
using UserManagement.Models;

namespace UserManagement.Web.Models.Logs;

public class LogListViewModel
{
    public List<LogListItemViewModel> Logs { get; set; } = new();
}

public class LogListItemViewModel {
    public long Id { get; set; }
    public long UserId {get; set; }
    public string Action {get; set; } = default!;
    public DateTime TimeStamp {get; set; } = default!;    
    public string Details {get; set; } = default!;

    public LogListItemViewModel(Log log){
            Id = log.Id;
            UserId = log.UserId;
            Action = log.Action;
            TimeStamp = log.TimeStamp;
            Details = log.Details;
    }
}
