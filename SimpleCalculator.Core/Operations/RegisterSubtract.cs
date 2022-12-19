namespace SimpleCalculator.Core.Operations
{
    public class RegisterSubtract : RegisterBasicOperation
	{
		protected override decimal ApplyOperation(decimal registerValue, decimal operandValue)
			=> registerValue - operandValue;

		public RegisterSubtract(IOperand operand)
			: base(operand) { }
	}
}
