namespace Schofield.Performance.Collections.Tests;

public class IntegerTests : BaseTests<int>
{
	public readonly int TestIterations;
	public readonly int MaxDataValue;
	public readonly int MaxLookupValue;

	public IntegerTests(int testIterations, int maxDataValue, int maxLookupValue)
	{
		TestIterations = testIterations;
		MaxDataValue = maxDataValue;
		MaxLookupValue = maxLookupValue;
		TestName = nameof(IntegerTests);
	}

	protected override void LoadData()
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
		ArrayData = ListData.ToArray();
	}
}