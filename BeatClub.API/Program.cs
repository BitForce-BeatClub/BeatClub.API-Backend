using System;
using BeatClub.API.BeatClub.Domain.Repositories;
using BeatClub.API.BeatClub.Domain.Services;
using BeatClub.API.BeatClub.Persistence.Repositories;
using BeatClub.API.BeatClub.Services;
using BeatClub.API.Security.Authorization.Handlers.Implementations;
using BeatClub.API.Security.Authorization.Handlers.Interfaces;
using BeatClub.API.Security.Authorization.Middleware;
using BeatClub.API.Security.Authorization.Settings;
using BeatClub.API.Security.Domain.Repositories;
using BeatClub.API.Security.Domain.Services;
using BeatClub.API.Security.Persistence.Repositories;
using BeatClub.API.Security.Service;
using BeatClub.API.Shared.Domain.Repositories;
using BeatClub.API.Shared.Persistence.Contexts;
using BeatClub.API.Shared.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add CORS service

builder.Services.AddCors();

// AppSettings Configuration

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        options.SwaggerDoc("v1",new OpenApiInfo
        {
            Version = "v1",
            Title = "BeatClub API",
            Description = "BeatClub RESTful API",
            TermsOfService = new Uri("https://bitforce-beatclub.github.io/LandingPage/#services"),
            Contact = new OpenApiContact
            {
                Name = "BitForce",
                Url = new Uri("https://bitforce-beatclub.github.io/LandingPage/")
            },
            License = new OpenApiLicense
            {
                Name = "BeatClub Resources License",
                Url = new Uri("https://bitforce-beatclub.github.io/LandingPage/#services")
            }
        });
        
        options.EnableAnnotations();
        options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http, 
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = "JWT Authorization header using the Bearer scheme."
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                },
                Array.Empty<string>()
            }
        });
        
    });

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString!)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// BeatClub Injection Configuration

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationService, PublicationService>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Security Injection Configuration

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(BeatClub.API.BeatClub.Mapping.ModelToResourceProfile),
    typeof(BeatClub.API.BeatClub.Mapping.ResourceToModelProfile),
    typeof(BeatClub.API.Security.Mapping.ModelToResourceProfile),
    typeof(BeatClub.API.Security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json","v1");
        options.RoutePrefix = "swagger";
    });
}

// Configuration CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure error handler middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();