using FitnessStore.Api.Validators;
using FitnessStore.Business;
using FitnessStore.Data;
using FluentValidation.AspNetCore;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using FluentValidation;
using FitnessStore.Tests;
using FitnessStore.Models.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Add configurations
        builder.Services.Configure<MongoDbConfiguration>(
            builder.Configuration
                .GetSection(nameof(MongoDbConfiguration)));

        // Add services to the container.
       

        

        builder.Services.AddControllers();

        builder.Services
            .AddValidatorsFromAssemblyContaining<ProductServiceTests>();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddSwaggerGen();

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        app.MapHealthChecks("/healthz");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        // Configure the HTTP request pipeline.

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

