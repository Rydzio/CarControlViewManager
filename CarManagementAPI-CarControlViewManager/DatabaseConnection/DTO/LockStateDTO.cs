using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection.DTO
{
    public class LockStateDTO
    {
        public bool AreDoorsBlocked { get; set; }
        public bool IsTrunkOpen { get; set; }
        public bool IsHoodOpen { get; set; }
        public bool IsRoofOpen { get; set; }
        public bool IsFuelFillerOpen { get; set; }
    }
}
