using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Features.Users.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.User.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(
             IValidator<UpdateUserDTO> updateUserValidator,
             IValidator<ChangeUserPasswordDTO> changePasswordValidator,
             IValidator<ChangeUserPremiumStatusDTO> changePremiumStatusValidator)
        {
            RuleFor(cmd =>
                (cmd.userDTO != null ? 1 : 0)
              + (cmd.changePasswordDTO != null ? 1 : 0)
              + (cmd.changePremiumStatusDTO != null ? 1 : 0))
                .Equal(1)
                .WithMessage("Exactly one update type must be provided.");

            When(cmd => cmd.userDTO != null, () =>
            {
                RuleFor(cmd => cmd.userDTO)
                    .SetValidator(updateUserValidator);
            });

            When(cmd => cmd.changePasswordDTO != null, () =>
            {
                RuleFor(cmd => cmd.changePasswordDTO)
                    .SetValidator(changePasswordValidator);
            });

            When(cmd => cmd.changePremiumStatusDTO != null, () =>
            {
                RuleFor(cmd => cmd.changePremiumStatusDTO)
                    .SetValidator(changePremiumStatusValidator);
            });
        }
    }
}
