namespace Schofield.Performance.Collections.Tests;

public class ObjectTests : BaseTests<SearchItem>
{
	public readonly int TestIterations;
	public readonly int MaxLookupValue;

	public ObjectTests(int testIterations, int maxLookupValue)
	{
		TestIterations = testIterations;
		MaxLookupValue = maxLookupValue;
		TestName = nameof(ObjectTests);
	}

	protected override void LoadData()
	{
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
		ArrayData = ListData.ToArray();
	}
}