using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Financial_Record
{
    public class FinancialRecord
    {
        public int RecordId { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Profit { get; set; }
    }
}
