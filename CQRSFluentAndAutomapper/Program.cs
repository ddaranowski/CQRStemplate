
using System.Text.Json.Serialization;
using CQRSFluentAndAutomapper.Models;
using CQRSMediatR.Api.Application;
using CQRSMediatR.Api.Application.Flows.Queries;
using CQRSMediatR.Api.Infractructure;
using CQRSMediatR.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using FluentValidation;


namespace CQRSFluentAndAutomapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            builder.Services.AddScoped<IFlowService, FlowService>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            builder.Services.AddScoped<IValidator<CreateFlowRequest>, CreateFlowValidator>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));


            var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
          
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
