using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Data;
using ATM.Data.Bank.Exceptions;

namespace ATM.Application.MoneyOperations.Bank
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IWithdrawalFeeCalculator _withdrawalFeeCalculator;

        public CardService(ICardRepository cardRepository, IWithdrawalFeeCalculator withdrawalFeeCalculator)
        {
            _cardRepository = cardRepository;
            _withdrawalFeeCalculator = withdrawalFeeCalculator;
        }

        public void Withdraw(string cardNumber, decimal amount)
        {
            var card = _cardRepository.Get(cardNumber);
            var amountTotal = _withdrawalFeeCalculator.Calculate(amount) + amount;
            if (card.Balance - amountTotal < 0)
            {
                throw new InsufficientFundsException();
            }

            card.Balance -= amountTotal;
        }
    }
}
