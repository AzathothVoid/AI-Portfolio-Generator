using Moq;
using Nauman.AIPortfolioGenerator.Domain;
using Nauman.AIPortfolioGenerator.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.UnitTests.Mocks
{
    public static class MockTemplateRepository
    {
        public static Mock<ITemplateRepository> GetTemplateRepository()
        {
            var templates = new List<Nauman.AIPortfolioGenerator.Domain.Template>
            {
                new Nauman.AIPortfolioGenerator.Domain.Template
                {
                    Id = 1,
                    Name = "Web Developer CV",
                    Description = "A fine CV for a sauve and professional look",
                    Keywords = new string[] { "Professional", "Portfolio", "Modern" },
                    Themes = new string[] { "Professional", "Upbright" },
                    Palette = new string[] { "#000", "#111" },
                    IsPaid = false
                },
                new Nauman.AIPortfolioGenerator.Domain.Template
                {
                    Id = 2,
                    Name = "AI Developer CV",
                    Description = "A fine CV for a automated engineer like youself",
                    Keywords = new string[] { "Professional", "Portfolio", "Modern" },
                    Themes = new string[] { "Professional", "Upbright" },
                    Palette = new string[] { "#000111", "#111000" },
                    IsPaid = true
                }
            };

            var mockRepo = new Mock<ITemplateRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(templates);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Nauman.AIPortfolioGenerator.Domain.Template>())).ReturnsAsync((Nauman.AIPortfolioGenerator.Domain.Template template) =>
            {
                templates.Add(template);
                return template;
            });

            return mockRepo;
        }
    }
}
