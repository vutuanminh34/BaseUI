using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmloyeeRepository _emloyeeRepository;
        #region Constructor
        public EmployeeService(IEmloyeeRepository emloyeeRepository)
        {
            _emloyeeRepository = emloyeeRepository;
        }
        #endregion

        #region Method
        public ServiceResult AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var res = _emloyeeRepository.GetEmployees();
            return res;
        }

        public ServiceResult UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
