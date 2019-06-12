namespace LightsOut
{
    public interface ILights
    {
        int X { get; set; }
        int Y { get; set; }
        bool[,] LightGrid { get; set; }
        void Initialise();
        void Display();
        bool IsGameComplete();
    }
}
