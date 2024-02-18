# Schofield.Benchmarks.Collections

Return to [Schofield Benchmarking](../../README.md)

A C# project demonstrating the lookup performance between Lists, HashSets, and Arrays using `Contains()` and `Equals()`.

## Results
Because of the multi-tasking code, the results are added to the output in order of fastest to slowest.

```
ObjectBenchmark Results
HashSetContains found 10000 items within 100000 items in 39 milliseconds
ListContains found 10000 items within 100000 items in 1449 milliseconds
ArrayContains found 10000 items within 100000 items in 1453 milliseconds
ArrayEquals found 10000 items within 100000 items in 1841 milliseconds
HashSetEquals found 10000 items within 100000 items in 2126 milliseconds
ListEquals found 10000 items within 100000 items in 2178 milliseconds

ObjectBenchmark Results
HashSetContains found 25000 items within 1000000 items in 6 milliseconds
ArrayContains found 25000 items within 1000000 items in 5123 milliseconds
ListContains found 25000 items within 1000000 items in 5239 milliseconds
ArrayEquals found 25000 items within 1000000 items in 7592 milliseconds
HashSetEquals found 25000 items within 1000000 items in 8889 milliseconds
ListEquals found 25000 items within 1000000 items in 9158 milliseconds

ObjectBenchmark Results
HashSetContains found 50000 items within 10000000 items in 13 milliseconds
ArrayContains found 50000 items within 10000000 items in 25444 milliseconds
ListContains found 50000 items within 10000000 items in 26054 milliseconds
ArrayEquals found 50000 items within 10000000 items in 35951 milliseconds
HashSetEquals found 50000 items within 10000000 items in 41160 milliseconds
ListEquals found 50000 items within 10000000 items in 41786 milliseconds

IntegerBenchmark Results
HashSetContains found 10000 items within 995110 items in 43 milliseconds
ArrayContains found 10000 items within 1000000 items in 48 milliseconds
ListContains found 10000 items within 1000000 items in 51 milliseconds
ArrayEquals found 10000 items within 1000000 items in 946 milliseconds
ListEquals found 10000 items within 1000000 items in 1081 milliseconds
HashSetEquals found 10000 items within 995110 items in 1104 milliseconds

IntegerBenchmark Results
HashSetContains found 25000 items within 9516104 items in 7 milliseconds
ArrayContains found 25000 items within 10000000 items in 57 milliseconds
ListContains found 25000 items within 10000000 items in 70 milliseconds
ArrayEquals found 25000 items within 10000000 items in 5733 milliseconds
ListEquals found 25000 items within 10000000 items in 6572 milliseconds
HashSetEquals found 25000 items within 9516104 items in 6713 milliseconds

IntegerBenchmark Results
HashSetContains found 50000 items within 63213347 items in 78 milliseconds
ArrayContains found 50000 items within 100000000 items in 242 milliseconds
ListContains found 50000 items within 100000000 items in 391 milliseconds
ArrayEquals found 50000 items within 100000000 items in 22861 milliseconds
ListEquals found 50000 items within 100000000 items in 26904 milliseconds
HashSetEquals found 50000 items within 63213347 items in 27673 milliseconds

StringBenchmark Results
HashSetContains found 10000 items within 100000 items in 26 milliseconds
ListContains found 10000 items within 100000 items in 319 milliseconds
ArrayContains found 10000 items within 100000 items in 325 milliseconds
ArrayEquals found 10000 items within 100000 items in 712 milliseconds
ListEquals found 10000 items within 100000 items in 1016 milliseconds
HashSetEquals found 10000 items within 100000 items in 1007 milliseconds

StringBenchmark Results
HashSetContains found 25000 items within 1000000 items in 24 milliseconds
ListContains found 25000 items within 1000000 items in 1761 milliseconds
ArrayContains found 25000 items within 1000000 items in 1817 milliseconds
ArrayEquals found 25000 items within 1000000 items in 4266 milliseconds
HashSetEquals found 25000 items within 1000000 items in 5916 milliseconds
ListEquals found 25000 items within 1000000 items in 5952 milliseconds

StringBenchmark Results
HashSetContains found 50000 items within 10000000 items in 11 milliseconds
ListContains found 50000 items within 10000000 items in 7338 milliseconds
ArrayContains found 50000 items within 10000000 items in 7549 milliseconds
ArrayEquals found 50000 items within 10000000 items in 18054 milliseconds
ListEquals found 50000 items within 10000000 items in 24641 milliseconds
HashSetEquals found 50000 items within 10000000 items in 24976 milliseconds
```

## Analysis
1. While C# arrays do not implement collections, they are included in this benchmark as quasi-baseline.
1. For most lookups using the `Contains()` method, the HashSet type provides the fastest lookups.
1. Lookup performance of a HashSet of type class is dependent on how the `Equals()` and `GetHashCode()` methods are implemented.
1. Overall lookup performance for non-HashSets is dependent upon the number of items in the collection to be searched. In general, the more items in the collection, the slower the performance.
1. The type of an object in a List or HashSet will vary performance results. For example, integer lookup performance is much faster than string or object lookup performance.