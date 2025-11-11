using AutoMapper;
using CCA.Application.DTOs.CourseCategoryDtos;
using CCA.Application.DTOs.CourseDtos;
using CCA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<CourseCategory, CourseCategoryDto>().ReverseMap();
            CreateMap<CourseCategoryCreateDto, CourseCategory>().ReverseMap();
            CreateMap<CourseCategoryUpdateDto, CourseCategory>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CourseCreateDto, Course>().ReverseMap();
            CreateMap<CourseUpdateDto, Course>().ReverseMap();
        }
    }
}
