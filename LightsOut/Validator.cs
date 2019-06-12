namespace LightsOut
{
    public class Validator : IValidator
    {
        private readonly IConsole _console;

        public Validator(IConsole console)
        {
            _console = console;
        }

        public bool IsValid(string input, int max)
        {
            if (string.IsNullOrEmpty(input))
            {
                _console.WriteLine("Please enter a value");
                return false;
            }

            if (!int.TryParse(input, out var x))
            {
                _console.WriteLine("Please enter an integer");
                return false;
            }

            if (x >= max)
            {
                _console.WriteLine("Please enter an integer between 0 and " + (max - 1));
                return false;
            }

            return true;
        }

        public bool IsQuit(string input)
        {
            return input.ToLower().Equals("q");
        }
    }
}
