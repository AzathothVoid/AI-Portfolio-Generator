using AutoMapper;
using MediatR;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template.Validators;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Commands;
using Nauman.AIPortfolioGenerator.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Commands
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, BaseResponse>
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public UpdateTemplateCommandHandler(ITemplateRepository templateRepository, IMapper mapper)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var validator = new UpdateTemplateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.templateDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var template = await _templateRepository.GetAsync(request.Id);

            _mapper.Map(request.templateDTO, template);

            await _templateRepository.UpdateAsync(template);

            response.Success = true;
            response.Message = "Update Successful";
            return response;
        }
    }
}
