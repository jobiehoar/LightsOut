namespace LightsOut
{
    /// <summary>
    /// Wrapper class for Console
    /// </summary>
    public class Console : IConsole
    {
        public void WriteLine(string log)
        {
            System.Console.WriteLine(log);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
