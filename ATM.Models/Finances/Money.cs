using System.Collections.Generic;

namespace ATM.Models.Finances
{
    public struct Money
    {
        public int Amount => GetPaperNoteSum();

        public Dictionary<PaperNote, int> Notes { get; set; }

        private int GetPaperNoteSum()
        {
            var sum = 0;
            foreach (var kvp in Notes)
            {
                sum += kvp.Key.FaceValue * kvp.Value;
            }

            return sum;
        }
    }
}
