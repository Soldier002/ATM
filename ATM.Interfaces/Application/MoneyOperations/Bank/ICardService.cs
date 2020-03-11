namespace ATM.Interfaces.Application.MoneyOperations.Bank
{
    public interface ICardService
    {
        void Withdraw(string cardNumber, decimal amount);
    }
}
