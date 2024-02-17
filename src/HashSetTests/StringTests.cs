namespace HashSetTests;

public class StringTests : BaseTests<string>
{
	public readonly int TestIterations;
	public readonly int MaxLookupValue;

	public StringTests(int testIterations, int maxLookupValue)
	{
		TestIterations = testIterations;
		MaxLookupValue = maxLookupValue;
		TestName = nameof(StringTests);
	}

	protected override void LoadData()
	{
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
		ArrayData = ListData.ToArray();
	}
}