using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface of list employee for repository
    /// </summary>
    /// createdBy: vtminh (8/1/2021)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Filter employee by multiple conditions
        /// </summary>
        /// <param name="inputValue">employeeCode, fullName, phoneNumber</param>
        /// <param name="departmentId"></param>
        /// <param name="positionId"></param>
        /// <returns>List employee</returns>
        /// createdBy: vtminh(18/1/2021)
        List<Employee> FilterEmployee(string inputValue, Guid? departmentId, Guid? positionId);

        /// <summary>
        /// Get max number only in employee code
        /// </summary>
        /// <returns>Only number in employee code</returns>
        /// createdBy: vtminh (21/1/2021)
        double GetMaxEmployeeCode();
    }
}
