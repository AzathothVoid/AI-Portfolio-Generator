using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Unit>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public DeleteSectionCommandHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetAsync(request.Id);

            await _sectionRepository.DeleteAsync(section);

            return Unit.Value;
        }
    }
}
