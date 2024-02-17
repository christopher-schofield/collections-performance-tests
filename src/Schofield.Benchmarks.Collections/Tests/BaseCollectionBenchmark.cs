using System;
using System.Diagnostics;
using System.Text;

namespace Schofield.Benchmarks.Collections.Tests;

public abstract class BaseCollectionBenchmark<T>
{
    protected StringBuilder sb = new StringBuilder();
    protected List<T> ListData = new();
    protected HashSet<T> HashSetData = new();
    protected T[]? ArrayData;
    protected List<T> LookupValues = new();

    protected string TestName { get; set; } = string.Empty;
    protected abstract void LoadData();

    public void Execute()
    {
        LoadData();
        TestListContains();
        TestListEquals();
        TestHashSetContains();
        TestHashSetEquals();
        TestArrayContains();
        TestArrayEquals();
        OutputResults(TestName);
    }

    protected void OutputResults(string testName)
    {
        Console.WriteLine($"{testName} Results");
        Console.WriteLine(sb.ToString());
    }

    private void AppendMessage(string functionName, int itemCount, int foundCount, long elapsedMilliseconds)
    {
		sb.AppendLine($"{functionName}[{itemCount}] found {foundCount} items in {elapsedMilliseconds} milliseconds");
	}

	protected void TestListEquals()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(w => ListData.Any(f => f.Equals(w))).ToList();
        sw.Stop();
		AppendMessage(nameof(TestListEquals), ListData.Count, found.Count, sw.ElapsedMilliseconds);
    }

    protected void TestListContains()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(ListData.Contains).ToList();
        sw.Stop();
		AppendMessage(nameof(TestListContains), ListData.Count, found.Count, sw.ElapsedMilliseconds);
	}

	protected void TestHashSetEquals()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(w => HashSetData.Any(f => f.Equals(w))).ToList();
        sw.Stop();
		AppendMessage(nameof(TestHashSetEquals), ListData.Count, found.Count, sw.ElapsedMilliseconds);
	}

	protected void TestHashSetContains()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(HashSetData.Contains).ToList();
        sw.Stop();
		AppendMessage(nameof(TestHashSetContains), ListData.Count, found.Count, sw.ElapsedMilliseconds);
	}

	protected void TestArrayEquals()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(w => ArrayData!.Any(f => f.Equals(w))).ToList();
        sw.Stop();
		AppendMessage(nameof(TestArrayEquals), ListData.Count, found.Count, sw.ElapsedMilliseconds);
	}

	protected void TestArrayContains()
    {
        var sw = Stopwatch.StartNew();
        var found = LookupValues.Where(ArrayData!.Contains).ToList();
        sw.Stop();
		AppendMessage(nameof(TestArrayContains), ListData.Count, found.Count, sw.ElapsedMilliseconds);
	}
}