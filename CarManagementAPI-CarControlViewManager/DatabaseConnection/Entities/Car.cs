using System;
using System.Collections.Generic;

namespace DatabaseConnection.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        #region Bools
        public bool IsBlocked { get; set; }
        public bool IsAlarmOn { get; set; }
        public bool IsEmergencyOn { get; set; }
        public bool AreDoorsBlocked { get; set; }
        public bool IsClimaOn { get; set; }
        public bool IsTrunkOpen { get; set; }
        public bool IsHoodOpen { get; set; }
        public bool IsRoofOpen { get; set; }
        public bool IsFuelFillerOpen { get; set; }
        public bool IsLowBeamOn { get; set; }
        public bool IsHighBeamOn { get; set; }
        public bool AreFrontParkingLightsOn { get; set; }
        #endregion
        
        #region Coolant
        public float MinCoolantLevel { get; set; }
        public float ActualCoolantLevel { get; set; }
        public float MaxCoolantLevel { get; set; }
        #endregion

        #region BrakeFuilds
        public float MinBrakeFluidLevel { get; set; }
        public float ActualBrakeFluidLevel { get; set; }
        public float MaxBrakeFluidLevel { get; set; }
        #endregion
        
        #region Motor Oil
        public float MinMotorOilLevel { get; set; }
        public float ActualMotorOilLevel { get; set; }
        public float MaxMotorOilLevel { get; set; }
        #endregion

        #region WindscreenWasher
        public float MinWindscreenWasherLevel { get; set; }
        public float ActualWindscreenWasherLevel { get; set; }
        public float MaxWindscreenWasherLevel { get; set; }
        #endregion

        #region Battery
        public float MinBatteryLevel { get; set; }
        public float ActualBatteryLevel { get; set; }
        public float MaxBatteryLevel { get; set; }
        #endregion
        
        #region Tyres
        public float MaxTyrePressure { get; set; }
        public float ActualFrontRightTyrePressure { get; set; }
        public float ActualFrontLeftTyrePressure { get; set; }
        public float ActualRearRightTyrePressure { get; set; }
        public float ActualRearLeftTyrePressure { get; set; }
        #endregion
        
        #region Temperature
        public float InsideTemperature { get; set; }
        public float OutsideTemperature { get; set; }
        public float ClimaTemperature { get; set; }
        #endregion
        
        public DateTime PreviousServiceDate{ get; set; }

        public HotChairLevel HotChairLevel { get; set; }
        
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public float BlockedLocationY { get; set; }
        public float BlockedLocationX { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Notification> ErrorLogs { get; set; }
    }

    public enum HotChairLevel
    {
        Off, Low, Medium, High
    }
}