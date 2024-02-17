# Enumerable Lookup Tests
A C# project demonstrating the differences of lookup performance between Lists, HashSets, and Arrays.

## Run The Project
Open in Visual Studio and hit F5.

## Results
The ObjectTests and StringTests were run with 10,000, 100,000, iterations
The IntegerTests were run with 10,000, 100,000, and 1,000,000 iterations

```
ObjectTests Results
TestListContains(10000) found 10000 items in 1043 milliseconds
TestListEquals(10000) found 10000 items in 1285 milliseconds
TestHashSetContains(10000) found 10000 items in 1 milliseconds
TestHashSetEquals(10000) found 10000 items in 1207 milliseconds
TestArrayContains(10000) found 10000 items in 605 milliseconds
TestArrayEquals(10000) found 10000 items in 967 milliseconds

ObjectTests Results
TestListContains(100000) found 100000 items in 92407 milliseconds
TestListEquals(100000) found 100000 items in 151470 milliseconds
TestHashSetContains(100000) found 100000 items in 12 milliseconds
TestHashSetEquals(100000) found 100000 items in 150186 milliseconds
TestArrayContains(100000) found 100000 items in 90987 milliseconds
TestArrayEquals(100000) found 100000 items in 128560 milliseconds

IntegerTests Results
TestListContains(10000) found 10000 items in 7 milliseconds
TestListEquals(10000) found 10000 items in 738 milliseconds
TestHashSetContains(10000) found 10000 items in 0 milliseconds
TestHashSetEquals(10000) found 10000 items in 787 milliseconds
TestArrayContains(10000) found 10000 items in 5 milliseconds
TestArrayEquals(10000) found 10000 items in 673 milliseconds

IntegerTests Results
TestListContains(100000) found 100000 items in 561 milliseconds
TestListEquals(100000) found 100000 items in 75314 milliseconds
TestHashSetContains(99947) found 100000 items in 2 milliseconds
TestHashSetEquals(99947) found 100000 items in 78718 milliseconds
TestArrayContains(100000) found 100000 items in 599 milliseconds
TestArrayEquals(100000) found 100000 items in 63900 milliseconds

StringTests Results
TestListContains(10000) found 10000 items in 284 milliseconds
TestListEquals(10000) found 10000 items in 785 milliseconds
TestHashSetContains(10000) found 10000 items in 2 milliseconds
TestHashSetEquals(10000) found 10000 items in 777 milliseconds
TestArrayContains(10000) found 10000 items in 197 milliseconds
TestArrayEquals(10000) found 10000 items in 532 milliseconds

StringTests Results
TestListContains(100000) found 100000 items in 27485 milliseconds
TestListEquals(100000) found 100000 items in 147624 milliseconds
TestHashSetContains(100000) found 100000 items in 6 milliseconds
TestHashSetEquals(100000) found 100000 items in 199309 milliseconds
TestArrayContains(100000) found 100000 items in 96228 milliseconds
TestArrayEquals(100000) found 100000 items in 159006 milliseconds
```

## Analysis
