namespace DotNet.Benchmarks.Collections.Tests;

public class IntegerBenchmark : BaseCollectionBenchmark<int>
{
	public override string BenchmarkName => nameof(IntegerBenchmark);
	public readonly int MaxIntegerValue;

	public IntegerBenchmark(int sizeOfCollectionToSearchIn, int sizeOfItemsToFind, int maxIntegerValue)
		: base(sizeOfCollectionToSearchIn, sizeOfItemsToFind)
	{
		MaxIntegerValue = maxIntegerValue;
	}

	protected override void LoadCollections()
	{
		var random = new Random();
		var countLookups = 0;
		for (var i = 0; i < SizeOfCollectionToSearchIn; i++)
		{
			var value = random.Next(0, MaxIntegerValue);
			ListData.Add(value);
			HashSetData.Add(value);
			if (++countLookups <= SizeOfItemsToFind)
			{
				LookupValues.Add(value);
			}
		}
		ArrayData = ListData.ToArray();
	}
}