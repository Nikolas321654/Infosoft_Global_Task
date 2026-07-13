using Breeders.API.Middleware;
using Breeders.Application.Interfaces;
using Breeders.Application.Services;
using Breeders.Infrastructure.Repositories;
using Breeders.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Breeders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BreedersDbContext>(options =>
    options.UseSqlite("Data Source=breeders.db"));

builder.Services.AddScoped<ILitterRepository, LitterRepository>();
builder.Services.AddScoped<IBreederBenefitRepository, BreederBenefitRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ILitterService, LitterService>();
builder.Services.AddTransient<INotificationService, ConsoleNotificationService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();