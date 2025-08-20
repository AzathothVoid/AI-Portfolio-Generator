using Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Handlers.Queries;
using Nauman.AIPortfolioGenerator.Application.Features.Templates.Requests.Queries;
using Nauman.AIPortfolioGenerator.Application.Mapper;
using Nauman.AIPortfolioGenerator.Application.Responses;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Template.Queries
{
    public class GetTemplateListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITemplateRepository> _mockRepo;
        public GetTemplateListRequestHandlerTests()
        {
            _mockRepo = MockTemplateRepository.GetTemplateRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTemplateListTest()
        {
            var handler = new GetTemplateListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTemplateListRequest(), CancellationToken.None);

            result.ShouldBeOfType<CustomQueryResponse<List<TemplateDTO>>>();
            result.Success.ShouldBe(true);
            result.Errors.ShouldBeNull();
            result.Data.ShouldBeOfType<List<TemplateDTO>>();
            result.Data.Count.ShouldBe(2);
        }
    }
}
