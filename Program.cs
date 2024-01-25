using HangfileService.Service;
using Hangfire;
using Hangfire.Dashboard;

namespace HangfileService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;

            var a = configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddHangfireServer();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IUsersService, UsersService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHangfireDashboard("/HangFireDashboard", new DashboardOptions
            {
                Authorization = Enumerable.Empty<IDashboardAuthorizationFilter>()
            });
            app.MapHangfireDashboard();

            RecurringJob.AddOrUpdate<IUsersService>("GetUser", x => x.GetUsers(), Cron.Minutely);

            app.MapControllers();

            app.Run();
        }
    }
}