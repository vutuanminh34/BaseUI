using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Enums.MISACode.Success };
        }
        #endregion
        public virtual ServiceResult Add(TEntity entity)
        {
            //validate
            entity.EntityState = Enums.EntityState.Insert;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        public ServiceResult Delete(Guid Id)
        {
            _serviceResult.Data = _baseRepository.Delete(Id);
            return _serviceResult;
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

        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Base function used to validate data 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool Validate(TEntity entity)
        {
            var isValidate = true;
            var listMessenger = new List<string>();
            //Get all properties
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayNameAttributes.Length > 0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;
                }
                
                //Check attribute need to validate
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check required
                    if (propertyValue == null || propertyValue.ToString().Trim() == "")
                    {
                        isValidate = false;
                        listMessenger.Add(string.Format(Properties.Resources.Msg_Required, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }

                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check duplicate
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                         listMessenger.Add(string.Format(Properties.Resources.Msg_Duplicate, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    //Get length of object
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxLength as MaxLength).Value;
                    var msg = (attributeMaxLength as MaxLength).ErrorMsg;
                    if (propertyValue != null)
                    {
                        if (propertyValue.ToString().Trim().Length > length)
                        {
                            isValidate = false;
                            listMessenger.Add(msg);
                            _serviceResult.MISACode = Enums.MISACode.NotValid;
                            _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                        }
                    }
                }
            }
            _serviceResult.Data = listMessenger;
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }
            return isValidate;
        }

        /// <summary>
        /// Function used to check data custom
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
    }
}
