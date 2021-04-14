using System;
using System.IO;
using System.Threading.Tasks;
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
        public static async Task<string> Run([BlobTrigger("transactions/{name}", Connection = "storageConnectionString")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            string docdbConnectionString = Environment.GetEnvironmentVariable("cosmosdbConnectionString");
            if (docdbConnectionString == null)
            {
                throw new Exception("Missing DocumentDB connection string");
            }

            using (DocumentClient client = new DocumentClient(new Uri(docdbConnectionString), (string)null)) {
                Uri collectionLInk = UriFactory.CreateDocumentCollectionUri("db_id", "col_id");
                ResourceResponse<DocumentCollection> docCollectionRep = await client.ReadDocumentCollectionAsync(collectionLInk);
                if (docCollectionRep.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Error getting collection link: " + docCollectionRep);
                }

                Transaction t = new Transaction{ TransactionId = "foo" };

                ResourceResponse<Document> docRep = await client.CreateDocumentAsync(collectionLInk, t);
                    
                if (docRep.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Error creating document: " + docRep);
                }
            }

            return "good";
        }
    }
}
