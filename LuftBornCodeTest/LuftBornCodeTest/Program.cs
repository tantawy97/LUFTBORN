using Application.Extension.ApplicationExtensionDI;
using Application.Repositories.IRepository;
using Application.Repositories.Repository;
using Infrastructure.Persistence.ContextDB;
using LuftBornCodeTest.Extensions;
using LuftBornCodeTest.Extensions.DBExtensions;
using LuftBornCodeTest.Extensions.ExceptionFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSQLServerDatabase(builder.Configuration);
builder.Services.AddApplicationDependancies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllerWithFluentValidation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
