using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthService.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Role { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
