using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;

        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion
        public virtual int Add(TEntity entity)
        {
            //validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                var rowAffects = _baseRepository.Add(entity);
                return rowAffects;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(Guid Id)
        {
            var res = _baseRepository.Delete(Id);
            return res;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        public TEntity GetEntityById(Guid Id)
        {
            var entity = _baseRepository.GetEntityById(Id);
            return entity;
        }

        public int Update(TEntity entity)
        {
            var rowAffects = _baseRepository.Update(entity);
            return rowAffects;
        }

        private bool Validate(TEntity entity)
        {
            var isValidate = true;
            //Get all properties
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                //Check attribute need to validate
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check required
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        isValidate = false;
                    }
                }

                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check duplicate
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(propertyName, property.GetValue(entity));
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                    }
                } 
            }
            return isValidate;
        }
    }
}
