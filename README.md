# hashset-performance-tests
A C# project demonstrating the differences of lookup performance between `List<T>()` and `HashSet<T>()`.

# Run The Project
Just open in Visual Studio and hit F5 or click the Play button.

# Results
It's obvious from the results that a properly tuned `HasSet<T>()` will always outperform a `List<T>()` 
as shown in the output belwo from a sample run:

```
StringTests Results
List lookup time: 1000
HashSet lookup time: 0

StringTests Results
List lookup time: 101320
HashSet lookup time: 11

IntegerTests Results
List lookup time: 6
HashSet lookup time: 0

IntegerTests Results
List lookup time: 501
HashSet lookup time: 5

IntegerTests Results
List lookup time: 58889
HashSet lookup time: 61

StringTests Results
List lookup time: 275
HashSet lookup time: 0

StringTests Results
List lookup time: 32491
HashSet lookup time: 6
```