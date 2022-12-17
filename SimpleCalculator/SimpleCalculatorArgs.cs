namespace SimpleCalculator
{
	public class SimpleCalculatorArgs : ISimpleCalculatorArgs
	{
		public string[] Args {get; private set;}

		public SimpleCalculatorArgs(string[] args)
		{
			Args = args;
		}
	}
}