using BarbershopManager.Application;
using BarbershopManager.Application.AutoMapper;
using BarbershopManager.Application.UseCases.Faturamento.GetAll;
using BarbershopManager.Application.UseCases.Faturamento.GetById;
using BarbershopManager.Application.UseCases.Faturamento.Register;
using BarbershopManager.Domain;
using BarbershopManager.Domain.IncomeRepository;
using BarbershopManager.Infrastructure;
using BarbershopManager.Infrastructure.DataAccess;
using BarbershopManager.Infrastructure.IncomeRepository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BarbershopDbContext>();
builder.Services.AddScoped<IIncomesRepository,IncomesRepository>();
builder.Services.AddScoped<IUpdateRepository, IncomesRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.MyDependencyInjection();

builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(options => {
	options.MapType<DateOnly>(() => new OpenApiSchema
	{
		Type = "string",
		Format = "date"
	});
});

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
