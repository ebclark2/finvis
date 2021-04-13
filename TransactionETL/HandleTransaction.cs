using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TransactionETL
{
    public static class HandleTransaction
    {
        [FunctionName("HandleTransaction")]
        public static void Run([BlobTrigger("transactions/{name}", Connection = "finvisStorageConnectionString")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
