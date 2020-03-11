using ATM.Application.Authorization.Exceptions;
using ATM.Interfaces.Application.Authorization;
using ATM.Interfaces.Application.Fees;
using ATM.Interfaces.Application.MoneyOperations.Bank;
using ATM.Interfaces.Application.MoneyOperations.PaperNotes;
using ATM.Models;
using System;
using System.Collections.Generic;

namespace ATM
{
    public class ATMachine : IATMachine
    {
        private readonly ICardReader _cardReader;
        private readonly ICardService _cardService;
        private readonly IFeeService _feeService;
        private readonly IPaperNoteDispenseAlgorithm _paperNoteDispenseAlgorithm;

        public ATMachine(ICardReader cardReader, ICardService cardService, IPaperNoteDispenseAlgorithm paperNoteDispenseAlgorithm, IFeeService feeService)
        {
            _cardReader = cardReader;
            _cardService = cardService;
            _paperNoteDispenseAlgorithm = paperNoteDispenseAlgorithm;
            _feeService = feeService;
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
            if (!_cardReader.IsCardInserted)
            {
                throw new CardNotInsertedException();
            }

            var cardBalance = _cardService.GetCardBalance(_cardReader.InsertedCardNumber);

            return cardBalance;
        }

        public void InsertCard(string cardNumber)
        {
            if (_cardReader.IsCardInserted)
            {
                throw new CardAlreadyInsertedException();
            }

            _cardReader.Insert(cardNumber);
        }

        public void LoadMoney(Money money)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fee> RetrieveChargedFees()
        {
            if (!_cardReader.IsCardInserted)
            {
                throw new CardNotInsertedException();
            }

            var fees = _feeService.GetAll(_cardReader.InsertedCardNumber);

            return fees;
        }

        public void ReturnCard()
        {
            if (!_cardReader.IsCardInserted)
            {
                throw new CardNotInsertedException();
            }

            _cardReader.Remove();
        }

        public Money WithdrawMoney(int amount)
        {
            if (!_cardReader.IsCardInserted)
            {
                throw new CardNotInsertedException();
            }
            
            var withdrawnMoney = _paperNoteDispenseAlgorithm.Dispense(amount);
            _cardService.Withdraw(_cardReader.InsertedCardNumber, amount);

            return withdrawnMoney;
        }
    }
}
