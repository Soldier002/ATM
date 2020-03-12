namespace ATM.Interfaces.Application.Maintenance
{
    public interface IPrepareForOperatorAccessCommand
    {
        void Do();

        void Undo();
    }
}
