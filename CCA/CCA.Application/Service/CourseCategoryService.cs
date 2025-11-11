using AutoMapper;
using CCA.Application.DTOs.CourseCategoryDtos;
using CCA.Application.IRepository;
using CCA.Application.IService;
using CCA.Application.Pagination;
using CCA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.Service
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IMapper _mapper;
        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository, IMapper mapper)
        {
            _courseCategoryRepository = courseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CourseCategoryDto>> GetAllPagedAsync(PaginationParams paginationParams)
        {
            var courseCategorries = await _courseCategoryRepository.GetAllPagedAsync(paginationParams);
            var courseCategoryDtos = _mapper.Map<IEnumerable<CourseCategoryDto>>(courseCategorries.Data);
            var paginatedResult = new PaginatedResult<CourseCategoryDto>(
                courseCategoryDtos,
                courseCategorries.TotalCount,
                courseCategorries.CurrentPage,
                courseCategorries.PageSize
                );
            return paginatedResult;
        }

        public async Task<CourseCategoryDto> GetByIdAsync(int id)
        {
            var courseCategory = await _courseCategoryRepository.GetByIdAsync(id);
            var courseCategoryDto = _mapper.Map<CourseCategoryDto>(courseCategory);
            return courseCategoryDto;
        }

        public async Task<CourseCategoryDto> GetByNameAsync(string name)
        {
            var courseCategory = await _courseCategoryRepository.GetByNameAsync(name);
            var courseCategoryDto = _mapper.Map<CourseCategoryDto>(courseCategory);
            return courseCategoryDto;
        }

        public async Task<bool> AddAsync(CourseCategoryCreateDto courseCategoryCreateDto)
        {
            var category = _mapper.Map<CourseCategory>(courseCategoryCreateDto);
            await _courseCategoryRepository.AddAsync(category);
            return true;
        }

        public async Task<bool> UpdateAsync(int id,CourseCategoryUpdateDto categoryDto)
        {
            var existingCategory = await _courseCategoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            _mapper.Map(categoryDto, existingCategory);

            await _courseCategoryRepository.UpdateAsync(existingCategory);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCategory = await _courseCategoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
                throw new KeyNotFoundException($"Course category with ID {id} not found.");

            return await _courseCategoryRepository.DeleteAsync(id);
        }

    }
}
