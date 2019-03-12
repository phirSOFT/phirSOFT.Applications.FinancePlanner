using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzplan.DB
{
    class AccountingEntry
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public Category Category { get; set; }
        public Collection<AccountingEntryPart> EntryParts { get; set; }

        public AccountingEntry()
        {
            EntryParts = new Collection<AccountingEntryPart>();

        }
    }
}
