namespace Schofield.Benchmarks.Collections.Tests;

public class StringBenchmark : BaseCollectionBenchmark<string>
{
    public readonly int TestIterations;
    public readonly int MaxLookupValue;

    public StringBenchmark(int testIterations, int maxLookupValue)
    {
        TestIterations = testIterations;
        MaxLookupValue = maxLookupValue;
        TestName = nameof(StringBenchmark);
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