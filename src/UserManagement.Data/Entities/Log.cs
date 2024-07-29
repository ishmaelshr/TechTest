using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class Log
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long UserId {get; set; }
    public string Action {get; set; } = default!;
    public DateTime TimeStamp {get; set; } = default!;    
    public string Details {get; set; } = default!;
}
