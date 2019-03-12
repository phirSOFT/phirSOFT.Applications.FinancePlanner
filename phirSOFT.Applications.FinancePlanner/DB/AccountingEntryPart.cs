using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzplan.DB
{
    class AccountingEntryPart
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool AmountGuessed { get; set; }
        public string Title { get; set; }
    }

    class IntervalAccountingEntryPart : AccountingEntryPart
    {
        public Interval Interval { get; set; }
        public bool Renewable { get; set; }
        public DateTime? LastDate { get; set; }

    }
}
