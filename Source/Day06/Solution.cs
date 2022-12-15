using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Day06;

public class Solution : BaseSolution
{
    public Solution() : base(6, "Tuning Trouble")
    {
    }

    public override string GetPart1Answer()
    {
        return GetMessageMarkerIndex(GetResourceString(), 4).ToString();
    }

    public override string GetPart2Answer()
    {
        return GetMessageMarkerIndex(GetResourceString(), 14).ToString();
    }

    private static int GetMessageMarkerIndex(string input, int offset)
    {
        for (int i = 0; i < input.Length; i++)
        {
            var diffChecker = new HashSet<char>();
            bool allDifferent = input.Skip(i).Take(offset).All(diffChecker.Add);
            if (allDifferent)
            {
                // find index
                return i + offset;
            }
        }

        return -1;
    }
}
