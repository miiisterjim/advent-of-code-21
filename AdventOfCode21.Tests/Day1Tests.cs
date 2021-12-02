using NUnit.Framework;
using System;
using System.Linq;
using System.IO;

namespace AdventOfCode21.Tests
{
    public class Day1Tests
    {
        private int[] readings;

        [SetUp]
        public void SetUp()
        {
            var path = Environment.CurrentDirectory + "/Data/day1.txt";
            readings = FileHelper.ReadFileRows(path).Select(str => int.Parse(str)).ToArray();
        }

        [Test]
        [TestCase(new int[] { 3, 4 }, ExpectedResult = 1)]
        [TestCase(new int[] { 10, 500 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 5, 40 }, ExpectedResult = 2)]

        public int CountPositiveStepChanges_increments_a_counter_for_positive_step_changes(int[] readings)
        {
            int count = SonarSweeper.CountPositiveStepChanges(readings);
            return count;
        }

        [Test]
        [TestCase(new int[] { 4, 3 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1000, 500 }, ExpectedResult = 0)]
        [TestCase(new int[] { 5, 5 }, ExpectedResult = 0)]

        public int CountPositiveStepChanges_calculates_zero_when_no_positive_step_changes(int[] readings)
        {
            int count = SonarSweeper.CountPositiveStepChanges(readings);
            return count;
        }

        [Test]
        public void CountPositiveStepChanges_calculates_positive_step_changes_with_mixed_data()
        {
            int count = SonarSweeper.CountPositiveStepChanges(readings);
            Assert.AreEqual(1292, count);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 3)]
        public int CountSlidingWindowPositiveStepChanges_returns_one_for_a_positive_sliding_window_step_change(int[] readings)
        {           
            return SonarSweeper.CountSlidingWindowPositiveStepChanges(readings);            
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 4)]
        public int CountSlidingWindowPositiveStepChanges_ignores_incomplete_windows(int[] readings)
        {
            return SonarSweeper.CountSlidingWindowPositiveStepChanges(readings);
        }

        [Test]
        public void ountSlidingWindowPositiveStepChanges_calculates_positive_step_changes_with_mixed_data()
        {
            int count = SonarSweeper.CountSlidingWindowPositiveStepChanges(readings);
            Assert.AreEqual(1262, count);
        }
    }
}