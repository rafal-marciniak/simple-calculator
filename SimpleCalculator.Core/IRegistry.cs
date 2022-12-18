using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core
{
    public interface IRegistry
	{
		decimal GetRegisterValue(string registerKey);
		void AppendRegisterChange(string registerKey, IRegisterOperation registerChange);
	}
}
