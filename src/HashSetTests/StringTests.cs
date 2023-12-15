using System.Diagnostics;

namespace HashSetTests;

public class StringTests : BaseTests
{
	public readonly List<string> ListData = new();
	public readonly HashSet<string> HashSetData = new();
	public readonly List<string> LookupValues = new();
	public readonly int TestIterations;
	public readonly int MaxLookupValue;

	public StringTests(int testIterations, int maxLookupValue)
	{
		TestIterations = testIterations;
		MaxLookupValue = maxLookupValue;
	}

	public override void Execute()
	{
		LoadData();
		TestList();
		TestHashSet();
		OutputResults(nameof(StringTests));
	}

	private void LoadData()
	{
		var random = new Random();
		var countLookups = 0;
		for (var i = 0; i < TestIterations; i++)
		{
			var value = Guid.NewGuid().ToString();
			ListData.Add(value);
			HashSetData.Add(value);
			if (++countLookups <= MaxLookupValue)
			{
				LookupValues.Add(value);
			}
		}
	}

	private void TestList()
	{
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		var count = 0;
		foreach (var i in LookupValues)
		{
			count++;
			var listFound = ListData.Contains(i);
		}
		stopWatch.Stop();
		sb.AppendLine($"List lookup time: {stopWatch.ElapsedMilliseconds}");
	}

	private void TestHashSet()
	{
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		var count = 0;
		foreach (var i in LookupValues)
		{
			count++;
			var hashSetFound = HashSetData.Contains(i);
		}
		stopWatch.Stop();
		sb.AppendLine($"HashSet lookup time: {stopWatch.ElapsedMilliseconds}");
	}
}