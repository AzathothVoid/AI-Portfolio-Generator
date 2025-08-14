using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Unit>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly ITemplateRepository _templateRepostiory;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public UpdateSectionCommandHandler(ISectionRepository sectionRepository, ITemplateRepository templateRepostiory, IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _templateRepostiory = templateRepostiory;
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSectionDTOValidator(_templateRepostiory, _portfolioRepository);
            var validationResult = await validator.ValidateAsync(request.sectionDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var section = await _sectionRepository.GetAsync(request.Id);

            _mapper.Map(request.sectionDTO, section);

            await _sectionRepository.UpdateAsync(section);

            return Unit.Value;
        }
    }
}
