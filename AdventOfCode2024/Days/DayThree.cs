using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
    public class DayThree : AdventBase
    {
        // https://adventofcode.com/2024/day/3
        public static string[] input = GetInput("Inputs/dayThree.txt");
        string joinedInput = string.Join(",", input);
        Regex mulPattern = new Regex("mul\\(([0-9]{1,3}),([0-9]{1,3})\\)");

        public override void RunProblemOne()
        {         
            var result = 0;
            foreach (Match match in mulPattern.Matches(joinedInput)) 
            {
                result += (int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));

            }
            Console.WriteLine(result);
        }

        public override void RunProblemTwo()
        {
            Regex doPattern = new Regex("(?:^|do\\(\\))(.*?)(?=(?:don't\\(\\))|$)", RegexOptions.Singleline);
            var result = 0;
            foreach (Match doMatch in doPattern.Matches(joinedInput))
            {
                foreach (Match mulMatch in mulPattern.Matches(doMatch.Groups[1].Value))
                {
                    result += (int.Parse(mulMatch.Groups[1].Value) * int.Parse(mulMatch.Groups[2].Value));

                }
            }
            Console.WriteLine(result);   
        }
    }
}
