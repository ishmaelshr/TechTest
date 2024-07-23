using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService{

    private readonly String ACTION_DELETE = "Delete", ACTION_CREATE = "Add", ACTION_UPDATE = "Edit";
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<User> FilterByActive(bool isActive) => _dataAccess.GetAll<User>().Where<User>(u => u.IsActive == isActive);

    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

    public User Get(long id) => _dataAccess.Get<User>(id) ?? throw new NullReferenceException(); 

    public void Delete(long id) { 
        User user = _dataAccess.Get<User>(id) ?? throw new NullReferenceException();
        _dataAccess.Delete<User>(Get(id));
        log(0, ACTION_DELETE, createLogDetails(ACTION_DELETE, user));
    }

    public void Create(string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive){
        User createUser = new User { 
        Forename = forename, 
        Surname = surname, 
        Email = email, 
        DateOfBirth = dateOfBirth,
        IsActive = isActive 
        };
        User newUser = _dataAccess.Create<User>(createUser);
        log(newUser.Id, ACTION_CREATE, createLogDetails(ACTION_CREATE, newUser));
    }

    public void Update(long id, string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive){
        User user = new User { 
        Id = id,
        Forename = forename, 
        Surname = surname, 
        Email = email, 
        DateOfBirth = dateOfBirth,
        IsActive = isActive 
        };
        _dataAccess.Update<User>(user);
        log(user.Id, ACTION_UPDATE, createLogDetails(ACTION_UPDATE, user));
    }

    private void log(long userId, string action, string details){
        Log log =new Log{
            UserId = userId,
            Action = action,
            TimeStamp = DateTime.UtcNow,
            Details = details
        };
        _dataAccess.Create<Log>(log);
    }

    public string createLogDetails(string action, User user){
        StringBuilder message = new StringBuilder();
        message.Append("The action {" + action + "} was performed on the user with values: ");
        foreach (var property in user.GetType().GetProperties()){
            message.Append($"{property.Name} : '{property.GetValue(user)}', ");
        }
        return message.ToString();
    }
}
