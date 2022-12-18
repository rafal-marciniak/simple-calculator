namespace SimpleCalculator
{
	internal class SimpleCalculatorArgs : ISimpleCalculatorArgs
	{
		public string[] Args { get; private set;}

		internal SimpleCalculatorArgs(string[] args)
		{
			Args = args;
		}
	}
}