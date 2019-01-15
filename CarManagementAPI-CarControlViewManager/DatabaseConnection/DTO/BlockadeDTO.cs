using System.ComponentModel.DataAnnotations;

namespace DatabaseConnection.DTO
{
    public class BlockadeDTO
    {
        [Required] public int CarId { get; set; }
        [Required] public bool State { get; set; }
    }
}