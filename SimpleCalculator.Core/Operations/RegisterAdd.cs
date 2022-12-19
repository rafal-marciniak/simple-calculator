namespace SimpleCalculator.Core.Operations
{
    public class RegisterAdd : RegisterBasicOperation
	{
		protected override decimal ApplyOperation(decimal registerValue, decimal operandValue)
			=> registerValue + operandValue;

		public RegisterAdd(IOperand operand)
			: base(operand) { }
    }
}
