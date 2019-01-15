using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection.DTO
{
    public class EmergencySystemDTO
    {
        [Required] public int CarId { get; set; }
        [Required] public bool State { get; set; }
    }
}