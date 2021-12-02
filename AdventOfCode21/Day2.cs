using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode21
{
    public abstract class Command
    {
        protected readonly ISubmarine submarine;

        public Command(ISubmarine submarine)
        {
            this.submarine = submarine;
        }

        public abstract void Execute();

    }

    public class MoveForward : Command
    {
        private readonly int distance;

        public MoveForward(ISubmarine submarine, int distance) : base(submarine)
        {
            this.distance = distance;
        }

        public override void Execute()
        {
            submarine.MoveHorizontally(distance);
        }
    }

    public class MoveUp : Command
    {
        private readonly int distance;

        public MoveUp(ISubmarine submarine, int distance) : base(submarine)
        {
            this.distance = distance;
        }

        public override void Execute()
        {
            submarine.MoveVertically(-distance);
        }
    }

    public class MoveDown : Command
    {
        protected readonly int distance;

        public MoveDown(ISubmarine submarine, int distance) : base(submarine)
        {
            this.distance = distance;
        }

        public override void Execute()
        {
            submarine.MoveVertically(distance);
        }
    }

    public interface ISubmarine
    {
        int GetCurrentLocation();
        void MoveHorizontally(int changeInX);
        void MoveVertically(int changeInY);
    }

    public class Submarine : ISubmarine
    {
        protected int currentX = 0;
        protected int currentY = 0;        

        public int GetCurrentLocation()
        {
            return currentX * currentY; 
        }

        public Submarine()
        {
        }

        public virtual void MoveHorizontally(int changeInX)
        {
            currentX += changeInX;
        }

        public virtual void MoveVertically( int changeInY)
        {
            currentY += changeInY;
        }
    }

    public class Submarine2 : Submarine
    {
        protected int currentAim = 0;               

        public Submarine2()
        {
        }

        public override void MoveHorizontally(int changeInX)
        {
            currentX += changeInX;
            currentY += currentAim * changeInX;
        }

        public override void MoveVertically(int changeInY)
        {
            currentAim += changeInY;
        }
    }

    public class RouteInvoker
    {
        List<Command> commands;

        public RouteInvoker(List<Command> commands)
        {
            this.commands = commands;
        }

        public void InvokeCommands()
        {
            commands.ForEach(command => command.Execute());
        }
    }

    public class SubmarineRouteParser 
    {
        protected readonly ISubmarine submarine;

        public SubmarineRouteParser(ISubmarine submarine)
        {
            this.submarine = submarine;
        }

        public List<Command> ParseCommands(string[] commands)
        {
            return commands.Select(command => ParseCommand(command)).ToList();
        }

        protected virtual Command ParseCommand(string commandStr)
        {            
            var commandParts = commandStr.Split(" ");
            var command = commandParts[0];
            var distance = int.Parse(commandParts[1]);

            switch (command)
            {
                case "forward":
                    return new MoveForward(submarine, distance);
                case "up": 
                    return new MoveUp(submarine, distance);
                case "down":
                    return new MoveDown(submarine, distance);
                default:
                    throw new Exception("Should have implemented a factory!");

            }
        }
    } 
}
