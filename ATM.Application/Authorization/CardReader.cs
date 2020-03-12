using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.Authorization.Validators;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Data.ThisATMachine;
using System.Linq;

namespace ATM.Application.Authorization
{
    public class CardReader : ICardReader
    {
        private readonly ICardService _cardService;
        private readonly IThisATMachineState _thisATMachineState;
        private readonly ICardNumberValidator _cardNumberValidator;

        public CardReader(ICardService cardService, IThisATMachineState thisATMachineState, ICardNumberValidator cardNumberValidator)
        {
            _cardService = cardService;
            _thisATMachineState = thisATMachineState;
            _cardNumberValidator = cardNumberValidator;
        }

        public string InsertedCardNumber => _thisATMachineState.InsertedCardNumber;

        public bool IsCardInserted => InsertedCardNumber != null;

        public void Insert(string cardNumber)
        {
            _cardNumberValidator.Validate(cardNumber);
            if (!_cardService.CardExists(cardNumber))
            {
                throw new CardDoesNotExistException();
            }

            _thisATMachineState.InsertedCardNumber = cardNumber;
        }

        public void Remove()
        {
            _thisATMachineState.InsertedCardNumber = null;
        }
    }
}
