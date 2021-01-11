using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface of the customer for service
    /// </summary>
    /// createdBy: vtminh (7/1/2021)
    public interface ICustomerService: IBaseService<Customer>
    {
        /// <summary>
        /// Get value of paging
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>list customer with paging</returns>
        ///  createdBy: vtminh (11/1/2021)
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);

        /// <summary>
        /// Get list customer by group customer id
        /// </summary>
        /// <param name="GroupId">GroupCustomerId</param>
        /// <returns>List customer</returns>
        ///  createdBy: vtminh (11/1/2021)
        IEnumerable<Customer> GetCustomerByGroup(Guid GroupId);
    }
}
