using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace FinVis
{

    class BOASource : Source
    {
        private static Dictionary<string, string> _headerMapping = new Dictionary<string, string>()
        {
            //{ "Status", "bar" },
            //{ "Date", "bar" },
            { "Original Description", "Description" },
            //{ "Category", "bar" },
            //{ "Amount", "bar" },
            { "Account Name", "Account" }
        };

        private CsvReader _csvReader;
        private IEnumerable<Transaction> _transactions;

        public BOASource(string filename)
        {
            this.LoadFile(filename);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return this._transactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._transactions.GetEnumerator();
        }

        private void LoadFile(string filename)
        {
            CsvConfiguration csvConfig = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => _headerMapping.GetValueOrDefault(args.Header, args.Header).Trim()
            };
            TextReader reader = new StreamReader(filename);
            _csvReader = new CsvReader(reader, csvConfig);
            _transactions = _csvReader.GetRecords<Transaction>();
        }

    }
}
