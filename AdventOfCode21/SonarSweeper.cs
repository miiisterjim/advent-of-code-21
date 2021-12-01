using System;
using System.Linq;

namespace AdventOfCode21
{
    public static class SonarSweeper
    {
        public static int CountPositiveStepChanges(int[] readings)
        {
            return readings.Skip(1)
                .Zip(readings, (curr, prev) => curr > prev ? 1 : 0)
                .Sum();
        }

        public static int CountSlidingWindowPositiveStepChanges(int[] readings)
        {
            var positiveStepChanges = 0;
            int? previousWindowTotal = null;

            for(int i = 0; i + 2 < readings.Length; i++)
            {
                var windowTotal = readings.Skip(i).Take(3).Sum();

                if (previousWindowTotal.HasValue)
                {
                    positiveStepChanges += windowTotal > previousWindowTotal ? 1 : 0;
                }

                previousWindowTotal = windowTotal;
            }

            return positiveStepChanges;
        }

        
    }
}