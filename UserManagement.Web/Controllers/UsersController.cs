using System;
using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users/")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    private UserListViewModel createUserListViewModel(IEnumerable<User> users){
        var userListItemViewModel = users.Select(p => new UserListItemViewModel{
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive
        });

        var userListViewModel = new UserListViewModel{
            Items = userListItemViewModel.ToList()
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
}
