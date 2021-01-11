using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetEntities();

        TEntity GetEntityById(Guid Id);

        int Add(TEntity entity);

        int Update(TEntity entity);

        int Delete(Guid Id);

        TEntity GetEntityByProperty(string propertyName, object propertyValue);
    }
}
