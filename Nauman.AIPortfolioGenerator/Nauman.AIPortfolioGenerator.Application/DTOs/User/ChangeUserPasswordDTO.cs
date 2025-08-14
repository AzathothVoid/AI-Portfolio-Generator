using Nauman.AIPortfolioGenerator.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User
{
    public class ChangeUserPasswordDTO : BaseDTO
   {
        public string PlainPassword { get; set; }
    }
}
