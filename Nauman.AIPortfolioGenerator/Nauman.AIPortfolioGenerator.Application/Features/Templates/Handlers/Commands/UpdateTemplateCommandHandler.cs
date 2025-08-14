using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Unit>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public UpdateTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTemplateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.templateDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var template = await _templateRepository.GetAsync(request.Id);

            _mapper.Map(request.templateDTO, template);

            await _templateRepository.UpdateAsync(template);

            return Unit.Value;
        }
    }
}
