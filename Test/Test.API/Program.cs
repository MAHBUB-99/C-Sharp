using Microsoft.EntityFrameworkCore;
using Test.Application.Services;
using Test.Domain.Interface;
using Test.Infrastructure.Data;
using Test.Infrastructure.Repository; // Add this using directive if BlogRepository is in this namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<IBlogRepository,BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
