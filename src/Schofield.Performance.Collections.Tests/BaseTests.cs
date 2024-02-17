using System.Diagnostics;
using System.Text;

namespace Schofield.Performance.Collections.Tests;

public abstract class BaseTests<T>
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

	protected void TestListEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => ListData.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestListEquals)}({ListData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}

	protected void TestListContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(ListData.Contains).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestListContains)}({ListData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}

	protected void TestHashSetEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => HashSetData.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestHashSetEquals)}({HashSetData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}

	protected void TestHashSetContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(HashSetData.Contains).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestHashSetContains)}({HashSetData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}

	protected void TestArrayEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => ArrayData!.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestArrayEquals)}({ListData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}

	protected void TestArrayContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(ArrayData!.Contains).ToList();
		sw.Stop();
		sb.AppendLine($"{nameof(TestArrayContains)}({ListData.Count}) found {found.Count} items in {sw.ElapsedMilliseconds} milliseconds");
	}
}