using SharedUtilities;

var puzzle = FileReader.ReadFile();

string path = "/";

Dictionary<string, int> fileSizesInFolder = new();
List<string> pathsHistory = new List<string>();

bool startedReadingLs = false;
int parseRes = 0;

foreach (var line in puzzle)
{
    if(startedReadingLs)
    {
        var valueToParse = line.Split(" ")[0];
        // if its a hit
        if (int.TryParse(valueToParse, out parseRes))
        {
            //if such key does not exist in dictionary
            if(!fileSizesInFolder.TryGetValue(path, out _))
            {
                //add path and value to dictionary
                fileSizesInFolder.Add(path, parseRes);
            } else
            {
                // if this place was visited already we do not want to repeat
                if (pathsHistory.FirstOrDefault(x => x == path) == null)
                {
                    // add another value (not first one!)
                    fileSizesInFolder[path] += parseRes;
                } else
                {
                    Console.WriteLine(path);
                }
            }
            
        }
        else if (line.StartsWith("dir")) { 
        } else
        {
            pathsHistory.Add(path);
            startedReadingLs = false;
        }
    }

    if (line.StartsWith("$ cd"))
    {
        pathsHistory.Add(path);
        startedReadingLs = false;
        ExecuteCdCommand(line.Split("cd")[1].Trim());
    }
    if (line.StartsWith("$ ls"))
    {
        startedReadingLs = true;
    }

}

long score = 0;
var failCounter = 0;
foreach (var item in fileSizesInFolder)
{

    var res = CalculateFolderSizeWithSubfolders(item.Key);
    if (res < 100000)
    {
        Console.WriteLine("path:" + item.Key + " has value " + res);
        score += res;
    } else
    {
        failCounter++;
    }
}

Console.WriteLine(score + " " + failCounter + " results were too large");

var x = 1;

void ExecuteCdCommand(string whereTo)
{
    if (whereTo == "..")
    {
        var lastWordLength = path.Split("/").Last().Length;
        path = path.Substring(0, path.Length - lastWordLength - 1);
        if (path == string.Empty) path = "/";
    } else
    {
        path = $"{path}/{whereTo}".Replace("//", "/");
        
    }
}

long CalculateFolderSizeWithSubfolders(string pathToFile)
{
    long res = 0;

    foreach (var item in fileSizesInFolder)
    {
        if (item.Key.Contains(pathToFile))
        {
            res += item.Value;
        }
    }

    return res;
}
