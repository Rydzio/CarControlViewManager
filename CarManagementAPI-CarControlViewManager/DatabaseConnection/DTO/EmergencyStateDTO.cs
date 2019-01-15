using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class EmergencyStateDTO
    {
        public int CarId { get; set; }  
        public bool IsBlocked { get; set; }
        public float BlockedLocationX { get; set; }
        public float BlockedLocationY { get; set; }
        public bool AreDoorsBlocked { get; set; }
    }
}