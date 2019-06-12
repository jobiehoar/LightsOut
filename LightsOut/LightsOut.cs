using System;
using Unity;

namespace LightsOut
{
    public class LightsOut : ILightsOut
    {
        private readonly IValidator _validator;
        private readonly IConsole _console;
        private readonly ILights _lights;

        public LightsOut(IValidator validator, IConsole console, ILights lights)
        {
            _validator = validator;
            _console = console;
            _lights = lights;
        }

        public void Run(string[] args)
        {
            _console.WriteLine("--- Welcome to the Lights Out game! ---");

            _lights.Display();

            _console.WriteLine("Enter q to quit");

            while (!GetInput())
            {
                // Getinput
            }
        }

        private bool GetInput()
        {
            _console.WriteLine("Enter x co-ordinates");
            var x = _console.ReadLine();
            if (_validator.IsQuit(x)) Environment.Exit(0);
            if (!_validator.IsValid(x)) return false;

            _console.WriteLine("Enter y co-ordinates");
            var y = _console.ReadLine();
            if (_validator.IsQuit(y)) Environment.Exit(0);
            if (!_validator.IsValid(y)) return false;

            return true;
        }
    }
}
