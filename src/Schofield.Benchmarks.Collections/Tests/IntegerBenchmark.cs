namespace Schofield.Benchmarks.Collections.Tests;

public class IntegerBenchmark : BaseCollectionBenchmark<int>
{
    public readonly int TestIterations;
    public readonly int MaxDataValue;
    public readonly int MaxLookupValue;

    public IntegerBenchmark(int testIterations, int maxDataValue, int maxLookupValue)
    {
        TestIterations = testIterations;
        MaxDataValue = maxDataValue;
        MaxLookupValue = maxLookupValue;
        TestName = nameof(IntegerBenchmark);
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