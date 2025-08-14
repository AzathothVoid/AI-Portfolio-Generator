using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, Unit>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public DeleteTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = await _templateRepository.GetAsync(request.Id);

            await _templateRepository.DeleteAsync(template);

            return Unit.Value;
        }
    }
}
