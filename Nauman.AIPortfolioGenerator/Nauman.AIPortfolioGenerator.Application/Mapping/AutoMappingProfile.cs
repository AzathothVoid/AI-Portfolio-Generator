using System;
using AutoMapper;
using System.Collections.Generic;
using Nauman.AIPortfolioGenerator.Domain;
using System.Text;
using Nauman.AIPortfolioGenerator.Application.DTOs.Portfolio;
using Nauman.AIPortfolioGenerator.Application.DTOs.Section;
using Nauman.AIPortfolioGenerator.Application.DTOs.Template;

namespace Nauman.AIPortfolioGenerator.Application.Mapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Portfolio, PortfolioDTO>().ReverseMap();
            CreateMap<Portfolio, CreatePortfolioDTO>().ReverseMap();
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<Section, UpdateSectionDTO>().ReverseMap();
            CreateMap<Template, TemplateDTO>().ReverseMap();
            CreateMap<UpdateTemplateDTO, Template>().ReverseMap();
        }
    }
}
