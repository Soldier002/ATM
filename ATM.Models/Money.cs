using System.Collections.Generic;

namespace ATM
{
    public struct Money
    {
        public int Amount { get; set; }

        public Dictionary<PaperNote, int> Notes { get; set; }
    }
}
