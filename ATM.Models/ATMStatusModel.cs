using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class ATMStatusModel
    {
        public Money AvailableMoney { get; set; }

        public string InsertedCardNumber { get; set; }

        public bool OutOfService { get; set; }

        public bool AlarmEnabled { get; set; }
    }
}
