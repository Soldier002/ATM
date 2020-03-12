using ATM.Models;

namespace ATM.Interfaces.Maintenance
{
    public interface IATMMaintenance
    {
        bool IsATMOutOfService { get; }

        void LoadMoney(Money money);
    }
}
