using System;
using System.IO;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace GenerateTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            BlobContainerClient bcc = new BlobContainerClient(new Uri("http://127.0.0.1:10000/devstoreaccount1/transactions?sv=2019-07-07&sr=c&sig=N2KQ7TEMEAB8c9Q4W%2BYRW82eCvTyHT%2Fg0%2Fr2dbmqPMQ%3D&se=2021-04-14T16%3A12%3A13Z&sp=rwdl"));
            BlobClient bc = bcc.GetBlobClient("newfile.txt");
            if(bc.Exists())
            {
                Azure.Response rep = bc.Delete();
                if(rep.Status/100 != 2)
                {
                    throw new Exception("Could not delete blob: " + rep);
                }
                Console.WriteLine("Blob deleted");
            }
            {
                Azure.Response<BlobContentInfo> rep = bc.Upload(new MemoryStream(Encoding.UTF8.GetBytes("foo")));
                if (rep.GetRawResponse().Status/100 != 2)
                {
                    throw new Exception("Could not upload blob: " + rep);
                }
                Console.WriteLine("Uploaded blob");
            }
        }
    }
}
