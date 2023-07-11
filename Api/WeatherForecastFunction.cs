using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Api;
using System.Threading.Tasks;

namespace ApiIsolated
{
    public class HttpTrigger
    {
        private readonly ILogger _logger;
        private readonly MockDataService _dataService;

        public HttpTrigger(ILoggerFactory loggerFactory, MockDataService dataService)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
            _dataService = dataService;
        }

        [Function("GetPatients")]
        public async Task<HttpResponseData> GetPatients([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var patients = _dataService.Patients;

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(patients);

            return response;
        }

    }
}
