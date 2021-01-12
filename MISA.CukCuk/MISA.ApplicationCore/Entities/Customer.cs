using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// createdBy: vtminh (6/1/2021)
    public class Customer : BaseEntity
    {
        #region Declare
        #endregion

        #region Constructor
        public Customer()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [Required]
        [DisplayName("mã khách hàng")]
        [MaxLength(20,"Mã khách hàng không vượt quá 20 ký tự!")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [DisplayName("họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Số tiền còn nợ
        /// </summary>
        public double? DebitAmount { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính(1-Nam, 0-Nữ, 2-Khác)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [CheckDuplicate]
        [DisplayName("số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên công ty làm việc
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế của công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string  Address { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }   
        #endregion

        #region Method

        #endregion
    }
}
