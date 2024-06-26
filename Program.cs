using System.Text.Json.Serialization;
using GamesAPI.Core.DataContexts;
using GamesAPI.Middleware;
using GamesAPI.Core.Models;
using GamesAPI.Repositories;
using GamesAPI.Core.Services;
using GamesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using GamesAPI.Core.Middleware;
using Serilog;
using GamesAPI.Core.Repositories;
using Asp.Versioning;
using Microsoft.AspNetCore.StaticFiles;
using StandardizedFilters.Core.Services.Request;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .ClearProviders()
    .AddSerilog(new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("Logs/error.log", rollingInterval: RollingInterval.Day)
        .CreateLogger()
    )
;

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("BaseContext");

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddDbContext<BaseContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services
    .AddAuthentication(options => {
        options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
        options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
    })
    .AddBearerToken()
;

builder.Services
    .AddAuthorization(option => {
        option.AddPolicy("IsGameDeveloper", policy => policy.Requirements.Add(new IsGameDeveloperRequirement()));
        option.AddPolicy("IsReviewerUser", policy => policy.Requirements.Add(new IsReviewerUserRequirement()));    
    });

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<BaseContext>()
    .AddDefaultTokenProviders()
;

builder.Services
    .AddSingleton<PasswordHasher<User>>()
    .AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>()
    .AddSingleton<IFileService, FileService>()
;

builder.Services
    .AddScoped(typeof(UserContextService))
;

builder.Services
    .AddScoped<IAuthorizationHandler, IsGameDeveloperHandler>()
    .AddScoped<IAuthorizationHandler, IsReviewerUserHandler>()
;

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRoleService, RoleService>()
    .AddScoped(typeof(IExcelExportService<>), typeof(ExcelExportService<>))
;

builder.Services
    .AddScoped<IMailService, MailService>()
;

builder.Services
    .AddScoped<IPlatformService, PlatformService>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IGameService, GameService>()
    .AddScoped<IReviewService, ReviewService>()
    .AddScoped<ISoftwareHouseService, SoftwareHouseService>()
    .AddScoped<IGamePlatformService, GamePlatformService>()
    .AddScoped<IDeveloperService, DeveloperService>()
;

builder.Services
    .AddScoped(typeof(IRepositoryHelper<>), typeof(RepositoryHelper<>))
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IRoleRepository, RoleRepository>()
;

builder.Services
    .AddScoped<IPlatformRepository, PlatformRepository>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<IGameRepository, GameRepository>()
    .AddScoped<IReviewRepository, ReviewRepository>()
    .AddScoped<ISoftwareHouseRepository, SoftwareHouseRepository>()
    .AddScoped<IGamePlatformRepository, GamePlatformRepository>()
    .AddScoped<IDeveloperRepository, DeveloperRepository>()
;

builder.Services.AddAutoMapper(typeof(Program));

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
;

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services
    .AddApiVersioning(options => {
        options.DefaultApiVersion = new ApiVersion(1);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options => {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    })
;

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

app.UseMiddleware<ResponseWrapperMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
    
