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

        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required]
        [DisplayName("họ và tên")]
        public string FullName { get; set; }
       
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [CheckDuplicate]
        [DisplayName("số chứng minh thư")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Ngày lập chứng minh thư
        /// </summary>
        public DateTime? IdentificationDate { get; set; }

        /// <summary>
        /// Nơi lập chứng minh thư
        /// </summary>
        public string IdentificationLocation { get; set; }

        /// <summary>
        /// Địa chỉ email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [CheckDuplicate]
        [DisplayName("số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mã vị trí công việc
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Tên vi trí công việc
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        
        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public double? BaseSalary { get; set; }

        /// <summary>
        /// Ngày thanh gia công ty
        /// </summary>
        public DateTime? JoiningDate { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int? WorkStatus { get; set; }
        #endregion  
    }
}
