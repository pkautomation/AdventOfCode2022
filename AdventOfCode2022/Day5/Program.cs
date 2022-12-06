using SharedUtilities;

var puzzle = FileReader.ReadFile();

var stacks = InitiateStacks();
var instructions = InitiateInstructions();
var stacksAmount = int.Parse(stacks[0].Split(" ").ToList().Last(x => x != ""));
var stackArray = new Stack<char>[stacksAmount];

var iterator = 0;

foreach (var item in stackArray)
{
    stackArray[iterator] = new Stack<char>();
    iterator++;
}

stacks.RemoveAt(0); // get rid of line with just numbers of stacks
populateStacks(stacks, stackArray);

foreach (var move in instructions)
{
    var amount = int.Parse(move.Split(' ')[1]);
    var from = int.Parse(move.Split(' ')[3]) - 1;
    var to = int.Parse(move.Split(' ')[5]) - 1;

    MakeMove2(stackArray, from, to, amount);
}



void PrintTopElementsFromStacks(Stack<char>[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i].First());
    }
}

void populateStacks(List<string> stackStrings, Stack<char>[] arr)
{
    foreach (var line in stackStrings)
    {
        for(int i = 1; i < line.Length; i += 4)
        {
            if (line[i] != ' ')
            {
                //Console.Write($"symbol: {line[i]} for stack {i / 4} ");
                //Console.WriteLine();

                arr[i / 4].Push(line[i]);
            }
        }
        //Console.WriteLine();
    }
}

List<string> InitiateStacks() {
    var stackList = new List<string>();

    for(int i = 0; i < puzzle.Count; i++)
    {
        if (puzzle[i].Length == 0)
        {
            stackList.Reverse();
            return stackList;
        } else
        {
            stackList.Add(puzzle[i]);
        }
    }

    throw new NotImplementedException("file input does not contain empty new line");
}

List<string> InitiateInstructions ()
{
    var instructionList = new List<string>();

    bool startReading = false;
    for (int i = 0; i < puzzle.Count; i++)
    {
        if (startReading)
        {
            instructionList.Add(puzzle[i]);
        }
        if (puzzle[i].Length == 0) startReading = true;
    }

    return instructionList;
}


void MakeMove(Stack<char>[] stacks, int from, int to, int howMany)
{
    for (int i = 0; i < howMany; i++)
    {
        stacks[to].Push(stacks[from].Peek());
        stacks[from].Pop();
    }
}

void MakeMove2(Stack<char>[] stacks, int from, int to, int howMany)
{
    List<char> elemsToPut = new();

    for (int i = 0; i < howMany; i++)
    {
        elemsToPut.Add(stacks[from].Peek());
        stacks[from].Pop();
    }

    elemsToPut.Reverse();

    foreach (var item in elemsToPut)
    {
        stacks[to].Push(item);
    }
}
