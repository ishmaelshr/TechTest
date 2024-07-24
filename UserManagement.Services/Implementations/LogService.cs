
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class LogService : ILogService
{
    private readonly IDataContext _dataAccess;
    public LogService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<Log> FilterByUserId(long id) => _dataAccess.GetAll<Log>().Where<Log>(l => l.UserId == id); 
    public IEnumerable<Log> GetAll() => _dataAccess.GetAll<Log>();
    public Log Get(long id) => _dataAccess.Get<Log>(id) ?? throw new NullReferenceException(); 
}
