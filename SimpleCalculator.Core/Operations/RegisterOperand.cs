namespace SimpleCalculator.Core.Operations
{
    public class RegisterOperand : IOperand
    {
        public decimal Value => _registry.GetRegisterValue(_registerKey);

        public RegisterOperand(IRegistry registry, string registerKey)
        {
            _registry = registry;
            _registerKey = registerKey;
        }

        private readonly IRegistry _registry;
        private readonly string _registerKey;
    }
}
