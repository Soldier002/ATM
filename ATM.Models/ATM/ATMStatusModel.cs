using ATM.Models.Finances;

namespace ATM.Models.ATM
{
    public class ATMStatusModel
    {
        public Money AvailableMoney { get; set; }

        public string InsertedCardNumber { get; set; }

        public bool OutOfService { get; set; }

        public bool AlarmEnabled { get; set; }
    }
}
