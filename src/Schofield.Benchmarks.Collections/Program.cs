using Schofield.Benchmarks.Collections.Tests;



new ObjectBenchmark(100000, 10000).Execute();
new ObjectBenchmark(1000000, 25000).Execute();
//This takes a while
new ObjectBenchmark(10000000, 50000).Execute();

new IntegerBenchmark(1000000, 10000, 100000000).Execute();
new IntegerBenchmark(10000000, 25000, 100000000).Execute();
new IntegerBenchmark(100000000, 50000, 100000000).Execute();

new StringBenchmark(100000, 10000).Execute();
new StringBenchmark(1000000, 25000).Execute();
//This takes a while
new StringBenchmark(10000000, 50000).Execute();