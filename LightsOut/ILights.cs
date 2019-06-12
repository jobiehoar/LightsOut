namespace LightsOut
{
    public interface ILights
    {
        bool[,] LightGrid { get; set; }
        void Display();
        void Initialise();
    }
}
