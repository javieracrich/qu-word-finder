using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using qu_word_finder;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80)]
public class BigMatrixWordFinderMemoryBenchmark
{
    private readonly List<string> _matrix;
    private readonly List<string> _words;
    private readonly WordFinder _wordFinder;
    private readonly OptimizedWordFinder _optimizedWordFinder;

    public BigMatrixWordFinderMemoryBenchmark()
    {
        _matrix = MatrixFactory.CreateMatrix(64, 64, ["javier", "acrich", "fullstackdev"]);
        _words = ["javier", "acrich", "fullstackdev", "php"];
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
