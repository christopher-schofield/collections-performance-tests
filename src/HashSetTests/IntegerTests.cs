using System.Diagnostics;

namespace HashSetTests;

public class IntegerTests : BaseTests
{
	public readonly List<int> ListData = new();
	public readonly HashSet<int> HashSetData = new();
	public readonly List<int> LookupValues = new();
	public readonly int TestIterations;
	public readonly int MaxDataValue;
	public readonly int MaxLookupValue;

	public IntegerTests(int testIterations, int maxDataValue, int maxLookupValue)
	{
		TestIterations = testIterations;
		MaxDataValue = maxDataValue;
		MaxLookupValue = maxLookupValue;
	}

	public override void Execute()
	{
		LoadData();
		TestList();
		TestHashSet();
		OutputResults(nameof(IntegerTests));
	}

	private void LoadData()
	{
		var random = new Random();
		var countLookups = 0;
		for (var i = 0; i < TestIterations; i++)
		{
			var value = random.Next(0, MaxDataValue);
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