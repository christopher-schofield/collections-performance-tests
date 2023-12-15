using System.Text;

namespace HashSetTests;

public abstract class BaseTests
{
	protected StringBuilder sb = new StringBuilder();

	public abstract void Execute();

	protected void OutputResults(string testName)
	{
		Console.WriteLine($"{testName} Results");
		Console.WriteLine(sb.ToString());
	}
}