namespace AdventOfCode.Day02;

public class Solution : BaseSolution
{
    public Solution() : base(2, "Rock Paper Scissors")
    {
    }

    public override string GetPart1Answer()
    {
        var stratGuide = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int totalScore = 0;
        foreach (var line in stratGuide)
        {
            totalScore += ScoreRound(line);
        }

        return totalScore.ToString();
    }

    public override string GetPart2Answer()
    {
        var stratGuide = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int totalScore = 0;
        foreach (var line in stratGuide)
        {
            totalScore += ScoreRound($"{line[0]} {GetPlayByOutcome(line[0], line[2])}");
        }

        return totalScore.ToString();
    }

    private static char GetPlayByOutcome(char playerOne, char resultChar)
    {
        Result result = Result.Draw;

        if (resultChar == 'X')
        {
            result = Result.Lose;
        }
        else if(resultChar == 'Z')
        {
            result = Result.Win;
        }

        if (result == Result.Draw)
        {
            // 23 is the difference between A/X, B/Y, C/Z
            return (char)(playerOne + 23);
        }

        if (result == Result.Win && playerOne == 'A' ||
            result == Result.Lose && playerOne == 'C')
        {
            return 'Y';
        }
        else if(result == Result.Win && playerOne == 'B' ||
            result == Result.Lose && playerOne == 'A')
        {
            return 'Z';
        }
        else
        {
            return 'X';
        }
    }

    private static int ScoreRound(string input)
    {
        Result result = PlayGame(input[0], input[2]);

        // Result enum has score as backing value
        // Subtracting 87 from the ASCII value of X, Y, Z nets 1, 2, 3 respectfully
        return (int)result + (input[2] - 87);
    }

    private static Result PlayGame(char playerOne, char playerTwo)
    {
        // The difference in ASCII int values for all draw scenarios is -23
        if(playerOne - playerTwo == -23)
        {
            return Result.Draw;
        }

        if (playerOne == 'A' && playerTwo == 'Z' ||
            playerOne == 'B' && playerTwo == 'X' ||
            playerOne == 'C' && playerTwo == 'Y')
        {
            return Result.Lose;
        }
        else
        {
            return Result.Win;
        }
    }

    private enum Result
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}
