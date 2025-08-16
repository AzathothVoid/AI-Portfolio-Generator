using Nauman.AIPortfolioGenerator.Application.Persistence;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(User user, string plainPassword)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
