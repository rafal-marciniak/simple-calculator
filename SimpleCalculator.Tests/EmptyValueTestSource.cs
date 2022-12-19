using System.Collections;

namespace SimpleCalculator.Tests
{
	public class EmptyValueTestSource : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
			yield return null;
			yield return string.Empty;
			yield return " ";
		}
	}
}
