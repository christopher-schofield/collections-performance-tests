using System.Diagnostics;

namespace HashSetTests;

public class ObjectTests : BaseTests
{
	public readonly List<SearchItem> ListData = new();
	public readonly HashSet<SearchItem> HashSetData = new();
	public readonly List<SearchItem> LookupValues = new();
	public readonly int TestIterations;
	public readonly int MaxLookupValue;

	public ObjectTests(int testIterations, int maxLookupValue)
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
			var id = Guid.NewGuid().ToString();
			var searchItem = new SearchItem
			{
				Id = id,
				Name = id.Substring(0, 8),
				Description = id.Substring(0, 16)
			};
			
			ListData.Add(searchItem);
			HashSetData.Add(searchItem);
			if (++countLookups <= MaxLookupValue)
			{
				LookupValues.Add(searchItem);
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