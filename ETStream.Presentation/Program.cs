using ETStream.Infrastructure.Sources;
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

            services.AddDbContext<ETStreamContext>(
                options => options.UseSqlServer(connectionString)
            );

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}