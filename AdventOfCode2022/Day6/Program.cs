using SharedUtilities;

var puzzle = FileReader.ReadFile().ToArray()[0];

var result = 0;

// i was superlazy this time. this is part 2 only
for (int i = 14; i < puzzle.Length; i++)
{
    var substring = puzzle.Substring(i - 14, 14);
    var sorted = new string(substring.OrderBy(x => x).ToArray());

    if (sorted[0] != sorted[1] &&
        sorted[1] != sorted[2] &&
        sorted[2] != sorted[3] &&
        sorted[3] != sorted[4] &&
        sorted[4] != sorted[5] && 
        sorted[5] != sorted[6] && 
        sorted[6] != sorted[7] && 
        sorted[7] != sorted[8] && 
        sorted[8] != sorted[9] && 
        sorted[9] != sorted[10]&& 
        sorted[10] != sorted[11]&& 
        sorted[11] != sorted[12]&&
        sorted[12] != sorted[13]
        )
    {
        result = i + 1;
        break;
    }
}

Console.WriteLine(result);

int x = 0;