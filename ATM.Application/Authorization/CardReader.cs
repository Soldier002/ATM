using ATM.Interfaces.Application.Authorization;

namespace ATM.Application.Authorization
{
    public class CardReader : ICardReader
    {
        private static string _currentCardNumber;

        public string CurrentCardNumber => _currentCardNumber;

        public bool IsCardInserted()
        {
            return _currentCardNumber != null;
        }

        public void Insert(string cardNumber)
        {
            _currentCardNumber = cardNumber;
        }
    }
}
