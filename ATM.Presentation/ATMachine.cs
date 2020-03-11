using ATM.Application.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.MoneyOperations;
using ATM.Interfaces.Data;
using ATM.Models;
using System;
using System.Collections.Generic;

namespace ATM
{
    public class ATMachine : IATMachine
    {
        private readonly ICardReader _cardReader;
        private readonly IPaperNoteDispenseAlgorithm _paperNoteDispenseAlgorithm;
        private readonly IThisATMachineState _thisATMachineState;

        public ATMachine(ICardReader cardReader, IPaperNoteDispenseAlgorithm paperNoteDispenseAlgorithm, IThisATMachineState thisATMachineState)
        {
            _cardReader = cardReader;
            _paperNoteDispenseAlgorithm = paperNoteDispenseAlgorithm;
            _thisATMachineState = thisATMachineState;
        }

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
            if (!_cardReader.IsCardInserted())
            {
                throw new CardNotInsertedException();
            }
            
            var withdrawnMoney = _paperNoteDispenseAlgorithm.Dispense(amount, _thisATMachineState.AvailableMoney);

            return withdrawnMoney;
        }
    }
}
