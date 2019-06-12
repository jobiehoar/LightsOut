using System;

namespace LightsOut
{
    public class Validator : IValidator
    {
        private readonly IConsole _console;

        public Validator(IConsole console)
        {
            _console = console;
        }



        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                _console.WriteLine("Please enter a value");
                return false;
            }

            if (!int.TryParse(input, out _))
            {
                _console.WriteLine("Please enter an integer");
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
