using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface of list customer for repository
    /// </summary>
    /// createdBy: vtminh (7/1/2021)
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Get customer by customerCode
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>Customer mapping with customerCode</returns>
        /// createdBy: vtminh (7/1/2021)
        Customer GetCustomerByCode(string customerCode);
    }
}
