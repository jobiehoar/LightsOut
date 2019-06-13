using System.Linq;
using System.Text;

namespace LightsOut
{
    public class Lights : ILights 
    {
        private readonly IConsole _console;
        private readonly IRandom _random;

        public bool[,] LightGrid { get; set; }
        public int XMax { get; set; } = 5;
        public int YMax { get; set; } = 5;

        public Lights(IConsole console, IRandom random)
        {
            _console = console;
            _random = random;
        }

        public void Initialise()
        {
            LightGrid = new bool[XMax, YMax];

            int[] lightsOn = GetLightsOn();

            int lightNumber = -1;

            for (var x = 0; x < XMax; x++)
            {
                for (var y = 0; y < YMax; y++)
                {
                    lightNumber++;

                    if (lightsOn.Contains(lightNumber))
                        LightGrid[x, y] = true;
                    else
                        LightGrid[x, y] = false;
                }
            }
        }

        private int[] GetLightsOn()
        {
            int maxLights = XMax * YMax;

            var numberOfLightsOn = _random.Next(1, maxLights);

            var lightsOn = new int[numberOfLightsOn];

            for (var entry = 0; entry < numberOfLightsOn; entry++)
            {
                lightsOn[entry] = _random.Next(0, maxLights);
            }

            return lightsOn;
        }

        public void Display()
        {
            var header = new StringBuilder(YMax).Append(" ");
            var lights = new StringBuilder(YMax);

            for (var x = 0; x < XMax; x++)
            {
                for (var y = 0; y < YMax; y++)
                {
                    if (x.Equals(0))
                    {
                        header.Append("|").Append(y);
                    }

                    if (y.Equals(0))
                    {
                        lights.Append(x).Append("|");
                    }

                    lights.Append(LightGrid[x, y] ? "*" : " ");

                    lights.Append("|");
                }

                lights.AppendLine();
            }
            _console.WriteLine(header.Append("|").ToString());
            _console.WriteLine(lights.ToString());
        }

        public bool Out()
        {
            for (var x = 0; x < XMax; x++)
                for (var y = 0; y < YMax; y++)
                    if (LightGrid[x, y])
                        return false;

            return true;
        }
     }
}