namespace Schofield.Benchmarks.Collections.Tests;

public class StringBenchmark : BaseCollectionBenchmark<string>
{
	public override string BenchmarkName => nameof(StringBenchmark);

	public StringBenchmark(int sizeOfCollectionToSearchIn, int sizeOfItemsToFind)
		: base(sizeOfCollectionToSearchIn, sizeOfItemsToFind) { }

	protected override void LoadData()
	{
		var countLookups = 0;
		for (var i = 0; i < SizeOfCollectionToSearchIn; i++)
		{
			var value = Guid.NewGuid().ToString();
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