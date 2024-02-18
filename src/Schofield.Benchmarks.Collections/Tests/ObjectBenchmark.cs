using Schofield.Benchmarks.Collections.Models;

namespace Schofield.Benchmarks.Collections.Tests;

public class ObjectBenchmark : BaseCollectionBenchmark<SearchItem>
{
	public override string BenchmarkName => nameof(ObjectBenchmark);

	public ObjectBenchmark(int sizeOfCollectionToSearchIn, int sizeOfItemsToFind)
		: base(sizeOfCollectionToSearchIn, sizeOfItemsToFind) { }

	protected override void LoadData()
	{
		var countLookups = 0;
		for (var i = 0; i < SizeOfCollectionToSearchIn; i++)
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
			if (++countLookups <= SizeOfItemsToFind)
			{
				LookupValues.Add(searchItem);
			}
		}
		ArrayData = ListData.ToArray();
	}
}