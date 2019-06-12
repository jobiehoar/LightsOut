namespace LightsOut
{
    public class LightController : ILightController
    {
        public void Press(bool[,] lights, int xMax, int yMax, int x, int y)
        {
            ToggleSelected(lights, x, y);
            ToggleXMinusOne(lights, x, y);
            ToggleXPlusOne(lights, xMax, x, y);
            ToggleYMinusOne(lights, x, y);
            ToggleYPlusOne(lights, yMax, x, y);
        }

        private static void ToggleSelected(bool[,] lights, int x, int y)
        {
            lights[x, y] = !lights[x, y];
        }

        private static void ToggleXMinusOne(bool[,] lights, int x, int y)
        {
            if (x - 1 > 0) lights[x - 1, y] = !lights[x - 1, y];
        }

        private static void ToggleXPlusOne(bool[,] lights, int xMax, int x, int y)
        {
            if (x + 1 < xMax) lights[x + 1, y] = !lights[x + 1, y];
        }

        private static void ToggleYMinusOne(bool[,] lights, int x, int y)
        {
            if (y - 1 > 0) lights[x, y - 1] = !lights[x, y - 1];
        }

        private static void ToggleYPlusOne(bool[,] lights, int yMax, int x, int y)
        {
            if (y + 1 < yMax) lights[x, y + 1] = !lights[x, y + 1];
        }
    }
}