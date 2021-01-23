using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List entities</returns>
        /// createdBy : vtminh(01/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Get enitty by entityId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Entity mapping with id</returns>
        /// createdBy: vtminh (01/2021)
        TEntity GetEntityById(Guid Id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        ServiceResult Update(TEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        ServiceResult Delete(Guid Id);
    }
}
