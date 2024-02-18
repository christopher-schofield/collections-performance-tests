using System.Diagnostics;
using System.Text;

namespace Schofield.Benchmarks.Collections.Tests;

public abstract class BaseCollectionBenchmark<T>
{
	public abstract string BenchmarkName { get; }
	public int SizeOfCollectionToSearchIn = 0;
	public int SizeOfItemsToFind = 0;

	protected StringBuilder sb = new StringBuilder();
	protected List<T> ListData = new();
	protected HashSet<T> HashSetData = new();
	protected T[]? ArrayData;
	protected List<T> LookupValues = new();

	public BaseCollectionBenchmark(int sizeOfCollectionToSearchIn, int sizeOfItemsToFind)
	{
		SizeOfCollectionToSearchIn = sizeOfCollectionToSearchIn;
		SizeOfItemsToFind = sizeOfItemsToFind;
		Validate();
	}

	protected abstract void LoadCollections();

	protected void Validate()
	{
		if (SizeOfCollectionToSearchIn <= 0 || SizeOfItemsToFind <= 0)
		{
			throw new ArgumentException($"{nameof(SizeOfCollectionToSearchIn)} and {nameof(SizeOfItemsToFind)} must be larger than 0");
		}
		if (SizeOfCollectionToSearchIn < SizeOfItemsToFind)
		{
			throw new ArgumentException($"{nameof(SizeOfCollectionToSearchIn)} cannot be larger than {nameof(SizeOfItemsToFind)}");
		}
	}

	public void Execute()
	{
		LoadCollections();

		var tasks = new List<Task>
		{
			Task.Factory.StartNew(ListContains),
			Task.Factory.StartNew(ListEquals),
			Task.Factory.StartNew(HashSetContains),
			Task.Factory.StartNew(HashSetEquals),
			Task.Factory.StartNew(ArrayContains),
			Task.Factory.StartNew(ArrayEquals)
		};
		Task.WaitAll(tasks.ToArray());

		OutputResults();
	}

	protected void OutputResults()
	{
		Console.WriteLine($"{BenchmarkName} Results");
		Console.WriteLine(sb.ToString());
	}

	private void AppendMessage(string functionName, int foundCount, int listItemCount, long elapsedMilliseconds)
	{
		sb.AppendLine($"{functionName} found {foundCount} items within {listItemCount} items in {elapsedMilliseconds} milliseconds");
	}

	protected void ListEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => ListData.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		AppendMessage(nameof(ListEquals), found.Count, ListData.Count, sw.ElapsedMilliseconds);
	}

	protected void ListContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(ListData.Contains).ToList();
		sw.Stop();
		AppendMessage(nameof(ListContains), found.Count, ListData.Count, sw.ElapsedMilliseconds);
	}

	protected void HashSetEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => HashSetData.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		AppendMessage(nameof(HashSetEquals), found.Count, HashSetData.Count, sw.ElapsedMilliseconds);
	}

	protected void HashSetContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(HashSetData.Contains).ToList();
		sw.Stop();
		AppendMessage(nameof(HashSetContains), found.Count, HashSetData.Count, sw.ElapsedMilliseconds);
	}

	protected void ArrayEquals()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(w => ArrayData!.Any(f => f.Equals(w))).ToList();
		sw.Stop();
		AppendMessage(nameof(ArrayEquals), found.Count, ArrayData!.Count(), sw.ElapsedMilliseconds);
	}

	protected void ArrayContains()
	{
		var sw = Stopwatch.StartNew();
		var found = LookupValues.Where(ArrayData!.Contains).ToList();
		sw.Stop();
		AppendMessage(nameof(ArrayContains), found.Count, ArrayData!.Count(), sw.ElapsedMilliseconds);
	}
}