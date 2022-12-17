namespace SimpleCalculator.Core
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
