using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day05;

public class Solution : BaseSolution
{
    private static Regex _moveParser = new("move (\\d+) from (\\d+) to (\\d+)");

    public Solution() : base(5, "Supply Stacks")
    {
    }

    public override string GetPart1Answer()
    {
        Dictionary<int, List<char>> stacks = GetInitialStackConfig();

        var instructions = GetInstructions();

        foreach (var instruction in instructions)
        {
            var (toMove, from, to) = ParseInstructions(instruction);

            int fromLength = stacks[from].Count;
            var items = stacks[from].GetRange(fromLength - toMove, toMove);
            items.Reverse();
            stacks[to].AddRange(items);
            stacks[from].RemoveRange(fromLength - toMove, toMove);
        }

        return GetTopStackString(stacks);
    }

    public override string GetPart2Answer()
    {
        Dictionary<int, List<char>> stacks = GetInitialStackConfig();

        var instructions = GetInstructions();

        foreach (var instruction in instructions)
        {
            var (toMove, from, to) = ParseInstructions(instruction);

            int fromLength = stacks[from].Count;
            var items = stacks[from].GetRange(fromLength - toMove, toMove);
            stacks[to].AddRange(items);
            stacks[from].RemoveRange(fromLength - toMove, toMove);
        }

        return GetTopStackString(stacks);
    }

    private static Dictionary<int, List<char>> GetInitialStackConfig()
    {
        return new()
        {
            { 1, new List<char> { 'R', 'G', 'H', 'Q', 'S', 'B', 'T', 'N' } },
            { 2, new List<char> { 'H', 'S', 'F', 'D', 'P', 'Z', 'J' } },
            { 3, new List<char> { 'Z', 'H', 'V' } },
            { 4, new List<char> { 'M', 'Z', 'J', 'F', 'G', 'H' } },
            { 5, new List<char> { 'T', 'Z', 'C', 'D', 'L', 'M', 'S', 'R' } },
            { 6, new List<char> { 'M', 'T', 'W', 'V', 'H', 'Z', 'J' } },
            { 7, new List<char> { 'T', 'F', 'P', 'L', 'Z' } },
            { 8, new List<char> { 'Q', 'V', 'W', 'S' } },
            { 9, new List<char> { 'W', 'H', 'L', 'M', 'T', 'D', 'N', 'C' } }
        };
    }

    private IEnumerable<string> GetInstructions()
    {
        return GetResourceString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .SkipWhile(x => !x.StartsWith("move"));
    }

    private static (int toMove, int from, int to) ParseInstructions(string instruction)
    {
        var match = _moveParser.Match(instruction);

        return (Convert.ToInt32(match.Groups[1].Value),
            Convert.ToInt32(match.Groups[2].Value),
            Convert.ToInt32(match.Groups[3].Value));
    }

    private static string GetTopStackString(Dictionary<int, List<char>> stacks)
    {
        StringBuilder sb = new();
        foreach (var stack in stacks)
        {
            sb.Append($"{stack.Value.Last()}");
        }

        return sb.ToString();
    }
}
