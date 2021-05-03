using System;
using System.Collections.Generic;
using System.Text;

namespace FinVis
{
    public class TestSource : LinkedList<Transaction>, Source
    {
        public TestSource()
        {
            string[] categories = { "food", "entertainment", "utilities" };
            string[] accounts = { "checking", "savings" };


            DateTime date = DateTime.Now;
            for (int i = 0; i < 10; ++i) {
                this.AddLast(new Transaction { Date = date, Status = "enum...", Description = i.ToString(), Category = categories[i%categories.Length],
                    Amount = i, Account = accounts[i%accounts.Length]});
                date = date.AddDays(-1);
            }
        }
    }
}
