using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
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
        int Add(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        int Update(TEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        int Delete(Guid Id);

        /// <summary>
        /// Get entity by property
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// createdBy: vtminh (01/2021)
        TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
    }
}
