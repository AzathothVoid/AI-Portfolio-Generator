using Nauman.AIPortfolioGenerator.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User
{
    public class UserDTO : BaseDTO, IUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool isPremium { get; set; }
    }
}
