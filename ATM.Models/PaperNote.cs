namespace ATM.Models
{
    public class PaperNote
    {
        public PaperNote(int faceValue)
        {
            FaceValue = faceValue;
        }

        public int FaceValue { get; }
    }
}