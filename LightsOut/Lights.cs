using System.Linq;
using System.Text;

namespace LightsOut
{
    public class Lights : ILights 
    {
        private readonly IConsole _console;
        private readonly IRandom _random;

        public bool[,] LightGrid { get; set; }
        public int X { get; set; } = 5;
        public int Y { get; set; } = 5;

        public Lights(IConsole console, IRandom random)
        {
            _console = console;
            _random = random;
        }

        public void Initialise()
        {
            LightGrid = new bool[X, Y];

            var xRandom = _random.Next(0, X);
            var yRandom = _random.Next(0, X);

            for (var xDimension = 0; xDimension < X; xDimension++)
            {
                for (var yDimension = 0; yDimension < Y; yDimension++)
                {
                    if (xRandom.Equals(xDimension) && yRandom.Equals(yDimension))
                        LightGrid[xDimension, yDimension] = true;
                    else
                        LightGrid[xDimension, yDimension] = false;
                }
            }
        }

        public void Display()
        {
            var header = new StringBuilder(Y).Append(" ");
            var grid = new StringBuilder(Y);

            for (var xDimension = 0; xDimension < X; xDimension++)
            {
                for (var yDimension = 0; yDimension < Y; yDimension++)
                {
                    if (xDimension.Equals(0))
                    {
                        header.Append("|").Append(yDimension);
                    }

                    if (yDimension.Equals(0))
                    {
                        grid.Append(xDimension).Append("|");
                    }

                    grid.Append(LightGrid[xDimension, yDimension] ? "*" : " ");

                    grid.Append("|");
                }

                grid.AppendLine();
            }
            _console.WriteLine(header.Append("|").ToString());
            _console.WriteLine(grid.ToString());
        }

        public bool IsGameComplete()
        {
            for (var xDimension = 0; xDimension < X; xDimension++)
            {
                for (var yDimension = 0; yDimension < Y; yDimension++)
                {
                    if (LightGrid[xDimension, yDimension])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
     }
}