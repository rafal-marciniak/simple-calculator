namespace SimpleCalculator.Core.Operations
{
    public class RegisterMultiply : RegisterBasicOperation
	{
		protected override decimal ApplyOperation(decimal registerValue, decimal operandValue)
			=> registerValue * operandValue;

		public RegisterMultiply(IOperand operand)
			: base(operand) { }
	}
}
