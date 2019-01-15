using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DatabaseConnection.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }

        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Reason { get; set; }
        [Required]
        [Column(TypeName ="text")]
        public string CarInfo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}