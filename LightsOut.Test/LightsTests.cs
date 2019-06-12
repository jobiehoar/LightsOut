using Moq;
using NUnit.Framework;

namespace LightsOut.Test
{
    public class LightsTests
    {
        private ILights _lights;
        private Mock<IConsole> _consoleMock;
        private Mock<IRandom> _randomMock;

        [SetUp]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _randomMock = new Mock<IRandom>();

            _lights = new Lights(_consoleMock.Object, _randomMock.Object);
        }

        [Test]
        public void Given_a_random_starting_position_of_2_When_the_game_starts_Then_the_lights_are_displayed_correctly()
        {
            _consoleMock.Setup(console => console.WriteLine(" |0|1|2|3|4|")).Verifiable("Header not displayed correctly");
            _consoleMock.Setup(console => console.WriteLine("0| | | | |*|\r\n1| | | | | |\r\n2| | |*| | |\r\n3| | | | | |\r\n4| | | | | |\r\n")).Verifiable("Light grid not displayed correctly");

            _randomMock.SetupSequence(random => random.Next(0, 25)).Returns(2).Returns(4).Returns(12);

            _lights.Initialise();

            _lights.Display();

            _consoleMock.Verify();
        }
    }
}
