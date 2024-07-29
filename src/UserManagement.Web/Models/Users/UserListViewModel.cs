using System;
using UserManagement.Models;

namespace UserManagement.Web.Models.Users;

public class UserListViewModel{
    public List<UserListItemViewModel> User { get; set; } = new();
}

public class UserListItemViewModel{
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; } = default!;
    public bool IsActive { get; set; }

    public UserListItemViewModel(User user){
            Id = user.Id;
            Forename = user.Forename;
            Surname = user.Surname;
            Email = user.Email;
            DateOfBirth = user.DateOfBirth;
            IsActive = user.IsActive;
    }
}
