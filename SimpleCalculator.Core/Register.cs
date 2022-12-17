namespace SimpleCalculator.Core
{
	internal class Register
	{
		internal string Key { get; private set; }
		internal decimal Value { get; set; }

		internal Register(string key)
		{
			Key = key;
		}
	}
}
