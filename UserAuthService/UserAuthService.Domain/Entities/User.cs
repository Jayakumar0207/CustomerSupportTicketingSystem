using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthService.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Customer, Support
        public string Email { get; set; }
        public string Password { get; set; }        

    }
}
