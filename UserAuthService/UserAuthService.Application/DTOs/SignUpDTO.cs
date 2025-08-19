using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthService.Domain.Entities;

namespace UserAuthService.Application.DTOs
{
    public class SignUpDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }        
        public required string Role { get; set; }
    }
}
