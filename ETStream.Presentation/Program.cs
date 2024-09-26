using System.IdentityModel.Tokens.Jwt;
using ETStream.Application.CrossCutting;
using ETStream.Application.Handlers;
using ETStream.Domain.Aggregates.School;
using ETStream.Domain.Contracts;
using ETStream.Domain.Seed;
using ETStream.Infrastructure.Repositories;
using ETStream.Infrastructure.Sources;
using ETStream.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace ETStream.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler();

            app.UseMiddleware<AuthMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            var jwtSettings = new JwtSettings()
            {
                SecretKey = configuration.GetSection("JwtSettings").GetValue<string>("SecretKey")!
            };

            services.AddSingleton(jwtSettings);
            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddScoped<JwtService>();

            services.AddDbContext<ETStreamContext>(
                options => options.UseSqlServer(connectionString)
            );

            services.AddScoped<IUserRepository, UserSqlServerRepository>();
            services.AddScoped<IRepository<SchoolEntity>, SqlServerRepository<SchoolEntity>>();

            services.AddScoped<SchoolCommandHandler>();
            services.AddScoped<UserCommandHandler>();

            services.AddScoped<SchoolQueryHandler>();
            services.AddScoped<UserQueryHandler>();

            services.AddTransient<AuthMiddleware>();

            services.AddExceptionHandler<ErrorHandlingMiddleware>();
            services.AddProblemDetails();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}