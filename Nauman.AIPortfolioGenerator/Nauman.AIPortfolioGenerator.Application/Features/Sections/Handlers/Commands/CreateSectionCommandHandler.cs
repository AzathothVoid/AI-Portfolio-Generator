using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Responses;
using Nauman.AIPortfolioGenerator.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, CustomCommandResponse>
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
        public async Task<CustomCommandResponse> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomCommandResponse();
            var validator = new CreateSectionDTOValidator(_templateRepostiory, _portfolioRepository);
            var validationResult = await validator.ValidateAsync(request.sectionDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = JsonConvert.SerializeObject(validationResult.Errors.Select(q => q.ErrorMessage).ToList());
                return response;
            }

            var section = _mapper.Map<Section>(request.sectionDTO);

            section = await _sectionRepository.AddAsync(section);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = section.Id;
            return response;
        }
    }
}
