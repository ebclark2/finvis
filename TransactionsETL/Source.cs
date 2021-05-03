using System;
using System.Collections.Generic;
using System.Text;

using InfluxDB.Client.Core;


namespace FinVis
{
    public enum Status
    {
        Pending,
        Posted
    }

    [Measurement("transaction")]
    public class Transaction {
        [Column("value")] public string Status { get; set; }
        [Column(IsTimestamp = true)] public DateTime Date { get; set; }
        [Column("value")] public string Description { get; set; }
        [Column("value")] public string Category { get; set; }
        [Column("value")] public double Amount { get; set; }
        [Column("value")] public string Account { get; set; }

        public override string ToString()
        {
            return "[status=" + this.Status + ", date=" + this.Date + ", description=" + this.Description + ", category=" + this.Category + ", amount=" + this.Amount + ", account=" + this.Account + "]";
        }
    }

    interface Source: IEnumerable<Transaction>
    {
    }
}
