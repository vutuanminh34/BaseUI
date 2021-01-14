using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required]
        [DisplayName("mã nhân viên")]
        [MaxLength(20, "Mã nhân viên không vượt quá 20 ký tự!")]
        public string EmployeeCode { get; set; }

        [DisplayName("họ và tên")]
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [CheckDuplicate]
        public string IdentificationNumber { get; set; }
        public DateTime? IdentificationDate { get; set; }
        public string IdentificationLocation { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [CheckDuplicate]
        [DisplayName("số điện thoại")]
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
