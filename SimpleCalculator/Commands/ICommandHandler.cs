namespace SimpleCalculator.Commands
{
    internal interface ICommandHandler
    {
        void Handle(string command);
    }
}