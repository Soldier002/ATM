using System.Collections.Generic;

namespace ATM.Models
{
    public struct Money
    {
        public Money(int amount)
        {
            Amount = amount;
            Notes = new Dictionary<PaperNote, int>();
        }

        public int Amount { get; set; }

        public Dictionary<PaperNote, int> Notes { get; set; }
    }
}
