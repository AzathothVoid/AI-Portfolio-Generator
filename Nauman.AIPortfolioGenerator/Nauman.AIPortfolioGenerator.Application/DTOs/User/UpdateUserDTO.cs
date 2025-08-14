using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User
{
    public class UpdateUserDTO : IUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
