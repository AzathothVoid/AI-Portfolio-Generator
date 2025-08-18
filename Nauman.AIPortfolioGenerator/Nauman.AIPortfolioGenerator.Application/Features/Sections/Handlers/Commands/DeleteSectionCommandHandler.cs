using Application.Responses.Common;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.Features.Sections.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Sections.Handlers.Commands
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, BaseResponse>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public DeleteSectionCommandHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var section = await _sectionRepository.GetAsync(request.Id);

            await _sectionRepository.DeleteAsync(section);

            response.Success = true;
            response.Message = "Deletion Successful";
            return response;
        }
    }
}
