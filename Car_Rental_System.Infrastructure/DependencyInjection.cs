﻿using Car_Rental_System.Application.Common.Interfaces;
using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Identity;
using Car_Rental_System.Infrastructure.Jobs;
using Car_Rental_System.Infrastructure.Persistence;
using Car_Rental_System.Infrastructure.Persistence.Seeders;
using Car_Rental_System.Infrastructure.Repositories;
using Car_Rental_System.Infrastructure.Services.EmailService;
using Car_Rental_System.Infrastructure.Services.Storage;
using Car_Rental_System.Infrastructure.Services.TokenProvider;
using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistence(configuration)
            .AddIdentity()
            .AddAuthentication(configuration)
            .AddAuthorization()
            .AddEmailServices(configuration)
            .AddBlobStorage(configuration)
            .AddBackgroundJobs(configuration)
            .AddHealthChecks(configuration);

        return services;
    }


    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ISeeder, RolesSeeder>();
        services.AddScoped<AppSeeder>();

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        //services.AddScoped<IUserFollowRepository, UserFollowRepository>();
        services.AddScoped<IUnitOfWork, UnitOfwork>();

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

        services
            .ConfigureOptions<TokenProviderConfiguration>()
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
        .AddJwtBearer();

        services.AddHttpContextAccessor();
        services.AddScoped<ITokenProvider, JwtTokeProvider>();
        services.AddScoped<IUserContext, UserContext>();

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        //services.AddScoped<IAuthorAuthorizationService, AuthorAuthorizationService>();
        return services;
    }

    private static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.Section));

        var emailSettings = configuration.GetSection(EmailSettings.Section).Get<EmailSettings>()
            ?? throw new InvalidOperationException("Email settings are not configured properly.");

        if (emailSettings.UseSmtp4Dev)
        {
            emailSettings.Host = "smtp.gmail.com";
            emailSettings.Port = 587;
            emailSettings.FromEmail = "ayabadrin667@gmail.com";
            services.AddFluentEmail(emailSettings.FromEmail)
            .AddSmtpSender(emailSettings.Host, emailSettings.Port);
        }
        else
        {
            services.AddFluentEmail(emailSettings.FromEmail, emailSettings.FromName)
                  .AddSmtpSender(() => new SmtpClient(emailSettings.Host)
                  {
                      Port = emailSettings.Port,
                      Credentials = new NetworkCredential("ayabadrin667@gmail.com", emailSettings.Password),
                      EnableSsl = true
                  });
            //.AddSmtpSender(//(emailSettings.Host, emailSettings.Port, emailSettings.Username, emailSettings.Password);
        }

        services.AddScoped<IEmailService, EmailService>();

        return services;
    }

    private static IServiceCollection AddBlobStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BlobStorageSettings>(configuration.GetSection(BlobStorageSettings.Section));
        services.AddSingleton<IBlobStorageService, BlobStorageService>();
        return services;
    }

    private static IServiceCollection AddBackgroundJobs(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<RefreshTokenCleanupJob>();
        services.AddHangfire(cfg => cfg
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSQLiteStorage(configuration.GetConnectionString("HangfireConnection")));

        services.AddHangfireServer();

        return services;
    }

    private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        var azureBlobStorageSettings = configuration.GetSection(BlobStorageSettings.Section).Get<BlobStorageSettings>();
        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>(name: "Database")
            .AddAzureBlobStorage(azureBlobStorageSettings.ConnectionString, name: "BlobStorage");

        return services;
    }

}

