using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
     public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetEmployees();

        TEntity GetEmployeeById(Guid employeeId);

        TEntity GetEmployeeByCode(string employeeCode);

        int AddEmployee(TEntity employee);

        int UpdateEmployee(TEntity employee);

        int DeleteEmployee(Guid employeeId);
    }
}
