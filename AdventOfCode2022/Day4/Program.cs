using SharedUtilities;

var puzzle = FileReader.ReadFile();

var score = 0;
var score2 = 0;

foreach (var line in puzzle)
{
    int[] result = new int[1000];
    clearTable(result);

    if (checkIfThereIsOverlap(line)) score++;
    if (checkIfThereIsAnyOverlap(line)) score2++;
}

Console.WriteLine(score);
Console.WriteLine(score2);

void clearTable(int[] tab) {
    for (int i = 0; i < tab.Length; i++)
    {
        tab[i] = 0;
    }
}

bool checkIfThereIsOverlap(string line)
{
    int firstFrom = int.Parse(line.Split(',')[0].Split('-')[0]);
    int firstTo = int.Parse(line.Split(',')[0].Split('-')[1]);

    int secondFrom = int.Parse(line.Split(',')[1].Split('-')[0]);
    int secondTo = int.Parse(line.Split(',')[1].Split('-')[1]);


    if (firstFrom >= secondFrom && firstTo <= secondTo) return true;
    if (secondFrom >= firstFrom && secondTo <= firstTo) return true;

    return false;
}

bool checkIfThereIsAnyOverlap(string line)
{
    int firstFrom = int.Parse(line.Split(',')[0].Split('-')[0]);
    int firstTo = int.Parse(line.Split(',')[0].Split('-')[1]);

    int secondFrom = int.Parse(line.Split(',')[1].Split('-')[0]);
    int secondTo = int.Parse(line.Split(',')[1].Split('-')[1]);


    for (int i = firstFrom; i <= firstTo; i++)
    {
        if (i >= secondFrom && i <= secondTo) return true;
    }

    for (int i = secondFrom; i <= secondTo; i++)
    {
        if (i >= firstFrom && i <= firstTo) return true;
    }

    return false;
}