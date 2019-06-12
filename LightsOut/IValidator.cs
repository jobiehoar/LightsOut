namespace LightsOut
{
    public interface IValidator
    {
        bool IsValid(string input, int max);
        bool IsQuit(string input);
    }
}