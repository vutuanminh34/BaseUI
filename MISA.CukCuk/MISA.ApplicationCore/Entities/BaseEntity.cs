﻿using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Value { get; set; }

        public string ErrorMsg { get; set; }

        public MaxLength(int length, string errorMsg)
        {
            this.Value = length;
            this.ErrorMsg = errorMsg;
        }
    }

    public class BaseEntity
    {
        public EntityState EntityState { get; set; } = EntityState.Insert;
        
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa bản ghi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa bản ghi
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
