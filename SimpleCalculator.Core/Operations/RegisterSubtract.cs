namespace SimpleCalculator.Core.Operations
{
    public class RegisterSubtract : IRegisterOperation
    {
        public void Apply(Register register)
        {
            _registerSimpleOperation.Apply(register);
        }

        public RegisterSubtract(IOperand operand)
        {
            _registerSimpleOperation = new RegisterSimpleOperation(operand, (currentValue, operandValue) => currentValue - operandValue);
        }

        private readonly IRegisterOperation _registerSimpleOperation;
    }
}
