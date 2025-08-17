using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nauman.AIPortfolioGenerator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entity
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasData(
                new Template
                {
                    Id = 1,
                    Name = "Web Developer CV",
                    Description = "A fine CV for a sauve and professional look",
                    Keywords = new string[] { "Professional", "Portfolio", "Modern" },
                    Themes = new string[] { "Professional", "Upbright" },
                    Palette = new string[] { "#000", "#111" },
                    IsPaid = false
                },
                new Template
                {
                    Id = 2,
                    Name = "AI Developer CV",
                    Description = "A fine CV for a automated engineer like youself",
                    Keywords = new string[] { "Professional", "Portfolio", "Modern" },
                    Themes = new string[] { "Professional", "Upbright" },
                    Palette = new string[] { "#000111", "#111000" },
                    IsPaid = true
                }
            );
        }
    }
}
