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
        public void Given_two_lights_are_on_When_the_user_presses_a_light_Then_the_game_is_not_complete()
        {
            var lightsOn = new int[3, 2] { { 1, 3 }, { 2, 3 }, { 4, 4 } };

            var lightStub = LightsStub.LightStub(lightsOn, _lights.XMax, _lights.YMax);

            _lights.LightGrid = lightStub;

            Assert.IsFalse(_lights.Out());
        }

        [Test]
        public void Given_all_lights_are_out_When_the_user_presses_a_light_Then_the_game_is_complete()
        {
            var lightsOn = new int[0, 2];

            var lightStub = LightsStub.LightStub(lightsOn, _lights.XMax, _lights.YMax);

            _lights.LightGrid = lightStub;

            Assert.IsTrue(_lights.Out());
        }

        [Test]
        public void Given_a_random_starting_position_When_the_game_starts_Then_the_correct_lights_are_on()
        {
            _consoleMock.Setup(console => console.WriteLine(" |0|1|2|3|4|")).Verifiable("Header not displayed correctly");
            _consoleMock.Setup(console => console.WriteLine("0| | | | |*|\r\n1| | | | | |\r\n2| | |*| | |\r\n3| | | | | |\r\n4| | | | | |\r\n")).Verifiable("Light grid not displayed correctly");

            _randomMock.Setup(random => random.Next(1, 25)).Returns(2);
            _randomMock.SetupSequence(random => random.Next(0, 25)).Returns(4).Returns(12);

            _lights.Initialise();

            _lights.Display();

            _consoleMock.Verify();
        }
    }
}
