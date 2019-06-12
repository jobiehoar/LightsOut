namespace LightsOut
{
    public interface IValidator
    {
        bool IsValid(string input);
        bool IsQuit(string input);
    }
}