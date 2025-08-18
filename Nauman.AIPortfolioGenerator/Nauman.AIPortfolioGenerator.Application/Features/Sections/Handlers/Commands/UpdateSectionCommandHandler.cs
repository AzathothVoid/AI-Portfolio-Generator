using Application.Responses.Common;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, BaseResponse>
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

        public async Task<BaseResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new UpdateSectionDTOValidator(_templateRepostiory, _portfolioRepository);
            var validationResult = await validator.ValidateAsync(request.sectionDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var section = await _sectionRepository.GetAsync(request.Id);

            _mapper.Map(request.sectionDTO, section);

            await _sectionRepository.UpdateAsync(section);

            response.Success = true;
            response.Message = "Update Successful";
            return response;
        }
    }
}
