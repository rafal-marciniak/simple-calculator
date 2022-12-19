namespace SimpleCalculator.Core.Operations
{
    public abstract class RegisterBasicOperation : IRegisterOperation
    {
        public void Apply(Register register)
        {
            var newValue = ApplyOperation(register.Value, _operand.Value);
            register.Value = newValue;
        }

        protected abstract decimal ApplyOperation(decimal registerValue, decimal operandValue);

        protected RegisterBasicOperation(IOperand operand)
        {
            _operand = operand;
        }

        private readonly IOperand _operand;
    }
}
