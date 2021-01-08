using Dapper;
using MISA.ApplicationCore.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class CustomerContext
    {
        #region Method
        /// <summary>
        /// Get all data of customer
        /// </summary>
        /// <returns>List customer</returns>
        /// createdBy: vtminh (7/1/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            //Connect to db
            var connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=MISACukCuk_MF651_VTMINH;Port=3306;Password=12345678;Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Create commandText
            var customers = dbConnection.Query<Customer>("SELECT * FROM Customer", commandType: CommandType.Text);
            //Return data
            return customers;
        }

        //Get customer by id
        public Customer GetCustomerById(Guid id)
        {
            //Connect to db
            var connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=MISACukCuk_MF651_VTMINH;Port=3306;Password=12345678;Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Create commandText
            var customers = dbConnection.QueryFirstOrDefault<Customer>("SELECT * FROM Customer WHERE CustomerId = '" + id + "'", commandType: CommandType.Text);
            //Return data
            return customers;
        }

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="customer">customer object</param>
        /// <returns>Return number of record have been inserted</returns>
        /// createdBy: vtminh(7/1/2021)
        public int InsertCustomer(Customer customer)
        {
            //Connect to db
            var connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=MISACukCuk_MF651_VTMINH;Port=3306;Password=12345678;Character Set=utf8";
            var dbConnection = new MySqlConnection(connectionString);
            //Mapping type of data
            var properties = customer.GetType().GetProperties();
            var paremeters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var propertyName = prop.Name;
                var propertyVal = prop.GetValue(customer);
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
            //Excute commandText
            var rowAffects = dbConnection.Execute("Proc_InsertCustomer", paremeters, commandType: CommandType.StoredProcedure);
            //Return number of record have been inserted
            return rowAffects;
        }

        /// <summary>
        /// Get customer by customerCode
        /// </summary>
        /// <param name="customerCode">CustomerCode</param>
        /// <returns>First object of customer</returns>
        /// createdBy: vtminh (7/1/2021)
        public Customer GetCustomerByCode(string customerCode)
        {
            //Connect to db
            var connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=MISACukCuk_MF651_VTMINH;Port=3306;Password=12345678;Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Create commandText
            var res = dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //return data
            return res;
        }

        //Modify infor of customer

        //Delete customer by id
        #endregion
    }
}
