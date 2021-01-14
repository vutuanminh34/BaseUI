using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class Employee : BaseEntity
    {
        #region Property
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? IdentificationDate { get; set; }
        public string IdentificationLocation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? PositionId { get; set; }
        public string PositionName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PersonalTaxCode { get; set; }
        public double? BaseSalary { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? WorkStatus { get; set; }
        #endregion  
    }
}
