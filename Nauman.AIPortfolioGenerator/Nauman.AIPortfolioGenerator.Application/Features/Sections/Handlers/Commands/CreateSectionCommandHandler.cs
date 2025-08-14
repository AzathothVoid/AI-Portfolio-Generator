using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Persistence.Contracts;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, int>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly ITemplateRepository _templateRepostiory;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public CreateSectionCommandHandler(ISectionRepository sectionRepository, ITemplateRepository templateRepostiory, IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _sectionRepository  = sectionRepository;
            _templateRepostiory = templateRepostiory;
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSectionDTOValidator(_templateRepostiory, _portfolioRepository);
            var validationResult = await validator.ValidateAsync(request.sectionDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var section = _mapper.Map<Section>(request.sectionDTO);

            section = await _sectionRepository.AddAsync(section);

            return section.Id;
        }
    }
}
