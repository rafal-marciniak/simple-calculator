namespace SimpleCalculator.Core
{
	public class ConstantOperand : IOperand
	{
		public decimal Value { get; private set; }

		internal ConstantOperand(decimal value)
		{
			Value = value;
		}
	}
}
