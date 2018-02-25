using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LoanApplications
{
    public static class ProcessAcceptedApplications
    {
        [FunctionName("ProcessAcceptedApplications")]
        public static void Run([BlobTrigger("accepted-applications/{name}", Connection = "")]string applicationJson, 
            string name, TraceWriter log)
        {
            var application = JsonConvert.DeserializeObject<LoanApplication>(applicationJson);

            log.Info($"Processing accepted application blob trigger for \n Name: {application.Name} \nAge: {application.Age}");
        }
    }
}
