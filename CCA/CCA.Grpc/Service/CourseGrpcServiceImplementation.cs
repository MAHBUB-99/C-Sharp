using CCA.Application.IService;
using CCA.Application.Pagination;
using Grpc.Core;
using GrpcService.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Grpc.Service
{
    public class CourseGrpcServiceImplementation : CourseGrpcService.CourseGrpcServiceBase
    {
        private readonly ICourseService _courseService;
        public CourseGrpcServiceImplementation(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public override async Task<CourseListResponse> GetAllCourses(PaginationRequest request, ServerCallContext serverCallContext)
        {
            var paginationParams = new PaginationParams
            {
                PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber,
                PageSize = request.PageSize <= 0 ? 3 : request.PageSize
            };

            var courses = await _courseService.GetAllPagedAsync(paginationParams);
            var response = new CourseListResponse
            {
                TotalCount = courses.TotalCount,
                CurrentPage = courses.CurrentPage,
                PageSize = courses.PageSize,
                TotalPages = courses.TotalPages
            };

            foreach (var c in courses.Data)
            {
                response.Courses.Add(new CourseResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                });
            }
            return response;
        }

        public override async Task<CourseResponse> GetCourseById(CourseIdRequest request, ServerCallContext context)
        {
            var course = await _courseService.GetByIdAsync(request.Id);

            if (course == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Course with ID {request.Id} not found."));

            return new CourseResponse
            {
                Id = course.Id,
                Title = course.Title,
                CategoryId = course.CategoryId,
                CategoryName = course.CategoryName
            };
        }

        public override async Task<CourseListResponse> GetCoursesByCategory(CategoryIdRequest request, ServerCallContext context)
        {
            var paginationParams = new PaginationParams
            {
                PageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber,
                PageSize = request.PageSize <= 0 ? 3 : request.PageSize
            };

            var courses = await _courseService.GetByCategoryIdAsync(request.CategoryId, paginationParams);

            var response = new CourseListResponse
            {
                TotalCount = courses.TotalCount,
                CurrentPage = courses.CurrentPage,
                PageSize = courses.PageSize,
                TotalPages = courses.TotalPages
            };

            foreach (var c in courses.Data)
            {
                response.Courses.Add(new CourseResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                });
            }

            return response;
        }
    }
}
