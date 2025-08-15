using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Responses;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, CustomCommandResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public CreateTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<CustomCommandResponse> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();
            var validator = new CreateTemplateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.templateDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var template = _mapper.Map<Template>(request.templateDTO);

            template = await _templateRepository.AddAsync(template);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = template.Id;
            return response;
        }
    }
}
