namespace qu_word_finder;

public class MatrixFactory
{
    public static List<string> CreateMatrix(int rows, int columns, IEnumerable<string> words)
    {
        var matrix = new List<string>();
        for (var i = 0; i < rows; i++)
        {
            matrix.Add(CreateRandomString(columns));
        }

        //insert words into the matrix
        foreach (var word in words)
        {
            var random = new Random(420);
            var row = random.Next(0, rows);
            var column = random.Next(0, columns - word.Length);
            matrix[row] = matrix[row].Substring(0, column) + word + matrix[row].Substring(column + word.Length);
        }

        return matrix;
    }

    private static string CreateRandomString(int length)
    {
        var random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, length)
                       .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}

