using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    public class DayThree : AdventBase
    {
        // https://adventofcode.com/2024/day/3
        public string[] input = GetInput("Inputs/dayThree.txt");

        public override void RunProblemOne()
        {
            string pattern = @"mul\([0-9]+,[0-9]+\)";
            var allMatches = new List<Match>();
            foreach (string inputItem in input) {
                var matches = Regex.Matches(inputItem, pattern, RegexOptions.None);
                foreach (Match match in matches) {
                    allMatches.Add(match);
                 }
            }
            
            var result = 0;
            string numsOnly = @"[0-9]+,[0-9]+";
            foreach (Match match in allMatches) 
            {
                var matchNums = Regex.Match(match.Value, numsOnly).Value.Split(",");
                Console.WriteLine($"{matchNums[0]} {matchNums[1]}");
                result += int.Parse(matchNums[0]) * int.Parse(matchNums[1]);
                
            }
            Console.WriteLine(result);  // 29369763 is too low
        }

        public override void RunProblemTwo()
        {
            throw new NotImplementedException();
        }
    }
}
