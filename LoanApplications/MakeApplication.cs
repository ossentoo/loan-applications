using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace LoanApplications
{
    public static class MakeApplication
    {
        [FunctionName("MakeApplication")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var application = await 
                req.Content.ReadAsAsync<LoanApplication>();

            log.Info($"Application received : {application.Name} {application.Age}");

            return req.CreateResponse(HttpStatusCode.OK, $"Loan application submitted for {application.Name}");
        }
    }
}
