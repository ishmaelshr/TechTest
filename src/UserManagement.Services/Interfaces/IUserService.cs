using System;
using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService {
    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> GetAll();
    User Get(long id);
    void Delete(long id);
    void Create(string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive);
    void Update(long id, string forename, string surname, string email, DateOnly? dateOfBirth, bool isActive);
}
