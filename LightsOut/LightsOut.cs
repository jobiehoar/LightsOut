using System;

namespace LightsOut
{
    public class LightsOut : ILightsOut
    {
        private readonly IConsole _console;
        private readonly ILights _lights;
        private readonly ILightController _lightController;
        private readonly IValidator _validator;

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

            while (!_lights.Out())
            {
                _console.WriteLine("Enter row number");
                var xInput = _console.ReadLine();

                if (_validator.IsQuit(xInput)) Environment.Exit(0);
                if (!_validator.IsValid(xInput, _lights.XMax)) continue;
                int.TryParse(xInput, out var x);

                _console.WriteLine("Enter column number");
                var yInput = _console.ReadLine();

                if (_validator.IsQuit(yInput)) Environment.Exit(0);
                if (!_validator.IsValid(yInput, _lights.YMax)) continue;
                int.TryParse(yInput, out var y);

                _lightController.Press(_lights.LightGrid, _lights.XMax, _lights.YMax, x, y);
                _lights.Display();
            }

            _console.WriteLine("Congratulations, you have turned out all the lights. You are a winner :)");
        }
    }
}
