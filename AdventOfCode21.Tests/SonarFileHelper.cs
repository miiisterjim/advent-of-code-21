using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode21.Tests
{
    internal static class SonarFileHelper
    {
        internal static string[] ReadFileRows()
        {
            return File.ReadAllLines(Environment.CurrentDirectory + "/Data/day1.txt");

    }
    }
}
