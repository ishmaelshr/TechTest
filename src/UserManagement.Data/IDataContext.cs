using System.Collections.Generic;
using System.Linq;
using UserManagement.Models;

namespace UserManagement.Data;

public interface IDataContext{

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    TEntity? Get<TEntity>(long id) where TEntity : class;
    TEntity Create<TEntity>(TEntity entity) where TEntity : class;

    void Update<TEntity>(TEntity entity) where TEntity : class;

    void Delete<TEntity>(TEntity entity) where TEntity : class;
}
