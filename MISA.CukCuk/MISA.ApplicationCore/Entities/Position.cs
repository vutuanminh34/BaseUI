﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class Position : BaseEntity
    {
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }
    }
}
