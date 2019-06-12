namespace LightsOut
{
    public interface ILightController
    {
        void Press(bool[,] lights, int xMax, int yMax, int x, int y);
    }
}