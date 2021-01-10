using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName;
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
            var paremeters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var propertyName = prop.Name;
                var propertyVal = prop.GetValue(entity);
                var propertyType = prop.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    paremeters.Add($"@{propertyName}", propertyVal, DbType.String);
                }
                else
                {
                    paremeters.Add($"@{propertyName}", propertyVal);
                }
            }
            return paremeters;
        }
        #endregion
    }
}
