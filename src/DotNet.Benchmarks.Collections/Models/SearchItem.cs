namespace DotNet.Benchmarks.Collections.Models;

public class SearchItem
{
	public required string Id { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }

	public override bool Equals(object? obj)
	{
		return obj is SearchItem item && Id.Equals(item.Id);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id);
	}
}

