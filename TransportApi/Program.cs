using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TransportApi.Application.DependecyInjection;
using TransportApi.Domain.Validators;
using TransportApi.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services .AddValidatorsFromAssemblyContaining<TransportValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
        {
            opt.CommandTimeout(180);
            opt.EnableRetryOnFailure(5);
            opt.MigrationsAssembly("TransportApi.Infra");
        }));

builder.Services.AddClassesMatchingInterfaces();

builder.Services.AddOutputCache();

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

app.UseOutputCache();

app.Run();
