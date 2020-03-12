using System;

namespace ATM.Models.Bank
{
    public struct Fee
    {
        public string CardNumber { get; set;}

        public decimal WithdrawalFeeAmount { get; set; }

        public DateTime WithdrawalDate { get; set; }
    }
}
