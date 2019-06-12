using Moq;
using NUnit.Framework;

namespace LightsOut.Test
{
    public class LightsTests
    {
        private ILights _lights;
        
        [SetUp]
        public void Setup()
        {
            var consoleMock = new Mock<IConsole>();
            var randomMock = new Mock<IRandom>();
            _lights = new Lights(consoleMock.Object, randomMock.Object);
        }

        [Test]
        public void Given__When__Then_()
        {
            _lights.Display();

            //Assert.IsTrue();
        }
    }
}
