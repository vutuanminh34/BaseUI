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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public List<Employee> FilterEmployee(string inputValue, Guid? departmentId, Guid? positionId)
        {
            //Get value input
            var inputs = inputValue != null ? inputValue : string.Empty;
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", inputs);
            parameters.Add("@FullName", inputs);
            parameters.Add("@PhoneNumber", inputs);
            parameters.Add("@DepartmentId", departmentId.ToString());
            parameters.Add("@PositionId", positionId.ToString());
            var employees = _dbConnection.Query<Employee>("Proc_FilterEmployee", parameters, commandType: CommandType.StoredProcedure).ToList();
            return employees;
        }
    }
}
