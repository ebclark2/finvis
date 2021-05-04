using System;
using System.Collections.Generic;


namespace FinVis
{
    public enum Status
    {
        Pending,
        Posted
    }

    public class Transaction {
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
        public string Account { get; set; }

        public override string ToString()
        {
            return "[status=" + this.Status + ", date=" + this.Date + ", description=" + this.Description + ", category=" + this.Category + ", amount=" + this.Amount + ", account=" + this.Account + "]";
        }
    }

    public interface Source: IEnumerable<Transaction>
    {
    }
}
