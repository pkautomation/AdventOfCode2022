using Day2;
using SharedUtilities;

var puzzle = FileReader.ReadFile();

var result = 0;
var result2 = 0;

foreach (var line in puzzle)
{
    result += GetRoundResult(line);
}

Console.WriteLine(result);

foreach (var line in puzzle)
{
    result2 += GetRoundResultPart2(line);
}

Console.WriteLine(result2);

int GetRoundResult(string roundLine)
{
    var letters = roundLine.Trim();

    var opponentShape = ConvertToEnum(letters[0]);
    var playerShape = ConvertToEnum(letters[2]);


    return PlayRound(opponentShape, playerShape);
}

int GetRoundResultPart2(string roundLine)
{
    var letters = roundLine.Trim();

    var opponentShape = ConvertToEnum(letters[0]);
    var playerShape = ConvertToEnum(letters[2]);

    playerShape = changeLetterToValidOne(opponentShape, playerShape);

    return PlayRound(opponentShape, playerShape);
}

ShapeScoreValues changeLetterToValidOne(ShapeScoreValues opponentPick, ShapeScoreValues decision)
{
    // enum meaning for player changed. now enum values mean:
    // rock - lose
    // scissors - draw
    // paper - win

    if (decision == ShapeScoreValues.Paper) return opponentPick;

    if (decision == ShapeScoreValues.Rock)
    {
        if (opponentPick == ShapeScoreValues.Rock) return ShapeScoreValues.Scissors;
        if (opponentPick == ShapeScoreValues.Paper) return ShapeScoreValues.Rock;
        if (opponentPick == ShapeScoreValues.Scissors) return ShapeScoreValues.Paper;
    }

    if (decision == ShapeScoreValues.Scissors)
    {
        if (opponentPick == ShapeScoreValues.Rock) return ShapeScoreValues.Paper;
        if (opponentPick == ShapeScoreValues.Paper) return ShapeScoreValues.Scissors;
        if (opponentPick == ShapeScoreValues.Scissors) return ShapeScoreValues.Rock;
    }

    throw new NotImplementedException("cannot change letters to valid one. missing some combination for it");
}


ShapeScoreValues ConvertToEnum(char letter){
    if (letter == 'X' || letter == 'A') return ShapeScoreValues.Rock;
    if (letter == 'Y' || letter == 'B') return ShapeScoreValues.Paper;
    if (letter == 'Z' || letter == 'C') return ShapeScoreValues.Scissors;

    throw new NotImplementedException($"unpredicted shape conversion. Cannot find conversion of letter:{letter}");
}

int PlayRound(ShapeScoreValues opponentShape, ShapeScoreValues playerShape)
{
    if(playerShape == opponentShape)
    {
        return (int)RoundScoreValues.DRAW + (int)playerShape;
    }
    if(playerShape == ShapeScoreValues.Rock && opponentShape == ShapeScoreValues.Paper)
    {
        return (int)RoundScoreValues.LOSE + (int)playerShape;
    }
    if (playerShape == ShapeScoreValues.Rock && opponentShape == ShapeScoreValues.Scissors)
    {
        return (int)RoundScoreValues.WIN + (int)playerShape;
    }
    if (playerShape == ShapeScoreValues.Paper && opponentShape == ShapeScoreValues.Rock)
    {
        return (int)RoundScoreValues.WIN + (int)playerShape;
    }
    if (playerShape == ShapeScoreValues.Paper && opponentShape == ShapeScoreValues.Scissors)
    {
        return (int)RoundScoreValues.LOSE + (int)playerShape;
    }
    if (playerShape == ShapeScoreValues.Scissors && opponentShape == ShapeScoreValues.Paper)
    {
        return (int)RoundScoreValues.WIN + (int)playerShape;
    }
    if (playerShape == ShapeScoreValues.Scissors && opponentShape == ShapeScoreValues.Rock)
    {
        return (int)RoundScoreValues.LOSE + (int)playerShape;
    }

    throw new NotImplementedException("This case was not predicted!");
}