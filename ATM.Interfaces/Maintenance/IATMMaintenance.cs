using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces.Maintenance
{
    public interface IATMMaintenance
    {
        bool IsATMOutOfService { get; }

        void LoadMoney(Money money);
    }
}
