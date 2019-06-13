namespace LightsOut.Test
{
    public static class LightsStub
    {
        public static bool[,] LightStub(int[,] lightsOn, int xMax, int yMax)
        {
            var lights = new bool[xMax, yMax];

            for (var x = 0; x < xMax; x++)
            {
                for (var y = 0; y < yMax; y++)
                {
                    lights[x, y] = false;
                    IsLightOn(lightsOn, lights, x, y);
                }
            }

            return lights;
        }

        private static void IsLightOn(int[,] lightsOn, bool[,] lights, int x, int y)
        {
            for (var row = 0; row < lightsOn.GetLength(0); row++)
            {
                if (x.Equals(lightsOn[row, 0]) && y.Equals(lightsOn[row, 1]))
                {
                    lights[x, y] = true;
                }
            }
        }
    }
}
