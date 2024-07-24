using System.Collections.Generic;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

public interface ILogService {
    IEnumerable<Log> FilterByUserId(long id);
    IEnumerable<Log> GetAll();
    Log Get(long id);
}