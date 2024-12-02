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
            var result = AnalyseSafety(data, false);
            Console.WriteLine(result);
        }

        public override void RunProblemTwo()
        {
            var data = GetData();
            var result = AnalyseSafety(data, true);
            Console.WriteLine(result);
        }

        private List<List<int>> GetData()
        {
            var data = new List<List<int>>();
            foreach (var item in input)
            {

                var row = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                data.Add(row);
            }
            return data;
        }

        private int AnalyseSafety(List<List<int>> data, bool withDampener)
        {
            var result = 0;
            foreach (var item in data)
            {
                if (IsSafe(item))
                {
                    result++;
                }
                else if (withDampener) 
                {
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (IsSafe(item.Where((x, index) => index != i).ToList()))
                        {
                            result++;
                            break;
                        }
                    }
                }
               
            }
            return result;
        }

        private bool IsSafe(List<int> item)
        {
            var isIncreasing = item[0] < item[1];
            var isDecreasing = item[0] > item[1];
            if (isIncreasing || isDecreasing)
            {
                for (var i = 1; i < item.Count; i++)
                {
                    var curr = item[i];
                    var prev = item[i - 1];
                    var diff = Math.Abs(curr - prev);
                    if ((isIncreasing && curr <= prev) || (isDecreasing && curr >= prev) || diff > 3)
                    {
                        return false;
                    }
                    else if (i == item.Count - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
