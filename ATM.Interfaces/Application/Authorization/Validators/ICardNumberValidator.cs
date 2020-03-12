namespace ATM.Interfaces.Application.Authorization.Validators
{
    public interface ICardNumberValidator
    {
        void Validate(string cardNumber);
    }
}
