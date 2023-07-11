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
        private readonly ILogger<HttpTrigger> _logger;
        private readonly MockDataService _dataService;

        public HttpTrigger(ILogger<HttpTrigger> logger, MockDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [Function("GetPatients")]
        public async Task<HttpResponseData> GetPatients([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext context)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var patients = _dataService.Patients;

            await response.WriteAsJsonAsync(patients);

            return response;
        }
    }
}
