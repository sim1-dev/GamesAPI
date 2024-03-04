using System.Text.Json.Serialization;
using GamesAPI.Core.DataContexts;
using GamesAPI.Core.Middleware;
using GamesAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BaseContext");

builder.Services.AddDbContext<BaseContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
	.AddAuthorization(option => {
        option.AddPolicy("IsGameDeveloper", policy => policy.Requirements.Add(new IsGameDeveloperRequirement()));
	})
	.AddIdentity<User, Role>()
	.AddEntityFrameworkStores<BaseContext>()
	.AddDefaultTokenProviders()
    .AddApiEndpoints()
;

builder.Services.AddScoped<IAuthorizationHandler, IsGameDeveloperHandler>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option => {
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
                 In = ParameterLocation.Header,
                 Name = "Authorization",
                 Type = SecuritySchemeType.ApiKey
             }
    );
    
    option.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    }
                },
                []
            }
        }
    );
});

builder.Services.AddScoped(typeof(GameService));
builder.Services.AddScoped(typeof(PlatformService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
