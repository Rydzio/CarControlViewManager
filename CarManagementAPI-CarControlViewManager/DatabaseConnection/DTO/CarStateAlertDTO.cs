using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection.DTO
{
    public class CarStateAlertDTO
    {
        public int CarId { get; set; }
        public float brakeFluidLevel { get; set; }
        public float batteryLevel { get; set; }
        public float coolantLevel { get; set; }
        public float lftyrePressure { get; set; }
        public float rftyrePressure { get; set; }
        public float lbtyrePressure { get; set; }
        public float rbtyrePressure { get; set; }
        public float motorOil { get; set; }
        public float windscreenFluid { get; set; }
        public System.DateTime serviceDate { get; set; }
    }
}
