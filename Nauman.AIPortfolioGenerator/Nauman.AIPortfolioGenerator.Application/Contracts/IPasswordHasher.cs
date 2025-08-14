using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.Contracts
{
    public interface IPasswordHasher
    {
        string HashPassword(User user, string plainPassword);
        PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword);
    }

    public enum PasswordVerificationResult
    {
        Failed = 0,
        Success = 1
    }
}
