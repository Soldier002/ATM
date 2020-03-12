namespace ATM.Models.Finances
{
    public struct PaperNote
    {
        public PaperNote(int faceValue)
        {
            FaceValue = faceValue;
        }

        public int FaceValue { get; }

        public override int GetHashCode()
        {
            return FaceValue;
        }

        public override bool Equals(object obj)
        {
            var paperNote = (PaperNote)obj;
            var result = paperNote.FaceValue == FaceValue;

            return result;
        }
    }
}