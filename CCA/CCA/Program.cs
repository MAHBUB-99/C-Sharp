using CCA.Application.IRepository;
using CCA.Application.IService;
using CCA.Application.Mappings;
using CCA.Application.Service;
using CCA.Grpc.Service;
using CCA.Infrastructure.Data;
using CCA.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add your repositories
builder.Services.AddScoped<ICourseCategoryRepository,CourseCategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// Add your services
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();

// Add gRPC services
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<CourseGrpcServiceImplementation>();

app.MapGet("/", () => "gRPC Service is running...");

app.Run();
