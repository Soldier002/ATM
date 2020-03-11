using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Data.Bank.Exceptions;
using ATM.Interfaces.Data.Bank;
using ATM.Interfaces.Application.Fees;

namespace ATM.Application.MoneyOperations.Bank
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IFeeFactory _feeFactory;
        private readonly IFeeRepository _feeRepository;
        private readonly IWithdrawalFeeCalculator _withdrawalFeeCalculator;

        public CardService(ICardRepository cardRepository, IWithdrawalFeeCalculator withdrawalFeeCalculator,
            IFeeRepository feeRepository, IFeeFactory feeFactory)
        {
            _cardRepository = cardRepository;
            _withdrawalFeeCalculator = withdrawalFeeCalculator;
            _feeRepository = feeRepository;
            _feeFactory = feeFactory;
        }

        public void Withdraw(string cardNumber, decimal amount)
        {
            var card = _cardRepository.Get(cardNumber);
            var feeAmount = _withdrawalFeeCalculator.Calculate(amount);
            var amountTotal = amount + feeAmount;
            if (card.Balance - amountTotal < 0)
            {
                throw new InsufficientFundsException();
            }

            card.Balance -= amountTotal;
            var fee = _feeFactory.Create(cardNumber, feeAmount);
            _feeRepository.Add(fee);
        }

        public decimal GetCardBalance(string cardNumber)
        {
            var card = _cardRepository.Get(cardNumber);

            return card.Balance;
        }

        public bool CardExists(string cardNumber)
        {
            var cardExists = _cardRepository.CardExists(cardNumber);

            return cardExists;
        }
    }
}
