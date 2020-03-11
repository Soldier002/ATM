namespace ATM.Interfaces.Application.Authorization
{
    public interface ICardReader
    {
        bool IsCardInserted { get; }

        string InsertedCardNumber { get; }

        void Insert(string cardNumber);

        void Remove();
    }
}
