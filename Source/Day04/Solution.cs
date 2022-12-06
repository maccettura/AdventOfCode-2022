using System.Linq;

namespace AdventOfCode.Day04;

public class Solution : BaseSolution
{
    public Solution() : base(4, "Camp Cleanup")
    {
    }

    public override string GetPart1Answer()
    {
        var assignments = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int overlappingTotal = 0;
        foreach(var assignment in assignments)
        {
            var sub = assignment.Split(',');

            var first = sub[0].Split('-').Select(int.Parse).ToArray();
            var second = sub[1].Split('-').Select(int.Parse).ToArray();

            if (first[0] >= second[0] && first[1] <= second[1])
            {
                overlappingTotal++;
            }
            else if (second[0] >= first[0] && second[1] <= first[1])
            {
                overlappingTotal++;
            }
        }
        return overlappingTotal.ToString();
    }

    public override string GetPart2Answer()
    {
        var assignments = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int overlappingTotal = 0;
        foreach (var assignment in assignments)
        {
            var sub = assignment.Split(',');

            var first = sub[0].Split('-').Select(int.Parse).ToArray();
            var second = sub[1].Split('-').Select(int.Parse).ToArray();

            if (first[0] <= second[1] && second[0] <= first[1])
            {
                overlappingTotal++;
            }
        }
        return overlappingTotal.ToString();
    }
}
