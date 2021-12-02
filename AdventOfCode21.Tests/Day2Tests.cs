using NUnit.Framework;
using System;
using System.Linq;

namespace AdventOfCode21.Tests
{
    public class Day2Tests
    {
        private string[] courseData;

        [SetUp]
        public void SetUp()
        {
            var path = Environment.CurrentDirectory + "/Data/day2.txt";
            courseData = FileHelper.ReadFileRows(path).ToArray();
        }


        [Test]       
        public void Submarine_correctly_tracks_location()
        {
            var commandData = new string[] {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            Submarine submarine = new Submarine();
            SubmarineRouteParser routeParser = new SubmarineRouteParser(submarine);
            var commands = routeParser.ParseCommands(commandData);
            var routeInvoker = new RouteInvoker(commands);
            routeInvoker.InvokeCommands();
            Assert.AreEqual(150, submarine.GetCurrentLocation());
        }       

        [Test]
        public void Submarine_data_set()
        {
            Submarine submarine = new Submarine();
            SubmarineRouteParser routeParser = new SubmarineRouteParser(submarine);
            var commands = routeParser.ParseCommands(courseData);
            var routeInvoker = new RouteInvoker(commands);
            routeInvoker.InvokeCommands();
            Assert.AreEqual(2073315, submarine.GetCurrentLocation());
        }

        [Test]
        public void Submarine2_correctly_tracks_location()
        {
            var commandData = new string[] {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            Submarine2 submarine = new Submarine2();
            SubmarineRouteParser routeParser = new SubmarineRouteParser(submarine);
            var commands = routeParser.ParseCommands(commandData);
            var routeInvoker = new RouteInvoker(commands);
            routeInvoker.InvokeCommands();
            Assert.AreEqual(900, submarine.GetCurrentLocation());
        }

        [Test]
        public void Submarine2_data_set()
        {
            Submarine2 submarine = new Submarine2();
            SubmarineRouteParser routeParser = new SubmarineRouteParser(submarine);
            var commands = routeParser.ParseCommands(courseData);
            var routeInvoker = new RouteInvoker(commands);
            routeInvoker.InvokeCommands();
            Assert.AreEqual(1840311528, submarine.GetCurrentLocation());
        }


    }
}