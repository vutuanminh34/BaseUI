using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        #region Method
        public int Add(TEntity entity)
        {
            //Mapping type of data
            var parameters = MappingDbType(entity);
            //Excute commandText
            var rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            //Return number of record have been inserted
            return rowAffects;
        }

        public int Delete(Guid Id)
        {
            var res = _dbConnection.Execute("Proc_DeleteCustomerById", new { CustomerId = Id.ToString() }, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            //Create commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //Return data
            return entities;
        }

        public TEntity GetEntityById(Guid Id)
        {
            //Create commandText
            var customers = _dbConnection.QueryFirstOrDefault<TEntity>($"Proc_Get{_tableName}ById", new { CustomerId = Id.ToString() }, commandType: CommandType.StoredProcedure);
            //Return data
            return customers;
        }

        public int Update(TEntity entity)
        {
            //Mapping type of data
            var parameters = MappingDbType(entity);
            //Excute commandText
            var rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            //Return number of record have been inserted
            return rowAffects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var propertyName = prop.Name;
                var propertyValue = prop.GetValue(entity);
                var propertyType = prop.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue == true ? 1 : 0);
                    parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return parameters;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.Insert)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            else if (entity.EntityState == EntityState.Update)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            else
                return null;
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }
        #endregion
    }
}
