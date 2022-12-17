namespace SimpleCalculator.Core
{
	public interface IRegistry
	{
		decimal CalculateRegisterValue(string registerKey);
		decimal GetRegisterValue(string registerKey);
		decimal SetRegisterValue(string registerKey, decimal value);
		void AppendRegisterChange(string registerKey, IRegisterChange registerChange);
	}
}
