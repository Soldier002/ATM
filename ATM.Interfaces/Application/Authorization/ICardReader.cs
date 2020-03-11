namespace ATM.Interfaces.Application.Authorization
{
    public interface ICardReader
    {
        bool IsCardInserted();

        string CurrentCardNumber { get; }
    }
}
