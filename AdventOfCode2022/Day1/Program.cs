using SharedUtilities;

var puzzle = FileReader.ReadFile();

Console.WriteLine(GetMax());
var resultsPerElf = GetEach();
Console.WriteLine(GetMaxResOfElves(resultsPerElf, 3));

int GetMax()
{
    int maxRes = 0;
    int currentCounter = 0;

    foreach (var line in puzzle)
    {
        if (line.Length == 0)
        {
            if (currentCounter > maxRes)
            {
                maxRes = currentCounter;
            }

            currentCounter = 0;
        }
        else currentCounter += int.Parse(line);
    }

    return maxRes;
}

List<int> GetEach()
{
    var list = new List<int>();
    int currentCounter = 0;

    foreach (var line in puzzle)
    {
        if (line.Length == 0)
        {
            list.Add(currentCounter);

            currentCounter = 0;
        }
        else currentCounter += int.Parse(line);
    }

    return list;
}

int GetMaxResOfElves(List<int> list, int recordsToSum)
{
    list.Sort();
    list.Reverse();

    var res = 0;

    for (int i = 0; i < recordsToSum; i++)
    {
        res += list[i];
    }

    return res;
}