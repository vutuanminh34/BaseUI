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
    public interface IEmloyeeRepository
    {
        /// <summary>
        /// Get all data of employee
        /// </summary>
        /// <returns>List employee</returns>
        /// createdBy: vtminh (8/1/2021)
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Get employee by employeeId
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>Employee mapping with employeeId</returns>
        /// createdBy: vtminh (7/1/2021)
        Employee GetEmployeeById(Guid employeeId);

        /// <summary>
        /// Get employee by employeeCode
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>Employee mapping with employeeCode</returns>
        /// createdBy: vtminh (7/1/2021)
        Employee GetEmployeeByCode(string employeeCode);

        /// <summary>
        /// Insert new employee
        /// </summary>
        /// <param name="employee">employee object</param>
        /// <returns>Number of record have been inserted</returns>
        /// createdBy: vtminh(7/1/2021)
        int AddEmployee(Employee employee);

        /// <summary>
        /// Update employee by employeeId
        /// </summary>
        /// <param name="employee">employee object</param>
        /// <returns>Infor of the employee has been updated</returns>
        int UpdateEmployee(Employee employee);

        /// <summary>
        /// Delete employee by employeeId
        /// </summary>
        /// <param name="employeeId">Id of the employee</param>
        /// <returns></returns>
        int DeleteEmployee(Guid employeeId);
    }
}
