using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinVis
{
    [TestClass]
    public class TestSourceTest
    {
        [TestMethod]
        public void VisualizeTestData()
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
