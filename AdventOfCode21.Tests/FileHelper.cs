using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode21.Tests
{
    internal static class FileHelper
    {

        internal static string[] ReadFileRows(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
