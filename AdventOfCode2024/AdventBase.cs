using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public abstract class AdventBase
    {
        public abstract void RunProblemOne();

        public abstract void RunProblemTwo();

        public static string[] GetInput(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
