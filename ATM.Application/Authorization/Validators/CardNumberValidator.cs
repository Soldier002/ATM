using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization.Validators;
using System.Linq;

namespace ATM.Application.Authorization.Validators
{
    public class CardNumberValidator : ICardNumberValidator
    {
        private const int digitsInCardNumber = 16;

        public void Validate(string cardNumber)
        {
            if (!(cardNumber.Count() == digitsInCardNumber && cardNumber.All(x => char.IsDigit(x))))
            {
                throw new InvalidCardNumberException();
            }
        }
    }
}
