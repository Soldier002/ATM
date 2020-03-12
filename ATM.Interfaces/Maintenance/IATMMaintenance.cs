using ATM.Models;
using ATM.Models.Finances;

namespace ATM.Interfaces.Maintenance
{
    public interface IATMMaintenance
    {
        bool IsATMOutOfService { get; }

        void LoadMoney(Money money);
    }
}
