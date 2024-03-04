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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
    options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
}).AddBearerToken();

builder.Services
	.AddAuthorization(option => {
        option.AddPolicy("IsGameDeveloper", policy => policy.Requirements.Add(new IsGameDeveloperRequirement()));
	});

builder.Services
	.AddIdentityApiEndpoints<User>()
	.AddRoles<Role>()
	.AddEntityFrameworkStores<BaseContext>()
	.AddDefaultTokenProviders();
;

builder.Services
    .AddScoped<IAuthorizationHandler, IsGameDeveloperHandler>()
    .AddScoped(typeof(GameService))
    .AddScoped(typeof(PlatformService));

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

var app = builder.Build();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<User>();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();
