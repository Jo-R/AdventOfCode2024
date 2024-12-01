
namespace AdventOfCode2024.Days
{
    public class DayOne : AdventBase
    {
        // https://adventofcode.com/2024/day/1
        public string[] input = GetInput("Inputs/dayOne.txt");

        public List<int> group1 = new List<int>();
        public List<int> group2 = new List<int>();

        public override void RunProblemOne()
        {
            foreach (var item in input)
            {
                var row = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                group1.Add(Int32.Parse(row[0]));
                group2.Add(Int32.Parse(row[1]));
            }
            group1.Sort();
            group2.Sort();
            var result = group1.Zip(group2, (x, y) => new { First = x, Second = y })
                .Select(p => Math.Abs(p.First - p.Second))
                .Sum(); 
           Console.WriteLine(result);
        }

        public override void RunProblemTwo()
        {
            var groupedB = group2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var result = group1.Select(x => groupedB.GetValueOrDefault(x, 0) * x).Sum();
            Console.WriteLine(result);
        }
    }
}
