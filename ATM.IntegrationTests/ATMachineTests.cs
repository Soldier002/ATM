using System.Collections.Generic;
using NUnit.Framework;
using StructureMap;
using ATM.Interfaces.Data.Bank;
using ATM.Data.Bank;
using ATM.Interfaces.Data.ThisATMachine;
using ATM.Data.ThisATMachine;
using ATM.Interfaces.Configuration;
using ATM.Application.Configuration;
using System.Linq;
using ATM.Application.Authorization.Exceptions;
using ATM.Models.Finances;

namespace ATM.IntegrationTests
{
    [TestFixture]
    public class ATMachineTests
    {
        [Test]
        public void BasicUserFlow()
        {
            var atMachine = BuildATMachine();

            var money = new Money
            {
                Notes = new Dictionary<PaperNote, int>
                {
                    { new PaperNote(50), 10 },
                    { new PaperNote(20), 10 },
                    { new PaperNote(10), 10 },
                    { new PaperNote(5), 10 }
                }
            };

            atMachine.LoadMoney(money);

            atMachine.InsertCard("4000300020001000");

            var withdrawnMoney = atMachine.WithdrawMoney(100);
            var withdrawnMoneyTwo = atMachine.WithdrawMoney(75);

            var cardBalanceAfterWithdraw = atMachine.GetCardBalance();
            Assert.AreEqual(823.25, cardBalanceAfterWithdraw);

            var fees = atMachine.RetrieveChargedFees();
            Assert.AreEqual(2, fees.Count());

            atMachine.ReturnCard();
            Assert.Throws<CardNotInsertedException>(() => atMachine.WithdrawMoney(10000));
        }
        
        private ATMachine BuildATMachine()
        {
            var registry = new Registry();
            registry.Scan(_ =>
            {
                _.Assembly("ATM.Application");
                _.Assembly("ATM.Data");
                _.WithDefaultConventions();
            });

            var container = new Container(registry);
            container.Configure(_ =>
            {
                _.For<ICardRepository>().Use<InMemoryCardRepository>();
                _.For<IFeeRepository>().Use<InMemoryFeeRepository>();
                _.For<IThisATMachineState>().Use<InMemoryThisATMachineState>();
                _.For<IConfiguration>().Use<InMemoryConfiguration>();
            });

            var atMachine = container.GetInstance<ATMachine>();

            return atMachine;
        }
    }
}
