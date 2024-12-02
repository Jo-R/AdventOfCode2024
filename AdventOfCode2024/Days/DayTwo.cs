using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    public class DayTwo : AdventBase
    {
        // https://adventofcode.com/2024/day/2
        public string[] input = GetInput("Inputs/dayTwo.txt");
        public override void RunProblemOne()
        {
            var data = GetData();
            var result = AnalyseSafety(data);
            Console.WriteLine(result);
        }

        public override void RunProblemTwo()
        {
            throw new NotImplementedException();
        }

        private List<int[]> GetData()
        {
            var data = new List<int[]>();
            foreach (var item in input)
            {

                var row = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                data.Add(row);
            }
            return data;
        }

        private int AnalyseSafety(List<int[]> data)
        {
            var result = 0;
            foreach (var item in data) { 
                var isIncreasing = item[0] < item[1];
                var isDecreasing = item[0] > item[1];
                if (isIncreasing || isDecreasing) {
                    for (var i = 1; i < item.Length; i++) { 
                        var curr = item[i];
                        var prev = item[i - 1];
                        var diff = Math.Abs(curr - prev);
                        if ((isIncreasing && curr <= prev) || (isDecreasing && curr >= prev) || diff > 3)
                        {
                            break;
                        }
                        else if (i == item.Length - 1) { 
                            result++;
                        }
                    }
                }
            }
            return result;
        }
    }
}
