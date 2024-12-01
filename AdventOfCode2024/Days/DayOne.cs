
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
                var row = item.Split(" ");
                group1.Add(Int32.Parse(row[0]));
                group2.Add(Int32.Parse(row[3]));
            }
            group1.Sort();
            group2.Sort();
            var bothSets = group1.Zip(group2, (x, y) => new { First = x, Second = y });
            int result = 0;
            foreach (var comp in bothSets)
            {
                var sub = Math.Abs(comp.First - comp.Second);
                result += sub;
            }

           Console.WriteLine(result);
        }

        public override void RunProblemTwo()
        {
            var list2Counts = new Dictionary<int, int>();
            foreach (var item in group2) {
                if (list2Counts.ContainsKey(item))
                {
                    list2Counts[item]++;
                }
                else
                {
                    list2Counts[item] = 1;
                }
            }

            var result = 0;
            foreach (var item in group1) {
                if (list2Counts.ContainsKey(item)) {
                    var score = item * list2Counts[item];
                    result += score;
                }
            }
            Console.WriteLine(result);
        }
    }
}
