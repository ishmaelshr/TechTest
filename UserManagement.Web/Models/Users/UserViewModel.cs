using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Models;

namespace UserManagement.Web.Models.Users;

public class UserViewModel{
    public long Id { get; set; }
    [Required]
    [StringLength(20)]
    public string? Forename { get; set; }
    [Required]
    [StringLength(20)]
    public string? Surname { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public DateOnly? DateOfBirth { get; set; } = default!;
    [Required]
    public bool IsActive { get; set; }

    public UserViewModel(User user){
            Id = user.Id;
            Forename = user.Forename;
            Surname = user.Surname;
            Email = user.Email;
            DateOfBirth = user.DateOfBirth;
            IsActive = user.IsActive;
    }
}
