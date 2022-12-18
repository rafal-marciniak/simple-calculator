using System.Collections;

namespace SimpleCalculator.Tests
{
	internal class EmptyValueTestSource : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
			yield return null;
			yield return string.Empty;
			yield return " ";
		}
	}
}
