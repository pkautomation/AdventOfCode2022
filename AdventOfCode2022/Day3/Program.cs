using SharedUtilities;

var puzzle = FileReader.ReadFile();

var globalCounter = 0;
var globalCounter2 = 0;

foreach (var line in puzzle)
{
	var firstPart = line.Substring(0, line.Length / 2);
	var secondPart = line.Substring(line.Length / 2, line.Length / 2);

	char letter = getRepeatingLetter(firstPart, secondPart);
	//26 liter, A -> 65 ascii
	if((int)letter - 65 > 26)
	{
        globalCounter += (int)letter - 96;
    } else
	{
        globalCounter += (int)letter - 64 + 26;
    }
}

for(int i = 0; i < puzzle.Count; i++)
{
	if(i % 3 == 0)
	{
		var firstElfWord = puzzle[i];
		var secondElfWord = puzzle[i + 1];
		var thirdElfWord = puzzle[i + 2];

		char letter = getRepeatingLetter2(firstElfWord, secondElfWord, thirdElfWord);

        if ((int)letter - 65 > 26)
        {
            globalCounter2 += (int)letter - 96;
        }
        else
        {
            globalCounter2 += (int)letter - 64 + 26;
        }
    }
}

Console.WriteLine(globalCounter);
Console.WriteLine(globalCounter2);



int countAmountOfParticularLetter(char letter, string expression) {
	var counter = 0;

	foreach (var letterInExpression in expression)
	{
		if (letter == letterInExpression)
		{
			counter++;
		}
	}

	return counter;
}

char getRepeatingLetter(string firstString, string secondString)
{
	foreach (var letter in firstString)
	{
		if (countAmountOfParticularLetter(letter, secondString) >= 1) return letter;
	}

    throw new NotImplementedException($"could not find repeating letter in strings: {firstString} and {secondString}");
}

char getRepeatingLetter2(string firstString, string secondString, string thirdString)
{
    foreach (var letter in firstString)
    {
        if (countAmountOfParticularLetter(letter, secondString) >= 1 && countAmountOfParticularLetter(letter, thirdString) >=1 ) return letter;
    }

    throw new NotImplementedException($"could not find repeating letter in strings: {firstString} and {secondString} and {thirdString}");
}