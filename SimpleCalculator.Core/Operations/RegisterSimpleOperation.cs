namespace SimpleCalculator.Core.Operations
{
    internal class RegisterSimpleOperation : IRegisterOperation
    {
        public void Apply(Register register)
        {
            var newValue = _operationExpression(register.Value, _operand.Value);
            register.Value = newValue;
        }

        internal RegisterSimpleOperation(IOperand operand, Func<decimal, decimal, decimal> operationExpression)
        {
            _operand = operand;
            _operationExpression = operationExpression;
        }

        private readonly IOperand _operand;
        private readonly Func<decimal, decimal, decimal> _operationExpression;
    }
}
