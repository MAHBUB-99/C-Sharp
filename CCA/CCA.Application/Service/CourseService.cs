using AutoMapper;
using CCA.Application.DTOs.CourseDtos;
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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, ICourseCategoryRepository courseCategoryRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseCategoryRepository = courseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CourseDto>> GetAllPagedAsync(PaginationParams paginationParams)
        {
            var courses = await _courseRepository.GetAllPagedAsync(paginationParams);
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses.Data);

            return new PaginatedResult<CourseDto>(
                courseDtos,
                courses.TotalCount,
                courses.CurrentPage,
                courses.PageSize
            );
        }

        public async Task<PaginatedResult<CourseDto>> GetByCategoryIdAsync(int categoryId, PaginationParams paginationParams)
        {
            var courses = await _courseRepository.GetByCategoryIdAsync(categoryId, paginationParams);
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses.Data);

            return new PaginatedResult<CourseDto>(
                courseDtos,
                courses.TotalCount,
                courses.CurrentPage,
                courses.PageSize
            );
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> AddAsync(CourseCreateDto courseCreateDto)
        {
            try
            {
                var category = await _courseCategoryRepository.GetByIdAsync(courseCreateDto.CategoryId);
                if (category == null)
                    throw new KeyNotFoundException($"Category with ID {courseCreateDto.CategoryId} does not exist.");

                var course = _mapper.Map<Course>(courseCreateDto);
                return await _courseRepository.AddAsync(course);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, CourseUpdateDto courseUpdateDto)
        {
            try
            {
                var existingCourse = await _courseRepository.GetByIdAsync(id);
                if (existingCourse == null)
                    throw new KeyNotFoundException($"Course with ID {id} not found.");
                
                var category = await _courseCategoryRepository.GetByIdAsync(courseUpdateDto.CategoryId);
                if (category == null)
                    throw new KeyNotFoundException($"Category with ID {courseUpdateDto.CategoryId} does not exist.");
                
                _mapper.Map(courseUpdateDto, existingCourse);
                return await _courseRepository.UpdateAsync(existingCourse);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existingCourse = await _courseRepository.GetByIdAsync(id);
                if (existingCourse == null)
                    throw new KeyNotFoundException($"Course with ID {id} not found.");

                return await _courseRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
