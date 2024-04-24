namespace qu_word_finder;

public class WordFinder
{
    private readonly IEnumerable<string> matrix ;
    public WordFinder(IEnumerable<string> matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);
        this.matrix = matrix;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        ArgumentNullException.ThrowIfNull(wordstream);

        var wordCount = new Dictionary<string, int>();
        foreach (var word in wordstream)
        {
            //check horizontally
            for (var i = 0; i < this.matrix.Count(); i++)
            {
                if (this.matrix.ElementAt(i).Contains(word))
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount.Add(word, 1);
                    }
                }
            }
            //check vertically
            for (var i = 0; i < this.matrix.Count(); i++)
            {
                var verticalWord = "";
                for (var j = 0; j < this.matrix.Count(); j++)
                {
                    verticalWord += this.matrix.ElementAt(j).Substring(i, 1);
                }
                if (verticalWord.Contains(word))
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount.Add(word, 1);
                    }
                }
            }
        }
        return wordCount.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key).ToList();
    }
}


