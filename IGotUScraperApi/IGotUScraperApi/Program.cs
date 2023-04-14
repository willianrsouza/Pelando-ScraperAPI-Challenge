using IGotUScraperApi.DependencyInjection;
using IGotUScraperApi.Startup.VersionamentoApi;
using Microsoft.AspNetCore.Server.IISIntegration;
using MySqlConnector;
using System;

internal static class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApiVersioning();
        builder.Services.ConfigureApiVersion();
        builder.Services.AddDependencyResolver();
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = IISDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = IISDefaults.AuthenticationScheme;
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}