using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntityById(Guid Id);
        ServiceResult Add(TEntity entity);
        ServiceResult Update(TEntity entity);
        ServiceResult Delete(Guid Id);
    }
}
