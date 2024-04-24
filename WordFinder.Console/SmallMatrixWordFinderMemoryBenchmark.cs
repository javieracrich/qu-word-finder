using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using qu_word_finder;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80)]
public class SmallMatrixWordFinderMemoryBenchmark
{
    private readonly List<string> _matrix;
    private readonly List<string> _words;
    private readonly WordFinder _wordFinder;
    private readonly OptimizedWordFinder _optimizedWordFinder;

    public SmallMatrixWordFinderMemoryBenchmark()
    {
        _matrix =
                [
                    "abcdc",
                    "fgwio",
                    "chill",
                    "pqnsd",
                    "uvdxy"
                ];
        _words = ["chill", "cold", "wind", "snow"];
        _wordFinder = new WordFinder(_matrix);
        _optimizedWordFinder = new OptimizedWordFinder(_matrix);
    }

    [Benchmark(Baseline = true)]
    public void Find()
    {
        _wordFinder.Find(_words);
    }

    [Benchmark]
    public void FindOptimized()
    {
        _optimizedWordFinder.Find(_words);
    }
}
