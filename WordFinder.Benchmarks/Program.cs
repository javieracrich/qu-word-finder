using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SmallMatrixWordFinderMemoryBenchmark>();
BenchmarkRunner.Run<BigMatrixWordFinderMemoryBenchmark>();
