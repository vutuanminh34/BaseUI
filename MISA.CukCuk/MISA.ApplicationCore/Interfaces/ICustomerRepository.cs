using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface of list customer
    /// </summary>
    /// createdBy: vtminh (7/1/2021)
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get all data of customer
        /// </summary>
        /// <returns>List customer</returns>
        /// createdBy: vtminh (7/1/2021)
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Get customer by customerId
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Customer mapping with customerId</returns>
        /// createdBy: vtminh (7/1/2021)
        Customer GetCustomerById(Guid customerId);

        /// <summary>
        /// Get customer by customerCode
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Customer mapping with customerCode</returns>
        /// createdBy: vtminh (7/1/2021)
        Customer GetCustomerByCode(string customerCode);

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="customer">customer object</param>
        /// <returns>Number of record have been inserted</returns>
        /// createdBy: vtminh(7/1/2021)
        int AddCustomer(Customer customer);

        /// <summary>
        /// Update customer by customerId
        /// </summary>
        /// <param name="customer">customer object</param>
        /// <returns>Infor of the customer has been updated</returns>
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete customer by customerId
        /// </summary>
        /// <param name="customerId">Id of the customer</param>
        /// <returns></returns>
        int DeleteCustomer(Guid customerId);
    }
}
