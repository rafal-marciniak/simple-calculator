namespace SimpleCalculator.Core.Operations
{
    public class RegisterAdd : IRegisterOperation
    {
        public void Apply(Register register)
        {
            _registerSimpleOperation.Apply(register);
        }

        public RegisterAdd(IOperand operand)
        {
            _registerSimpleOperation = new RegisterSimpleOperation(operand, (currentValue, operandValue) => currentValue + operandValue);
        }

        private readonly IRegisterOperation _registerSimpleOperation;
    }
}
