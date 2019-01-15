using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection.DTO
{
    public class AlarmStateDTO
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public bool State { get; set; }
    }
}