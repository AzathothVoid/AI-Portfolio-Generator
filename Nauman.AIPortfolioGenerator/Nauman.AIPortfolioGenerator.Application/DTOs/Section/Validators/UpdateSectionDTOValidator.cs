using FluentValidation;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators
{
    public class UpdateSectionDTOValidator : AbstractValidator<UpdateSectionDTO>
    {
        private readonly ITemplateRepository _templateRepostiory;
        private readonly IPortfolioRepository _portfolioRepository;

        public UpdateSectionDTOValidator(ITemplateRepository templateRepostiory, IPortfolioRepository portfolioRepository)
        {
            _templateRepostiory = templateRepostiory;
            _portfolioRepository = portfolioRepository;

            Include(new ISectionDTOValidator(templateRepostiory, portfolioRepository));
        }
    }
}
