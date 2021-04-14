using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;



namespace TransactionsETL
{

    public static class Function1
    {
        private class Transaction
        {
            public string TransactionId { get; set;}
        }

        [FunctionName("Function1")]
        public static void Run([BlobTrigger("transactions/{name}", Connection = "storageConnectionString")]Stream myBlob,
            [CosmosDB(
    databaseName: "finvisdb",
    collectionName: "transactions",
    ConnectionStringSetting = "cosmosdbConnectionString")]ICollector<dynamic> documentsOut,
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            Transaction t = new Transaction { TransactionId = name };
            documentsOut.Add(t);
        }
    }
}
