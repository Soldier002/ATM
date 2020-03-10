using System;

namespace ATM
{
    public struct Fee
    {
        public string CardNumber { get; set;}

        public decimal WithdrawalFeeAmount { get; set; }

        public DateTime WithdrawalDate { get; set; }
    }
}
