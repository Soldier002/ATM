using System;
using System.Collections.Generic;

namespace ATM
{
    public class ATMachine : IATMachine
    {
        public string Manufacturer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SerialNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal GetCardBalance()
        {
            throw new NotImplementedException();
        }

        public void InsertCard(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public void LoadMoney(Money money)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fee> RetrieveChargedFees()
        {
            throw new NotImplementedException();
        }

        public void ReturnCard()
        {
            throw new NotImplementedException();
        }

        public Money WithdrawMoney(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
