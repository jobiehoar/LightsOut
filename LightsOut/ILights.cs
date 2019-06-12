namespace LightsOut
{
    public interface ILights
    {
        int XMax { get; set; }
        int YMax { get; set; }
        bool[,] LightGrid { get; set; }
        void Initialise();
        void Display();
        bool Out();
    }
}
