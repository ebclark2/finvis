using System;

namespace FinVis
{
    class Program
    {
        static void Main(string[] args)
        {
            Source source = new TestSource();
            {
                foreach (Transaction t in source)
                {
                    t.Date = TimeZoneInfo.ConvertTimeToUtc(t.Date);
                    Console.WriteLine(t);
                }
            }
        }
    }
}
