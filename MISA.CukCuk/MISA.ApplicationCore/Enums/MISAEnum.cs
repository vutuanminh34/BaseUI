using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Enums
{
    /// <summary>
    /// MISACode used to validate
    /// </summary>
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 900,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// exception
        /// </summary>
        Exception = 500
    }

    /// <summary>
    /// State of object
    /// </summary>
    public enum EntityState
    {
        Insert = 1,
        Update = 2,
        Delete = 3
    }

    /// <summary>
    /// Value of gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Female,

        /// <summary>
        /// Nam
        /// </summary>
        Male,

        /// <summary>
        /// Chưa xác định
        /// </summary>
        Other,
    }

    /// <summary>
    /// Value of WordStatus
    /// </summary>
    public enum WorkStatus
    {
        /// <summary>
        /// Đã nghỉ việc
        /// </summary>
        Resign,

        /// <summary>
        /// Đang làm việc
        /// </summary>
        Working,

        /// <summary>
        /// Đang thử việc
        /// </summary>
        TrailWork,

        /// <summary>
        /// Đã nghỉ hưu
        /// </summary>
        Retired
    }
}
