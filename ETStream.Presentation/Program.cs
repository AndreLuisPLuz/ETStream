using ETStream.Application.Handlers;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Aggregates.User;
using ETStream.Domain.Seed;
using ETStream.Infrastructure.Repositories;
using ETStream.Infrastructure.Sources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETStream.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            Console.WriteLine(connectionString);
            services.AddDbContext<ETStreamContext>(
                options => options.UseSqlServer(connectionString)
            );

            services.AddScoped<IRepository<UserEntity>, SqlServerRepository<UserEntity>>();
            services.AddScoped<IRepository<SchoolEntity>, SqlServerRepository<SchoolEntity>>();

            services.AddScoped<SchoolCommandHandler>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}