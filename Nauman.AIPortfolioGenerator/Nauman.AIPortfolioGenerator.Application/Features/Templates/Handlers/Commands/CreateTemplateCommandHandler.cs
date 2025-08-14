using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, int>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public CreateTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateTemplateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.templateDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var template = _mapper.Map<Template>(request.templateDTO);

            template = await _templateRepository.AddAsync(template);

            return template.Id;
        }
    }
}
