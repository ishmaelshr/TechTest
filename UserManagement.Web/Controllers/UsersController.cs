using System;
using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Logs;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users/")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogService _logService ;
    public UsersController(IUserService userService, ILogService logService) {
        _userService = userService;
        _logService = logService;
    }


    private UserListViewModel createUserListViewModel(IEnumerable<User> users){
        var userListItemViewModels = users.Select(u => new UserListItemViewModel(u));
        var userListViewModel = new UserListViewModel{
            User = userListItemViewModels.ToList()
        };
        return userListViewModel;
    }

    [HttpGet]
    [Route ("list")]
    public ViewResult List(){
        return View(createUserListViewModel(_userService.GetAll()));
    }
    
    [HttpGet]
    [Route ("list/filter/isActive")]
    [ActionName("IsActive")]
    public ViewResult List(string value){
         bool isActive = Boolean.Parse(value);
        return View("List", createUserListViewModel(_userService.FilterByActive(isActive)));
    }

    [HttpGet]
    [Route ("/add")]
    public ViewResult Add(){
        return View();
    }

    [HttpPost]
    [Route ("/add/user")]
    public ActionResult AddUser(string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive){
        if(ModelState.IsValid == false){
            return View("Add");
        }
        _userService.Create(
            forename,
            surname,
            email,
            dateOfBirth,
            isActive
            );
        
        return RedirectToAction("List");
    }

    [HttpGet]
    [Route ("/delete")]
    public ViewResult Delete(long id){
        return View(new UserViewModel(_userService.Get(id)));
    }

    [HttpPost]
    [Route ("/delete/user")]
    public ActionResult DeleteUser(long id){
        _userService.Delete(id);
        ViewBag.deleteMessage = "User Added";
        return RedirectToAction("List");
    }

    [HttpGet]
    [Route ("/edit")]
    public ViewResult Edit(long id){
        return View(new UserViewModel(_userService.Get(id)));
    }

    [HttpPost]
    [Route ("/edit/user")]
    public ActionResult EditUser(long id, string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive){
        if(ModelState.IsValid == false){
            return View("Edit", new UserViewModel(_userService.Get(id)));
        }
        _userService.Update(
            id,
            forename,
            surname,
            email,
            dateOfBirth,
            isActive
            );
        return RedirectToAction("Edit", new UserViewModel(_userService.Get(id)));
    }

    private LogListViewModel createLogListViewModel(IEnumerable<Log> logs){
        var logListItemViewModels = logs.Select(l => new LogListItemViewModel(l));
        var logListViewModel = new LogListViewModel{
            Logs = logListItemViewModels.ToList()
        };
        return logListViewModel;
    }

    [HttpGet]
    [Route ("/view")]
    public ViewResult View(long id){
        return View(new UserViewModel(_userService.Get(id), createLogListViewModel(_logService.FilterByUserId(id))));
    }
}
