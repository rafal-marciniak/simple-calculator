namespace SimpleCalculator
{
	internal interface IConsoleProxy
    {
		void WriteLine();
		void WriteLine(string value);
		void WriteLine(decimal value);
		void Clear();
    }
}
