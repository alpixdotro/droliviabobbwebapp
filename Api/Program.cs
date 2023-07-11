using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Api;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults(worker =>
                {
                    worker.Services.AddSingleton<MockDataService>();
                })
                .Build();

            host.Run();
        }
    }
}
