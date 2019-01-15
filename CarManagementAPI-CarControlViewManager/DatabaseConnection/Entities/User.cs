using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Nick { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Surname { get; set; }

        public bool IsFirstLogIn { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<Notification> ErrorLogs { get; set; }
    }
}
