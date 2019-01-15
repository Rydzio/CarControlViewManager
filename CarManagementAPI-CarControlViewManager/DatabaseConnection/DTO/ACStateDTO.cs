using DatabaseConnection.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection.DTO
{
    public class ACStateDTO
    {
        public float ACTemp { get; set; }
        public float InsideTemp { get; set; }
        public float OutsideTemp { get; set; }
        public bool IsACOn { get; set; }
        public HotChairLevel HotChairLevel { get; set; }
    }
}
