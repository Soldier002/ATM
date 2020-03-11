namespace ATM.Interfaces.Application.Authorization
{
    public interface ICardReader
    {
        bool IsCardInserted { get; }

        string CurrentCardNumber { get; }

        void Insert(string cardNumber);
    }
}
