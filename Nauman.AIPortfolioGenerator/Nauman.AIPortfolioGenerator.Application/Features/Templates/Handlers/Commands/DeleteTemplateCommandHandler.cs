using Application.Responses.Common;
using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, BaseResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public DeleteTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var template = await _templateRepository.GetAsync(request.Id);

            await _templateRepository.DeleteAsync(template);

            response.Success = true;
            response.Message = "Deletion Successful";
            return response;
        }
    }
}
