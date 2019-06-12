using System;

namespace LightsOut
{
    public class LightsOut : ILightsOut
    {
        private readonly IConsole _console;
        private readonly ILights _lights;
        private readonly ILightController _lightController;
        private readonly IValidator _validator;
        private int _x;
        private int _y;

        public LightsOut(IValidator validator, IConsole console, ILights lights, ILightController lightController)
        {
            _validator = validator;
            _console = console;
            _lights = lights;
            _lightController = lightController;
        }

        public void Run(string[] args)
        {
            _console.WriteLine("--- Welcome to the Lights Out game! ---");

            _lights.Initialise();

            _lights.Display();

            _console.WriteLine("Enter q to quit");

            while (!_lights.IsGameComplete())
            {
                if (!IsInputValid()) continue;

                _lightController.Press(_lights.LightGrid, _lights.X, _lights.Y, _x, _y);

                _lights.Display();
            }

            _console.WriteLine("Congratulations, you have turned out all the lights. You are a winner :)");
        }

        private bool IsInputValid()
        {
            _console.WriteLine("Enter x co-ordinates");
            var x = _console.ReadLine();
            if (_validator.IsQuit(x)) Environment.Exit(0);
            if (!_validator.IsValid(x, _lights.X)) return false;
            int.TryParse(x, out _x);

            _console.WriteLine("Enter y co-ordinates");
            var y = _console.ReadLine();
            if (_validator.IsQuit(y)) Environment.Exit(0);
            if (!_validator.IsValid(y, _lights.Y)) return false;
            int.TryParse(y, out _y);

            return true;
        }
    }
}
