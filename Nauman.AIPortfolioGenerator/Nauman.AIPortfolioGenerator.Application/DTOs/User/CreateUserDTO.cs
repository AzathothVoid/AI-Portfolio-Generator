using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User
{
    public class CreateUserDTO : IUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PlainPassword { get; set; }
        public bool isPremium { get; set; }

    }
}
