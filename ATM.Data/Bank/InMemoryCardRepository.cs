﻿using ATM.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;

namespace ATM.Data.Bank
{
    public class InMemoryCardRepository : ICardRepository
    {
        private static List<Card> cards = new List<Card>
        {
            new Card
            {
                CardNumber = "4000300020001000",
                Balance = 1000
            }
        };

        public Card Get(string cardNumber)
        {
            return cards.First(x => x.CardNumber == cardNumber);
        }
    }
}
