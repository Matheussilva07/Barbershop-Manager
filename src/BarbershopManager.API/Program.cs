using BarbershopManager.API.Filter;
using BarbershopManager.API.Token;
using BarbershopManager.Application;
using BarbershopManager.Application.AutoMapper;
using BarbershopManager.Domain.Services;
using BarbershopManager.Infrastructure;
using BarbershopManager.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
	config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Description = @"JWT Authorization header using the bearer scheme. 
						Enter 'Bearer [space]' and then your token in the text input below.
						Example: 'Bearer 123diqjwoo'",
		In = ParameterLocation.Header,
		Scheme = "Bearer",
		Type = SecuritySchemeType.ApiKey
	});

	config.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
});

builder.Services.AddScoped<ITokenProvider, HttpContextAccessorRequest>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
	options.AddPolicy("PoliticaCors",
		policy =>
		{
			policy.WithOrigins("http://127.0.0.1:5500/")
			.AllowAnyMethod()
			.AllowAnyHeader()
			.SetIsOriginAllowed(origin => true)
			.WithExposedHeaders("Location");

		});

});

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter))); // <- Define o filtro de exceção:

builder.Services.AddUseCasesDependencyInjection();
builder.Services.AddInfrastructureDependencyInjection(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapping));


builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(options =>
{
	options.MapType<DateOnly>(() => new OpenApiSchema
	{
		Type = "string",
		Format = "date"
	});
});

builder.Services.AddAuthentication(config =>
{
	config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
	config.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ClockSkew = new TimeSpan(0),
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Settings:Jwt:signingKey")!))
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


app.UseCors("PoliticaCors");

await MigrationsApllyCommand.ApllyMigration(app.Services);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
