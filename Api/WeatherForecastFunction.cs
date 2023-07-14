using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Api;
using System.Threading.Tasks;
using System;
using Api.Services;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiIsolated
{
    public class HttpTrigger
    {
        private readonly ILogger<HttpTrigger> _logger;
        private readonly FunctionDbContext _dbContext;
        private readonly PatientService _patientService;

        public HttpTrigger(ILogger<HttpTrigger> logger, FunctionDbContext dbContext, PatientService patientService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _patientService = patientService;
        }

        [Function("GetPatients")]
        public async Task<HttpResponseData> GetPatients([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext context)
        {
            
            try
            {
                _patientService.InsertData();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                Console.WriteLine(ex.Message);
            }




            var response = req.CreateResponse(HttpStatusCode.OK);
            var patients = "HELLO";

            await response.WriteAsJsonAsync(patients);

            return response;
        }
    }
}
