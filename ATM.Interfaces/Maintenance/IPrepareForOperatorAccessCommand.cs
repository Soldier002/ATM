namespace ATM.Interfaces.Maintenance
{
    public interface IPrepareForOperatorAccessCommand
    {
        void Do();

        void Undo();
    }
}
