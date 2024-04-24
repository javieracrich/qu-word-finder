# READ ME !!
In order to demonstrate the code optimizations I made 2 word finders:
1. WordFinder (used as a baseline in the benchmarks)
2. OptimizedWordFinder (optimized version)

## The solution has 3 projects.
1. WordFinder: A library with the WordFinder and OptimizedWordFinder classes
2. WordFinder.Benchmarks (A Console app with benchmarks that can be run to compare performance of the 2 wordfinders)
3. wordFinder.Tests (A Unit Test project)

## These are the optimizations I applied to the OptimizedWordFinder 
1. I'm converting the matrix to a list at the begginning of the method because accessing specific elements in a List is faster than acessing a specific element in an IEnumerable. This reduces the time complexity of the method.
2. I'm Using Distinct() on the wordstream parameter just in case there are duplicates. This reduces the number of iterations in the outer loop.
3. I'm using StringBuilder for the verticalWord variable for a more efficient string concatenations. Since strings are immutable in C# every time you concatenate a string a new string is created in memory and gives the GC more work to do.
4. I'm using TryGetValue for dictionary access: This is more efficient than the ContainsKey method followed by an indexer, as it only requires a single lookup in the dictionary.
5. I'm converting the wordstream list to a span collection for a faster for loop.																		
6. Also the *sealed* keyword was added to the OptimizedWordFinder class. This not only prevents the class from being inherited but also allows the JIT compiler to optimize the code and make it run faster.



## These are the benchmarks for a 5x5 matrix.

| Method        | Mean     | Error     | StdDev    | Ratio | Allocated | Alloc Ratio |
|-------------- |---------:|----------:|----------:|------:|----------:|------------:|
| Find          | 3.490 us | 0.0626 us | 0.0555 us |  1.00 |   5.59 KB |        1.00 |
| FindOptimized | 1.178 us | 0.0234 us | 0.0219 us |  0.34 |   3.54 KB |        0.63 |

## These are the benchmarks for a 64x64 matrix.

| Method        | Mean      | Error    | StdDev   | Ratio | Allocated  | Alloc Ratio |
|-------------- |----------:|---------:|---------:|------:|-----------:|------------:|
| Find          | 440.79 us | 8.554 us | 8.001 us |  1.00 | 1818.71 KB |        1.00 |
| FindOptimized |  50.49 us | 1.001 us | 1.112 us |  0.11 |  125.34 KB |        0.07 |


# CONCLUSION
From these results we can conclude:
- the optimized version runs in a 1/3 of the time and allocates 37% less memory in the small matrix 
- the optimized version runs in a 1/10 of the time and allocates 93% less memory in the big matrix.