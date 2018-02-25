using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LoanApplications
{
    public static class ScoreApplication
    {
        [FunctionName("ScoreApplication")]
        public static void Run([QueueTrigger("loan-applications", Connection = "")]
            LoanApplication application,
            [Blob("accepted-applications/{rand-guid}", Connection = "")] out string acceptedApplication,
            [Blob("declined-applications/{rand-guid}", Connection = "")] out string declinedApplication,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {application.Name}");

            var isAccepted = application.Age >= 18;

            if (isAccepted)
            {
                acceptedApplication = JsonConvert.SerializeObject(application);
                declinedApplication = null;
            }
            else
            {
                acceptedApplication = null;
                declinedApplication = JsonConvert.SerializeObject(application); 
            }
        }
    }
}
