using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public int AddCustomer(Customer customer)
        {
            //Mapping type of data
            var parameters = MappingDbType(customer);
            //Excute commandText
            var rowAffects = _dbConnection.Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            //Return number of record have been inserted
            return rowAffects;
        }

        public int DeleteCustomer(Guid customerId)
        {
            var res = _dbConnection.Execute("Proc_DeleteCustomerById", new { CustomerId = customerId.ToString() }, commandType: CommandType.StoredProcedure);
            return res;
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            //Create commandText
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //return data
            return res;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            //Create commandText
            var customers = _dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", new { CustomerId = customerId.ToString() }, commandType: CommandType.StoredProcedure);
            //Return data
            return customers;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Create commandText
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //Return data
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            //Mapping type of data
            var parameters = MappingDbType(customer);
            //Excute commandText
            var rowAffects = _dbConnection.Execute("Proc_UpdateCustomer", parameters, commandType: CommandType.StoredProcedure);
            //Return number of record have been inserted
            return rowAffects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType<TEntity>(TEntity entity)
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
