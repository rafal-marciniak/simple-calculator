namespace SimpleCalculator
{
	internal class ConsoleProxy : IConsoleProxy
	{
		public void WriteLine()
		{
			Console.WriteLine();
		}

		public void WriteLine(string value)
		{
			Console.WriteLine(value);
		}

		public void WriteLine(decimal value)
		{
			Console.WriteLine(value);
		}

		public void Clear()
		{
			Console.Clear();
		}
	}
}
