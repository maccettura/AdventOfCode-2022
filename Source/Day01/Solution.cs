using System.Linq;

namespace AdventOfCode.Day01;

public class Solution : BaseSolution
{
    public Solution() : base(1, "Calorie Counting")
    {
    }

    public override string GetPart1Answer()
    {
        List<int> calorieSums = GetCalorieSums(GetResourceString()
            .Split(Environment.NewLine, StringSplitOptions.None));

        return calorieSums.OrderByDescending(x => x).FirstOrDefault().ToString();
    }

    public override string GetPart2Answer()
    {
        List<int> calorieSums = GetCalorieSums(GetResourceString()
            .Split(Environment.NewLine, StringSplitOptions.None));

        return calorieSums.OrderByDescending(x => x).Take(3).Sum().ToString();
    }

    private static List<int> GetCalorieSums(string[] input)
    {
        int inputIndex = 0;
        List<int> calorieSums = new();

        while (inputIndex < input.Length)
        {
            var chunk = input.Skip(inputIndex).TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            calorieSums.Add(chunk.Select(x => Convert.ToInt32(x)).Sum());
            inputIndex += chunk.Length + 1;
        }

        return calorieSums;
    }
}