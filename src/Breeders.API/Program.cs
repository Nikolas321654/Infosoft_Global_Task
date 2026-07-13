using Breeders.Application.Interfaces;
using Breeders.Infrastructure;
using Breeders.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ILitterRepository, LitterRepository>();
builder.Services.AddScoped<IBreederBenefitRepository, BreederBenefitRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BreedersDbContext>(options =>
    options.UseSqlite("Data Source=breeders.db"));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();