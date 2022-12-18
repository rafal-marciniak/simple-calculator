namespace SimpleCalculator.Core
{
	public class Register
	{
		public string Key { get; private set; }
		public decimal Value { get; set; }

		public Register(string key)
		{
			Key = key;
		}
	}
}
