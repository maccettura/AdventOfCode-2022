using System.Linq;

namespace AdventOfCode.Day03;

public class Solution : BaseSolution
{
    public Solution() : base(3, "Rucksack Reorganization")
    {
    }

    public override string GetPart1Answer()
    {
        var rucksacks = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        List<char> priorities = new();
        foreach(var rucksack in rucksacks)
        {
            int mid = rucksack.Length / 2;
            var first = rucksack[new Range(0, mid)];
            var second = rucksack[new Range(mid, rucksack.Length)];

            priorities.Add(first.Intersect(second).First());
        }
        
        int totalSum = priorities.Select(ScorePriority).Sum();
        return totalSum.ToString();
    }

    public override string GetPart2Answer()
    {
        const int groupSize = 3;

        var rucksacks = GetResourceString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        List<char> priorities = new();
        for (int index = 0; index < rucksacks.Length; index += groupSize)
        {
            string[] group = rucksacks.Skip(index).Take(groupSize).ToArray();
            HashSet<char> hashSet = new (group[0]);
            hashSet.IntersectWith(group[1]);
            hashSet.IntersectWith(group[2]);
            priorities.Add(hashSet.First());
        }
        int totalSum = priorities.Select(ScorePriority).Sum();
        return totalSum.ToString();
    }

    private static int ScorePriority(char c)
    {
        int result = c - 96;

        if(result < 0)
        {
            return result + 58;
        }
        return result;
    }
}
