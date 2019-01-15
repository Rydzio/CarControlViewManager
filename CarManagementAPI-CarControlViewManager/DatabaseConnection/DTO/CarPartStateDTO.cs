using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection.DTO
{
    public class CarPartStateDTO
    {
        public bool ToggleLock { get; set; }
        public bool ToggleDors { get; set; }
        public bool ToggleTrunk { get; set; }
        public bool ToggleHood { get; set; }
        public bool ToggleRoof { get; set; }
        public bool ToggleFuelCap { get; set; }
    }
}
