using Unity;
using Unity.Injection;

namespace LightsOut
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using Unity for dependence injection
            var container = new UnityContainer();

            RegisterTypes(container);

            // Resolve ILightsOut, this is the root of the class tree hierarchy
            var lightsOut = container.Resolve<ILightsOut>();

            lightsOut.Run(args);
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IConsole, Console>();
            container.RegisterType<IRandom, Random>();
            container.RegisterType<IValidator, Validator>();
            container.RegisterType<ILights, Lights>();
            container.RegisterType<ILightsOut, LightsOut>();
        }
    }
}
