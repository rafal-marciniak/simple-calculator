namespace SimpleCalculator.Core.Operations
{
    public class ConstantOperand : IOperand
    {
        public decimal Value { get; private set; }

        public ConstantOperand(decimal value)
        {
            Value = value;
        }
    }
}
