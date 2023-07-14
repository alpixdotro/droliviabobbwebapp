using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Api;
using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    // Register the DbContext
                    services.AddDbContext<FunctionDbContext>(options =>
                    {
                        options.UseSqlServer("Server=droliviabobbmysql.mysql.database.azure.com;User ID=alpixapps_dev_admin;Password=Yp8Br12c1109#oli;Database=droliviabobbdb;sslmode=Required");
                    });

                    // Register the PatientService
                    services.AddScoped<PatientService>();
                })
                .Build();

            host.Run();
        }
    }
}
