using ATM.Models.Finances;

namespace ATM.Interfaces.Application.Maintenance
{
    public interface IATMMaintenance
    {
        bool IsATMOutOfService { get; }

        void LoadMoney(Money money);
    }
}
