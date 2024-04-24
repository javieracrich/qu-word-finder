using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace qu_word_finder;

public sealed class OptimizedWordFinder(IEnumerable<string> matrix)
{
    private readonly IEnumerable<string> matrix = matrix;

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var wordCount = new Dictionary<string, int>();
        var matrixList = this.matrix.ToList();
        var matrixCount = matrixList.Count;
        var wordsSpan = CollectionsMarshal.AsSpan(wordstream.Distinct().ToList());
        ref var wordsReference = ref MemoryMarshal.GetReference(wordsSpan);

        for (int x = 0; x < wordsSpan.Length; x++)
        {
            var word = Unsafe.Add(ref wordsReference, x);
            for (var y = 0; y < matrixCount; y++)
            {
                //check horizontally
                if (matrixList[y].Contains(word, StringComparison.Ordinal))
                {
                    wordCount.TryGetValue(word, out var count);
                    wordCount[word] = count + 1;
                }

                //check vertically
                var verticalWord = new StringBuilder();
                for (var z = 0; z < matrixCount; z++)
                {
                    verticalWord.Append(matrixList[z][y]);
                }

                if (verticalWord.ToString().Contains(word, StringComparison.Ordinal))
                {
                    wordCount.TryGetValue(word, out var count);
                    wordCount[word] = count + 1;
                }
            }
        }

        return wordCount.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
    }
}


