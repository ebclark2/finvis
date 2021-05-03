using System;

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;

namespace FinVis
{
    class Program
    {
        static void Main(string[] args)
        {
            InfluxDBClient influxDBClient = InfluxDBClientFactory.Create("http://localhost:8086", "test");

            Source source = new BOASource("C:\\Users\\B\\Downloads\\ExportData.csv");
            using (var writeApi = influxDBClient.GetWriteApi())
            {
                foreach (Transaction t in source)
                {
                    t.Date = TimeZoneInfo.ConvertTimeToUtc(t.Date);
//                    Console.WriteLine(t);

                    writeApi.WriteMeasurement("bucket", "org", WritePrecision.Ns, t);
                }
            }
        }
    }
}
