using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Logs;
namespace UserManagement.WebMS.Controllers;

[Route("logs")]
public class LogsController : Controller
{
    private readonly ILogService _logService ;
    public LogsController(ILogService logService) => _logService = logService;

    private LogListViewModel createLogListViewModel(IEnumerable<Log> logs){
        var logListItemViewModels = logs.Select(l => new LogListItemViewModel(l));
        var logListViewModel = new LogListViewModel{
            Logs = logListItemViewModels.ToList()
        };
        return logListViewModel;
    }

    [HttpGet]
    [Route ("list")]
    public ViewResult List(){
        return View(createLogListViewModel(_logService.GetAll()));
    }

    [HttpGet]
    [Route ("view")]
    public ViewResult View(long id){
        return View(new LogViewModel(_logService.Get(id)));
    }
}
